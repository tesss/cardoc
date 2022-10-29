using CARDOC.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Models
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Date { get; set; }

        /* Tech data */
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string MileageUnits { get; set; }
        public int MileageH { get; set; }
        public string Color { get; set; }
        public string Notes { get; set; }
        public List<Part> Parts { get; set; }


        public static Vehicle Empty 
        { 
            get 
            {
                return new Vehicle
                {
                    Updated = DateTime.Now,
                    Date = DateTime.Now.Date,
                    Color = Const.DefaultColor,
                    MileageUnits = Const.UnitsKm,
                    Parts = new List<Part>()
                };
            } 
        }

        public Vehicle Clone()
        {
            return JsonConvert.DeserializeObject<Vehicle>(JsonConvert.SerializeObject(this));
        }

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(Vin);
            }
        }

        public string GetTemplateName()
        {
            if (string.IsNullOrEmpty(Manufacturer) || string.IsNullOrEmpty(Model))
                return null;
            return Manufacturer + " " + Model;
        }
    }
}
