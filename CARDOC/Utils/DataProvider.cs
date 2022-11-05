using CARDOC.Models;
using Newtonsoft.Json;
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
        public static HashSet<string> Types { get; private set; }
        public static Dictionary<string, HashSet<string>> Models { get; private set; }
        public static string[] Colors { get { return new string[] { "Чорний", "Коричневий", "Сірий", "Білий", "Синій", "Зелений", "Жовтий", "Червоний" }; } }
        public static HashSet<string> PartNames { get; private set; }
        public static string[] PartTypes { get { return new string[] { PartType.Zip.GetDescription(), PartType.Equipment.GetDescription(), PartType.Aggregate.GetDescription(), PartType.Tire.GetDescription(), PartType.Battery.GetDescription() }; } }
        public static string[] PartUnits { get { return new string[] { Const.DefaultPartUnits, "к-т", "пар" }; } }
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
            Vehicles = vehicles.OrderByDescending(x => x.Date).ToList();
            return vehicles;
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
                        return JsonConvert.DeserializeObject<List<Vehicle>>(json).OrderByDescending(x => x.Date).ToList();
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
            Vehicles = Vehicles.OrderByDescending(x => x.Date).ToList();
            var vehicles = Vehicles.Where(x => x.Date.Date == date.Date).ToList();
            using (StreamWriter r = new StreamWriter(GetDataPath(date)))
            {
                string json = JsonConvert.SerializeObject(vehicles);
                r.Write(json);
            }
        }

        public static void Write(Vehicle vehicle, DateTime date)
        {
            var existing = Vehicles.FirstOrDefault(x => x.Vin == vehicle.Vin);
            if (existing != null)
                Vehicles.Remove(existing);
            Vehicles.Add(vehicle);
            AddCache(vehicle);
            Write(date);
        }

        public static void Remove(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
            Write(vehicle.Date);
        }

        private static void AddCache(Vehicle vehicle)
        {
            Types.Add(vehicle.Type);
            if (Models.TryGetValue(vehicle.Manufacturer, out HashSet<string> models))
                Models[vehicle.Manufacturer].Add(vehicle.Model);
            else
                Models.Add(vehicle.Manufacturer, new HashSet<string> { vehicle.Model });
            foreach (var part in vehicle.Parts)
                PartNames.Add(part.Name);
        }

        public static void FillCache()
        {
            Types = new HashSet<string>();
            Models = new Dictionary<string, HashSet<string>>();
            PartNames = new HashSet<string>();
            foreach (var vehicle in Vehicles.Union(Templates.Values))
            {
                Types.Add(vehicle.Type);
                foreach(var part in vehicle.Parts)
                    PartNames.Add(part.Name);
            }
            foreach (var manufacturer in Vehicles.Union(Templates.Values).GroupBy(x => x.Manufacturer))
            {
                Models.Add(manufacturer.Key, manufacturer.Select(x => x.Model).ToHashSet());
            }
        }

        private static string GetTemplatePath(Vehicle vehicle)
        {
            return Const.TemplateFolder + "/" + (vehicle.Manufacturer + " " + vehicle.Model).RemoveInvalidChars() + ".json";
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
            Templates = templates.ToDictionary(x => x.GetTemplateName());
            return templates;
        }

        public static void WriteTemplate(Vehicle vehicle)
        {
            if (vehicle.GetTemplateName() == null)
                return;
            using (StreamWriter r = new StreamWriter(GetTemplatePath(vehicle)))
            {
                string json = JsonConvert.SerializeObject(vehicle);
                r.Write(json);
            }
            var templateName = vehicle.GetTemplateName();
            if (Templates.ContainsKey(templateName))
                Templates[templateName] = vehicle;
            else
                Templates.Add(templateName, vehicle);
            FillCache();
        }
    }
}
