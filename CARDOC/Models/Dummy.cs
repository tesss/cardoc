using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Models
{
    internal class Dummy
    {
        public static List<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle
            {
                Type = "Бортовий вантажний автомобіль",
                Vin = "ZCFD4098009036791",
                Manufacturer = "IVECO",
                Model = "SPA,40E13 W/M",
                Date = DateTime.Now,
                Year = 2021,
                Mileage = 30195,
                MileageUnits = "км",
                Color = "Зелений",
                Parts = new List<Part>
                {
                    new Part
                    {
                        Name = "Переговорний пристрій",
                        Type = "ЗІП",
                        Units = "шт",
                        Quantity = 1
                    },
                    new Part
                    {
                        Name = "12 В 6CT-95Ah",
                        Type = "АКБ",
                        Units = "шт",
                        Quantity = 4
                    },
                    new Part
                    {
                        Name = "Автошини 255/100R16",
                        Type = "Шини",
                        Units = "шт",
                        Quantity = 5
                    }
                }
            });
            return vehicles;
        }
    }
}
