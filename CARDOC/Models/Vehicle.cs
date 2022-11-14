using CARDOC.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public bool Medical { get; set; }
        public bool Rao { get; set; }
        public bool Сommunication { get; set; }
        public List<Part> Parts { get; set; }

        /* out fields */
        public string Act { get; set; }
        public string Nom { get; set; }
        public string Order { get; set; }
        public string Mou { get; set; }
        public string Unit { get; set; }
        public DateTime OutDate { get; set; }
        public decimal Price { get; set; }

        public static Vehicle Empty 
        { 
            get 
            {
                return new Vehicle
                {
                    Updated = DateTime.Now,
                    Date = DateTime.Now.Date,
                    OutDate = DateTime.Now.Date,
                    MileageUnits = Const.UnitsKm,
                    Parts = new List<Part>
                    {
                        new Part { Name = "Кузов", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = "Двигун", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = "Передній міст", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = "Коробка передач", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = "Задній міст", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = "Роздавальна коробка", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = "Кермовий механізм", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Aggregate.GetDescription() },
                        new Part { Name = " ", Quantity = 4, Units = Const.DefaultPartUnits, Type = PartType.Tire.GetDescription() },
                        new Part { Name = "6СТ-", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Battery.GetDescription() },
                        new Part { Name = "Тягово-зчипний пристрій", Quantity = 1, Units = Const.DefaultPartUnits, Type = PartType.Equipment.GetDescription() }
                    }
                };
            } 
        }

        [JsonIgnore]
        public string TemplateName
        {
            get
            {
                if (string.IsNullOrEmpty(Manufacturer) || string.IsNullOrEmpty(Model))
                    return null;
                return (Manufacturer.ToUpper() + " " + Model.ToUpper()).RemoveInvalidChars();
            }
        }

        public bool Equals(Vehicle? other)
        {
            other = other.Clone();
            other.Updated = Updated;
            return JsonHelper.SerialiseAlphabeticaly(this) == JsonHelper.SerialiseAlphabeticaly(other);
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

        [JsonIgnore]
        public string ExportFolder
        {
            get
            {
                return string.Format("{0}/{1} {2}", Const.ExportFolder, Date.ToString(Const.DateFormat), this.TemplateName);
            }
        }
    }
}
