using CARDOC.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace CARDOC.Utils
{
    public static class DataProvider
    {
        static DataProvider()
        {
            Vehicles = new List<Vehicle>();
        }
        public static List<Vehicle> Vehicles { get; private set; }
        public static Dictionary<string, Vehicle> Templates { get; private set; }
        public static SortedSet<string> Types { get; private set; }
        public static SortedDictionary<string, SortedSet<string>> Models { get; private set; }
        public static string[] Colors { get { return new string[] { "чорний", "коричневий", "сірий", "білий", "синій", "зелений", "жовтий", "червоний" }; } }
        public static SortedSet<string> PartNames { get; private set; }
        public static string[] PartTypes { get { return new string[] { PartType.Zip.GetDescription(), PartType.Equipment.GetDescription(), PartType.Aggregate.GetDescription(), PartType.Tire.GetDescription(), PartType.Battery.GetDescription(), PartType.EquipmentCargo.GetDescription(), }; } }
        public static string[] PartUnits { get { return new string[] { Const.DefaultPartUnits, "к-т", "пара" }; } }
        public static List<Vehicle> ReadAll()
        {
            var vehicles = new List<Vehicle>();
            DirectoryInfo d = new DirectoryInfo(Const.DataFolder);
            FileInfo[] Files = d.GetFiles("*.json");
            foreach (FileInfo file in Files)
            {
                try
                {
                    using (StreamReader r = new StreamReader(file.FullName))
                    {
                        string json = r.ReadToEnd();
                        if (!string.IsNullOrEmpty(json))
                        {
                            vehicles.AddRange(JsonConvert.DeserializeObject<List<Vehicle>>(json));
                        }
                    }
                }
                catch
                {
                    // todo: error handling
                }
            }
            Vehicles = vehicles.OrderVehicles().ToList();
            return Vehicles;
        }

        public static void Cleanout()
        {
            var vins = new string[]
            {
                "AHTDB3CD605622765","381337","1HPLUAFP2AX385065","381335","380882","380751","380733","380843","380849","380749","380897","380859","380857","380756","380767","380782","1HTWEAZR4AJ173814","10TDC1523CS733592","10TDC1525KS788432","10TDC1527KS788531","10TDC1525KS788236","TM-208815EHHV","TM-208816EHHV","10TDC1523CS749775","TM-208824EHHV","VF6TRM2000S007316","JTEEB71JХ0F016862","JTEEB71J50F017000","VF640K837PB000161","MMBJJKL10NH073389","JTEEB71J30F016444","JTEEB71J70F016589","JTEEB71J40F016825","JTEEB71J40F016839","JTEEB71J70F016897","JTEEB71J90F016965","JTEEB71J40F016971","VF640K834PB000165","JTMHV09J2B4050815","JTMHV09J2B4050975","JTMHV09J8B5022429","MMBJJKL10NH074931","MMBJJKL10NH076392","MMBJJKL10NH072946","MMBJJKL10NH073105","MMBJJKL10NH074639","MMBNGV542NH209270","MMBNGV543NH209892","MMBNGV543NH210055","MMBNGV546NH210129","MMBNGV547NH210107","VR3FDAHDJM3005476"
            };
            foreach (var vin in vins)
            {
                var vehicle = Vehicles.First(x => x.Vin == vin);
                if (vehicle.OutDate < new DateTime(2022, 11, 11)) {
                    vehicle.Unit = "";
                    vehicle.Order = "";
                    vehicle.OutDate = Vehicle.EmptyDate;
                    Write(vehicle);
                }
            }
        }

        private static string GetDataPath(DateTime date)
        {
            return Const.DataFolder + "/" + date.ToString(Const.DateFormat) + ".json";
        }

        public static List<Vehicle> Read(DateTime date)
        {
            try
            {
                using (StreamReader r = new StreamReader(GetDataPath(date)))
                {
                    string json = r.ReadToEnd();
                    if (!string.IsNullOrEmpty(json))
                    {
                        return JsonConvert.DeserializeObject<List<Vehicle>>(json).OrderVehicles().ToList();
                    }
                }
            }
            catch
            {
                // todo: error handling
            }
            return new List<Vehicle>();
        }

        public static void Write(DateTime date)
        {
            Vehicles = Vehicles.OrderVehicles().ToList();
            var vehicles = Vehicles.Where(x => x.Date.Date == date.Date).ToList();
            using (StreamWriter r = new StreamWriter(GetDataPath(date)))
            {
                string json = JsonConvert.SerializeObject(vehicles);
                r.Write(json);
            }
        }

        public static bool Exists(Vehicle vehicle)
        {
            return Vehicles.Any(x => x.Vin == vehicle.Vin);
        }

        public static void Write(Vehicle vehicle)
        {
            var existing = Vehicles.FirstOrDefault(x => x.Vin == vehicle.Vin);
            var prevDate = vehicle.Date;
            if (existing != null)
            {
                prevDate = existing.Date;
                Vehicles.Remove(existing);
            }
            Vehicles.Add(vehicle);
            AddCache(vehicle);
            Write(vehicle.Date);
            if(vehicle.Date != prevDate)
                Write(prevDate);
        }

        public static void Remove(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
            Write(vehicle.Date);
        }

        private static void AddCache(Vehicle vehicle)
        {
            Types.Add(vehicle.Type);
            if (Models.TryGetValue(vehicle.Manufacturer, out SortedSet<string> models))
                Models[vehicle.Manufacturer].Add(vehicle.Model);
            else
                Models.Add(vehicle.Manufacturer, new SortedSet<string> { vehicle.Model });
            foreach (var part in vehicle.Parts)
                PartNames.Add(part.Name);
        }

        public static void FillCache()
        {
            Types = new SortedSet<string>();
            Models = new SortedDictionary<string, SortedSet<string>>();
            PartNames = new SortedSet<string>();
            foreach (var vehicle in Vehicles.Union(Templates.Values))
            {
                Types.Add(vehicle.Type);
                foreach(var part in vehicle.Parts)
                    PartNames.Add(part.Name);
            }
            foreach (var manufacturer in Vehicles.Union(Templates.Values).GroupBy(x => x.Manufacturer))
            {
                Models.Add(manufacturer.Key, manufacturer.OrderBy(x => x.Model).Select(x => x.Model).ToSortedSet<string>());
            }
        }

        private static string GetTemplatePath(Vehicle vehicle)
        {
            return Const.TemplateFolder + "/" + vehicle.TemplateName + ".json";
        }

        public static List<Vehicle> ReadAllTemplates()
        {
            var templates = new List<Vehicle>();
            DirectoryInfo d = new DirectoryInfo(Const.TemplateFolder);
            FileInfo[] Files = d.GetFiles("*.json");
            foreach (FileInfo file in Files)
            {
                try
                {
                    using (StreamReader r = new StreamReader(file.FullName))
                    {
                        string json = r.ReadToEnd();
                        if (!string.IsNullOrEmpty(json))
                        {
                            templates.Add(JsonConvert.DeserializeObject<Vehicle>(json));
                        }
                    }
                }
                catch
                {
                    // todo: error handling
                }
            }
            Templates = templates.ToDictionary(x => x.TemplateName);
            return templates;
        }

        public static void WriteTemplate(Vehicle vehicle)
        {
            if (vehicle.TemplateName == null)
                return;
            using (StreamWriter r = new StreamWriter(GetTemplatePath(vehicle)))
            {
                string json = JsonConvert.SerializeObject(vehicle);
                r.Write(json);
            }
            var templateName = vehicle.TemplateName;
            if (Templates.ContainsKey(templateName))
                Templates[templateName] = vehicle;
            else
                Templates.Add(templateName, vehicle);
            FillCache();
        }
    }
}
