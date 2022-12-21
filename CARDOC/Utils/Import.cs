using CARDOC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CARDOC.Utils
{
    internal class Import
    {
        public static void FromCsv(StreamReader stream)
        {
            DateTime date = DateTime.Now;
            using (StreamWriter sw = new StreamWriter("import.csv")) {
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    var values = line.Split(',');
                    if (values[1].StartsWith("Зведений реєстр автомобілів"))
                    {
                        DataProvider.Write(date);
                        date = DateTime.ParseExact(values[1].Replace("Зведений реєстр автомобілів", "").Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        continue;
                    }
                    if (int.TryParse(values[1], out int result))
                    {
                        var words = values[3].Trim().Split(' ');
                        var type = "";
                        var manufacturer = "";
                        var model = "";
                        var vin = "";
                        var str = "";
                        for (var i = 0; i < words.Length; i++)
                        {
                            var word = words[i];
                            if (word.Length == 0)
                                continue;
                            if (type == "")
                            {
                                if (Regex.IsMatch(word, @"\p{IsCyrillic}") && !word.Contains("УАЗ", StringComparison.InvariantCultureIgnoreCase) && !word.Contains("КРАЗ", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    str += word + " ";
                                }
                                else
                                {
                                    type = str;
                                    str = "";
                                    if (manufacturer == "")
                                    {
                                        manufacturer = word;
                                    }
                                }
                            } else if (i == words.Length - 1)
                            {
                                vin = word;
                            }
                            else if (i != words.Length - 1)
                            {
                                model += word + " ";
                            }
                        }
                        decimal price = 0;
                        string unit = "";
                        string order = "";
                        DateTime outDate = Vehicle.EmptyDate;
                        if (values.Length > 4) {
                            decimal.TryParse(values[4].Trim(), out price);
                            unit = values[5].Replace("в/ч ", "").Trim();
                            order = values[6].Replace("№ ", "").Trim();
                            if (!DateTime.TryParseExact(values[7].Trim(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate))
                                outDate = Vehicle.EmptyDate;
                        }
                        if (manufacturer == "MAXX")
                        {
                            manufacturer = "MAXX PRO";
                            model = model.Replace("PRO ", "");
                        }
                        var vehicle = new Vehicle
                        {
                            Date = date,
                            Type = type.Trim(),
                            Manufacturer = manufacturer.Trim().ToUpper(),
                            Model = model.Trim().ToUpper(),
                            Vin = vin.Trim().ToUpper(),
                            Price = price,
                            Unit = unit.Trim(),
                            Order = order.Trim(),
                            OutDate = outDate,
                            Parts = new List<Part>()
                        };
                        DataProvider.Vehicles.Add(vehicle);
                        sw.WriteLine("{0,15}{1,40}{2,30}{3,40}{4,25}{5,20}{6,50}{7,40}{8,30}", vehicle.Date, vehicle.Type, vehicle.Manufacturer, vehicle.Model, vehicle.Vin, vehicle.Price, vehicle.Unit, vehicle.Order, vehicle.OutDate);
                    }
                }
            }
            DataProvider.FillCache();
        }
    }
}
