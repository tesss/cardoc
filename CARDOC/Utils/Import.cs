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
            string fileName = null;
            if (stream.BaseStream is FileStream)
            {
                fileName = (stream.BaseStream as FileStream).Name;
            }
            DateTime date = DateTime.Now;
            string unit = "";
            string order = "";
            DateTime outDate = Vehicle.EmptyDate;
            using (StreamWriter sw = new StreamWriter("import.csv")) {
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    var values = line.Split(',');
                    if (values[0].StartsWith("Зведений реєстр автомобілів"))
                    {
                        DataProvider.Write(date);
                        date = DateTime.ParseExact(values[0].Replace("Зведений реєстр автомобілів", "").Trim(), "d.M.yyyy", CultureInfo.InvariantCulture);
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
                        if (values.Length > 4) {
                            var i = 4;
                            var priceStr = "";
                            while (i < values.Length) {
                                if (decimal.TryParse(values[i].Trim(), out price))
                                {
                                    priceStr += values[i].Trim();
                                    i++;
                                }
                                else
                                    break;
                            }
                            decimal.TryParse(priceStr, out price);
                            var u = values[i].Replace("в/ч ", "").Trim();
                            if (!string.IsNullOrEmpty(u))
                                unit = u;
                            var o = values[i+1].Replace("№ ", "").Trim();
                            if (!string.IsNullOrEmpty(o))
                                order = o;
                            if (DateTime.TryParseExact(values[i+2].Trim(), "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime od))
                                outDate = od;
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
                        if(fileName.Contains("update_out", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (vin != "Б/Н")
                            {
                                var v = DataProvider.Vehicles.FirstOrDefault(x => x.Vin == vin);
                                if (v != null)
                                {
                                    v.Price = price;
                                    v.Unit = unit;
                                    v.Order = order;
                                    v.OutDate = outDate;
                                    if (v.Date != vehicle.Date)
                                    {
                                        v.Date = vehicle.Date;
                                        DataProvider.Write(v);
                                    }
                                }
                                else
                                    DataProvider.Vehicles.Add(vehicle);
                            }
                        }
                        else
                        {
                            DataProvider.Vehicles.Add(vehicle);
                        }
                        sw.WriteLine("{0,15}{1,40}{2,30}{3,40}{4,25}{5,20}{6,50}{7,40}{8,30}", vehicle.Date, vehicle.Type, vehicle.Manufacturer, vehicle.Model, vehicle.Vin, vehicle.Price, vehicle.Unit, vehicle.Order, vehicle.OutDate);
                    }
                }
            }
            DataProvider.Write(date);
            DataProvider.FillCache();
        }
    }
}
