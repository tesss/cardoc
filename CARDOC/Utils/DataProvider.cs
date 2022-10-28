using CARDOC.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace CARDOC.Utils
{
    public static class DataProvider
    {
        static DataProvider()
        {
            Vehicles = new List<Vehicle>();
        }
        public static List<Vehicle> Vehicles { get; private set; }
        public static HashSet<string> Types { get; private set; }
        public static Dictionary<string, HashSet<string>> Models { get; private set; }
        public static string[] Colors { get { return new string[] { "Чорний", "Коричневий", "Сірий", "Білий", "Синій", "Зелений", "Жовтий", "Червоний" }; } }
        public static HashSet<string> PartNames { get; private set; }
        public static string[] PartTypes { get { return new string[] { "ЗІП", "Агрегат", "Обладнання", "Шина", "Батарея" }; } }
        public static string[] PartUnits { get { return new string[] { "шт", "к-т" }; } }
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
            FillCache();
            return vehicles;
        }

        public static List<Vehicle> Read(DateTime date)
        {
            try
            {
                using (StreamReader r = new StreamReader(Const.DataFolder + "/" + date.ToString(Const.DateFormat) + ".json"))
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
            using (StreamWriter r = new StreamWriter(Const.DataFolder + "/" + date.ToString(Const.DateFormat) + ".json"))
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
        private static void FillCache()
        {
            Types = new HashSet<string>();
            Models = new Dictionary<string, HashSet<string>>();
            PartNames = new HashSet<string>();
            foreach (var vehicle in Vehicles)
            {
                Types.Add(vehicle.Type);
                foreach(var part in vehicle.Parts)
                    PartNames.Add(part.Name);
            }
            foreach (var manufacturer in Vehicles.GroupBy(x => x.Manufacturer))
            {
                Models.Add(manufacturer.Key, manufacturer.Select(x => x.Model).ToHashSet());
            }
        }
    }
}
