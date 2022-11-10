using CARDOC.Models;
using CARDOC.Views;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDOC.Utils
{
    public static partial class Extensions
    {
        public static string GetTemplateName(this Vehicle vehicle)
        {
            if (string.IsNullOrEmpty(vehicle.Manufacturer) || string.IsNullOrEmpty(vehicle.Model))
                return null;
            return (vehicle.Manufacturer.ToUpper() + " " + vehicle.Model.ToUpper()).RemoveInvalidChars();
        }
        
        public static IEnumerable<int> GetDigits(this int source)
        {
            int individualFactor = 0;
            int tennerFactor = Convert.ToInt32(Math.Pow(10, source.ToString().Length));
            do
            {
                source -= tennerFactor * individualFactor;
                tennerFactor /= 10;
                individualFactor = source / tennerFactor;

                yield return individualFactor;
            } while (tennerFactor > 1);
        }

        public static string ToText(this int number)
        {
            if (number < 0 || number > 1000)
                return number.ToString();
            if (number == 0)
                return "нуль";
            var str = "";
            var digits = number.GetDigits().ToArray();
            Func<int, string> r1 = (n) =>
            {
                if(n == 0)
                    return "";
                if (n == 1)
                    return "одне";
                if (n == 2)
                    return "два";
                if (n == 3)
                    return "три";
                if (n == 4)
                    return "чотири";
                if (n == 5)
                    return "п'ять";
                if (n == 6)
                    return "шість";
                if (n == 7)
                    return "сім";
                if (n == 8)
                    return "вісім";
                if (n == 9)
                    return "дев'ять";
                return "";
            };
            Func<int, int, string> r2 = (n1, n2) =>
            {
                if (n1 == 0)
                    return r1(n2);
                if (n1 == 1)
                {
                    if (n2 == 1)
                        return "одинадцять";
                    if (n2 == 2)
                        return "дванадцять";
                    if (n2 == 3)
                        return "тринадцять";
                    if (n2 == 4)
                        return "чотирнадцять";
                    if (n2 == 5)
                        return "п'ятнадцять";
                    if (n2 == 6)
                        return "шістнадцять";
                    if (n2 == 7)
                        return "сімнадцять";
                    if (n2 == 8)
                        return "вісімнадцять";
                    if (n2 == 9)
                        return "дев'ятнадцять";
                } else
                {
                    if (n1 == 2)
                        return "двадцять " + r1(n2);
                    if (n1 == 3)
                        return "тридцять " + r1(n2);
                    if (n1 == 4)
                        return "сорок " + r1(n2);
                    if (n1 == 5)
                        return "п'ятдесят " + r1(n2);
                    if (n1 == 6)
                        return "шістдесят " + r1(n2);
                    if (n1 == 7)
                        return "сімдесят " + r1(n2);
                    if (n1 == 8)
                        return "вісімдесят " + r1(n2);
                    if (n1 == 9)
                        return "дев'яносто " + r1(n2);
                }
                
                return "";
            };
            Func<int, int, int, string> r3 = (n1, n2, n3) =>
            {
                if (n1 == 1)
                    return "сто " + r2(n2, n3);
                if (n1 == 2)
                    return "двісті " + r2(n2, n3);
                if (n1 == 3)
                    return "триста " + r2(n2, n3);
                if (n1 == 4)
                    return "чотириста " + r2(n2, n3);
                if (n1 == 5)
                    return "п'ятсот " + r2(n2, n3);
                if (n1 == 6)
                    return "шістсот " + r2(n2, n3);
                if (n1 == 7)
                    return "сімсот " + r2(n2, n3);
                if (n1 == 8)
                    return "вісімсот " + r2(n2, n3);
                if (n1 == 9)
                    return "дев'ятсот " + r2(n2, n3);
                return "";
            };
            if (digits.Length == 1)
                return r1(digits[0]).Trim();
            if(digits.Length == 2)
                return r2(digits[0], digits[1]).Trim();
            if (digits.Length == 3)
                return r3(digits[0], digits[1], digits[2]).Trim();
            return number.ToString();
        }

        public static string Titles(this int number)
        {
            var digits = number.GetDigits().ToArray();
            if (digits.Length >= 2 && digits[digits.Length - 2] == 1)
                return "найменувань";
            switch (digits[digits[digits.Length - 1]])
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return "найменування";
                case 0:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return "найменувань";
                    break;
            }
            return "найменувань";
        }

        public static List<Models.Part> GetZip(this Vehicle vehicle, bool columns = false)
        {
            var zip = vehicle.Parts.Where(x => x.PartType == PartType.Zip).ToList();
            if (columns)
                if (zip.Count > 0 && zip.Count % 2 == 1)
                    zip.Add(new Models.Part());
            return zip;
        }

        public static List<Models.Part> GetAggregates(this Vehicle vehicle)
        {
            return vehicle.Parts.Where(x => x.PartType == PartType.Aggregate).ToList();
        }

        public static Models.Part GetTires(this Vehicle vehicle)
        {
            return vehicle.Parts.FirstOrDefault(x => x.PartType == PartType.Tire) ??
                new Models.Part()
                {
                    PartType = PartType.Tire,
                    Name = "",
                    Quantity = 4
                };
        }

        public static string GetBatteries(this Vehicle vehicle)
        {
            var str = "";
            foreach (var battery in vehicle.Parts.Where(x => x.PartType == PartType.Battery))
            {
                str += battery.Name + " - " + battery.Quantity + " " + battery.Units + "., ";
                if (!string.IsNullOrEmpty(battery.Notes))
                    str += battery.Notes + ", ";
            }
            return str;
        }

        public static string GetEquipment(this Vehicle vehicle)
        {
            var str = "";
            foreach (var equipment in vehicle.Parts.Where(x => x.PartType == PartType.Equipment))
                str += equipment.Name.ToLower() + ", ";
            if(str.Length > 0)
                str = str.Substring(0, str.Length - 2);
            return str;
        }

        public static int GetCategory(this Vehicle vehicle)
        {
            if (DateTime.Now.Year > 0 && DateTime.Now.Year - vehicle.Year <= 3 && (vehicle.Mileage > 0 && vehicle.Mileage <= 3000 || vehicle.MileageH > 0 && vehicle.MileageH <= 1864))
                return 1;
            return 2;
        }

        public static string GetMileage(this Vehicle vehicle)
        {
            var str = vehicle.Mileage + " " + vehicle.MileageUnits;
            if (vehicle.MileageH > 0)
                str += "; " + vehicle.MileageH + " " + Const.UnitsHours;
            return str;
        }

        public static string GetAddons(this Vehicle vehicle)
        {
            if(vehicle.Medical || vehicle.Сommunication || vehicle.Rao)
            {
                var str = "Додається: ";
                if (vehicle.Medical)
                    str += "опис медичного майна, ";
                if (vehicle.Сommunication)
                    str += "опис засобів зв'язку, ";
                if (vehicle.Rao)
                    str += "опис майна по службі РАО, ";
                str = str.Substring(0, str.Length - 2);
                str += ".";
                return str;
            }
            return "";
        }

        public static string GetNotes(this Models.Part part, Vehicle vehicle)
        {
            if (part.Name == "Кузов" && !string.IsNullOrEmpty(vehicle.Color))
            {
                var colorNotes = "колір " + vehicle.Color;
                if (!string.IsNullOrEmpty(part.Notes))
                    return colorNotes + ", " + part.Notes + ", ";
                else
                    return colorNotes + ", ";
            }
            if (string.IsNullOrEmpty(part.Notes))
                return "";
            return part.Notes + ", ";
        }
    }
}
