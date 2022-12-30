using CARDOC.Models;
using CARDOC.Views;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDOC.Utils
{
    public static partial class Extensions
    {
        public static string SerializeForFilter(this Vehicle vehicle)
        {
            return string.Concat(vehicle.Vin, vehicle.Manufacturer, " ", vehicle.Model, vehicle.Type, vehicle.Date.ToString(Const.DateShortFormat), vehicle.OutDate.ToString(Const.DateShortFormat),
                vehicle.Year.ToString(), vehicle.Color, vehicle.Notes, vehicle.Act, vehicle.ActIn, vehicle.Nom, vehicle.Order, vehicle.Mou, vehicle.Unit, vehicle.Category);
        }
        public static IOrderedEnumerable<Vehicle> OrderVehicles(this IEnumerable<Vehicle> input)
        {
            return input.OrderByDescending(x => x.Date).ThenByDescending(x => x.TemplateName).ThenByDescending(x => x.Vin);
        }
        public static IEnumerable<int> GetDigits(this decimal s)
        {
            Int64 source = (Int64)s;
            Int64 individualFactor = 0;
            var tennerFactor = Convert.ToInt64(Math.Pow(10, source.ToString().Length));
            do
            {
                source -= tennerFactor * individualFactor;
                tennerFactor /= 10;
                individualFactor = source / tennerFactor;

                yield return (int)individualFactor;
            } while (tennerFactor > 1);
        }

        public static string ToText(this int number, int gender = 0)
        {
            return Convert.ToInt64(number).ToText(gender);
        }

        public static string ToText(this Int64 number, int gender = 0)
        {
            if (number < 0)
                return number.ToString();
            if (number == 0)
                return "нуль";
            var str = "";
            var digits = ((decimal)number).GetDigits().ToArray();
            Func<int[], int, string> getWord = (digits, length) =>
            {
                var word = "";
                var i = digits.Length - length + 1;
                var j = i + 1;
                if (i > 0 && digits[i] == 1)
                {
                    if (length == 6)
                        word = " тисяч ";
                    else if (length == 9)
                        word = " мільйонів ";
                    else if (length == 12)
                        word = " мільярдів ";
                }
                else if (digits[j] == 1)
                {
                    if (length == 6)
                        word = " тисяча ";
                    else if (length == 9)
                        word = " мільйон ";
                    else if (length == 12)
                        word = " мільярд ";
                }
                else if (digits[j] >= 2 && digits[j] <= 4)
                {
                    if (length == 6)
                        word = " тисячі ";
                    else if (length == 9)
                        word = " мільйони ";
                    else if (length == 12)
                        word = " мільярди ";
                }
                else if (digits[j] >= 2 && digits[j] <= 4)
                {
                    if (length == 6)
                        word = " тисячі ";
                    else if (length == 9)
                        word = " мільйони ";
                    else if (length == 12)
                        word = " мільярди ";
                }
                else if (digits[j] >= 5)
                {
                    if (length == 6)
                        word = " тисяч ";
                    else if (length == 9)
                        word = " мільйонів ";
                    else if (length == 12)
                        word = " мільярдів ";
                }
                return word;
            };
            Func<int, int, string> r1 = (n, gender) =>
            {
                if (n == 0)
                    return "";
                if (n == 1)
                {
                    if (gender == 0)
                        return "одне";
                    if (gender == 1)
                        return "один";
                    if (gender == 2)
                        return "один";
                }
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
            Func<int, int, int, string> r2 = (n1, n2, gender) =>
            {
                if (n1 == 0)
                    return r1(n2, gender);
                if (n1 == 1)
                {
                    if (n2 == 0)
                        return "десять";
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
                }
                else
                {
                    if (n1 == 2)
                        return "двадцять " + r1(n2, gender);
                    if (n1 == 3)
                        return "тридцять " + r1(n2, gender);
                    if (n1 == 4)
                        return "сорок " + r1(n2, gender);
                    if (n1 == 5)
                        return "п'ятдесят " + r1(n2, gender);
                    if (n1 == 6)
                        return "шістдесят " + r1(n2, gender);
                    if (n1 == 7)
                        return "сімдесят " + r1(n2, gender);
                    if (n1 == 8)
                        return "вісімдесят " + r1(n2, gender);
                    if (n1 == 9)
                        return "дев'яносто " + r1(n2, gender);
                }

                return "";
            };
            Func<int, int, int, int, string> r3 = (n1, n2, n3, gender) =>
            {
                if (n1 == 1)
                    return "сто " + r2(n2, n3, gender);
                if (n1 == 2)
                    return "двісті " + r2(n2, n3, gender);
                if (n1 == 3)
                    return "триста " + r2(n2, n3, gender);
                if (n1 == 4)
                    return "чотириста " + r2(n2, n3, gender);
                if (n1 == 5)
                    return "п'ятсот " + r2(n2, n3, gender);
                if (n1 == 6)
                    return "шістсот " + r2(n2, n3, gender);
                if (n1 == 7)
                    return "сімсот " + r2(n2, n3, gender);
                if (n1 == 8)
                    return "вісімсот " + r2(n2, n3, gender);
                if (n1 == 9)
                    return "дев'ятсот " + r2(n2, n3, gender);
                return "";
            };
            Func<int[], int, string> r4_6 = (digits, gender) =>
            {
                var thousand = getWord(digits, 6);
                if (digits.Length == 4)
                    return r1(digits[0], 2) + thousand + r3(digits[1], digits[2], digits[3], gender);
                if (digits.Length == 5)
                    return r2(digits[0], digits[1], 2) + thousand + r3(digits[2], digits[3], digits[4], gender);
                if (digits.Length == 6)
                    return r3(digits[0], digits[1], digits[2], 2) + thousand + r3(digits[3], digits[4], digits[5], gender);
                return "";
            };
            Func<int[], int, string> r7_9 = (digits, gender) =>
            {
                var million = getWord(digits, 9);
                if (digits.Length == 7)
                    return r1(digits[0], 1) + million + r4_6(digits.Skip(1).Take(6).ToArray(), gender);
                if (digits.Length == 8)
                    return r2(digits[0], digits[1], 2) + million + r4_6(digits.Skip(2).Take(6).ToArray(), gender);
                if (digits.Length == 9)
                    return r3(digits[0], digits[1], digits[2], 1) + million + r4_6(digits.Skip(2).Take(6).ToArray(), gender);
                return "";
            };
            Func<int[], int, string> r10_12 = (digits, gender) =>
            {
                var billion = getWord(digits, 12);
                if (digits.Length == 10)
                    return r1(digits[0], 1) + billion + r7_9(digits.Skip(1).Take(9).ToArray(), gender);
                if (digits.Length == 11)
                    return r2(digits[0], digits[1], 1) + billion + r7_9(digits.Skip(2).Take(9).ToArray(), gender);
                if (digits.Length == 12)
                    return r3(digits[0], digits[1], digits[2], 1) + billion + r7_9(digits.Skip(2).Take(9).ToArray(), gender);
                return "";
            };
            if (digits.Length == 1)
                return r1(digits[0], gender).Trim();
            if (digits.Length == 2)
                return r2(digits[0], digits[1], gender).Trim();
            if (digits.Length == 3)
                return r3(digits[0], digits[1], digits[2], gender).Trim();
            if (digits.Length > 3 && digits.Length <= 6)
                return r4_6(digits, gender);
            if (digits.Length > 6 && digits.Length <= 9)
                return r7_9(digits, gender);
            if (digits.Length > 9 && digits.Length <= 12)
                return r10_12(digits, gender);
            return number.ToString();
        }

        public static string ToPrice(this decimal number)
        {
            var uah = Math.Truncate(number);
            var digits = uah.GetDigits().ToArray();
            var str = Convert.ToInt64(uah).ToText(2);
            var last = digits.Last();
            if (last == 0 || digits[digits.Count() - 1] == 1)
                str += " гривень ";
            if (last == 1)
                str += " гривня ";
            if (last > 1 && last <= 4)
                str += " гривні ";
            if (last > 4)
                str += " гривень ";
            var cop = Convert.ToDecimal((number - uah) * 100);
            digits = cop.GetDigits().ToArray();
            str += Convert.ToInt64(cop).ToText(2) + " ";
            last = digits.Last();
            if (last == 0 || digits[digits.Count() - 1] == 1)
                str += " копійок";
            if (last == 1)
                str += " копійка";
            if (last > 1 && last <= 4)
                str += " копійки";
            if (last > 4)
                str += " копійок";
            return str;
        }

        public static string Titles(this int number)
        {
            var digits = Convert.ToDecimal(number).GetDigits().ToArray();
            if (digits.Length >= 2 && digits[digits.Length - 2] == 1)
                return "найменувань";
            switch (digits[digits.Length - 1])
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
            var zip = vehicle.Parts.Where(x => x.PartType == PartType.Zip && x.Quantity > 0).ToList();
            if (columns)
                if (zip.Count > 0 && zip.Count % 2 == 1)
                    zip.Add(new Models.Part());
            return zip;
        }

        public static List<Models.Part> GetAggregates(this Vehicle vehicle)
        {
            return vehicle.Parts.Where(x => x.PartType == PartType.Aggregate && x.Quantity > 0).ToList();
        }

        public static List<Models.Part> GetEquipmentAndZip(this Vehicle vehicle)
        {
            var parts = vehicle.Parts.Where(x => x.PartType == PartType.Equipment).ToList();
            parts.AddRange(vehicle.Parts.Where(x => x.PartType == PartType.EquipmentCargo).ToList());
            parts.Add(new Models.Part());
            parts.Add(new Models.Part());
            parts.Add(new Models.Part());
            parts.AddRange(vehicle.Parts.Where(x => x.PartType == PartType.Zip).ToList());
            return parts;
        }

        public static List<Models.Part> GetTires(this Vehicle vehicle)
        {
            return vehicle.Parts.Where(x => x.PartType == PartType.Tire && x.Quantity > 0).ToList();
        }

        public static string GetBatteries(this Vehicle vehicle)
        {
            var str = "";
            foreach (var battery in vehicle.Parts.Where(x => x.PartType == PartType.Battery && x.Quantity > 0))
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
            foreach (var equipment in vehicle.Parts.Where(x => x.PartType == PartType.Equipment && x.Quantity > 0))
                str += equipment.Name.ToFirstLowerCase() + (!string.IsNullOrEmpty(equipment.Notes) ? " - " + equipment.Notes : "") + ", ";
            if (str.Length > 0)
                str = str.Substring(0, str.Length - 2);
            return str;
        }
        public static List<CARDOC.Models.Part> GetEquipmentCargo(this Vehicle vehicle, bool columns = false)
        {
            var zip = vehicle.Parts.Where(x => x.PartType == PartType.EquipmentCargo && x.Quantity > 0).ToList();
            if (columns)
                if (zip.Count > 0 && zip.Count % 2 == 1)
                    zip.Add(new Models.Part());
            return zip;
        }

        public static int GetCategory(this Vehicle vehicle)
        {
            if (vehicle.Category > 0)
                return vehicle.Category;
            if (DateTime.Now.Year > 0 && DateTime.Now.Year - vehicle.Year <= 3 && (vehicle.Mileage > 0 && (vehicle.Mileage <= 3000 && vehicle.MileageUnits == Const.UnitsKm || vehicle.MileageH <= 1864 && vehicle.MileageUnits == Const.UnitsMiles)))
                return 1;
            return 2;
        }

        public static string GetMileage(this Vehicle vehicle)
        {
            var str = vehicle.Mileage == 0 ? "" : vehicle.Mileage + " " + vehicle.MileageUnits;
            if (vehicle.MileageH > 0)
                str += "; " + vehicle.MileageH + " " + Const.UnitsHours;
            return str;
        }

        public static string GetYear(this Vehicle vehicle, bool withUnit = false)
        {
            return vehicle.Year > 0 ? vehicle.Year.ToString() + (withUnit ? " рік" : "") : "";
        }

        public static string GetAddons(this Vehicle vehicle)
        {
            if (vehicle.Medical || vehicle.Сommunication || vehicle.Rao)
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

        public static string GetNotes(this Vehicle vehicle)
        {
            if (string.IsNullOrEmpty(vehicle.Notes))
                return "прибув без документів";
            return vehicle.Notes.ToFirstLowerCase();
        }

        public static string GetMonth(this DateTime date)
        {
            if (date.Month == 1)
                return "січня";
            if (date.Month == 2)
                return "лютого";
            if (date.Month == 3)
                return "березня";
            if (date.Month == 4)
                return "квітня";
            if (date.Month == 5)
                return "травня";
            if (date.Month == 6)
                return "червня";
            if (date.Month == 7)
                return "липня";
            if (date.Month == 8)
                return "серпня";
            if (date.Month == 9)
                return "вересня";
            if (date.Month == 10)
                return "жовтня";
            if (date.Month == 11)
                return "листопада";
            if (date.Month == 12)
                return "грудня";
            return "";
        }

        public static string GetReceiver(this Vehicle vehicle, bool shortVersion = false)
        {
            if (vehicle.Type == "Автомобіль вантажний" ||
                vehicle.Type == "Контейнеровоз" ||
                vehicle.Type == "Напівпричеп" ||
                vehicle.Type == "Самоскид" ||
                vehicle.Type == "Сідельний тягач")
                return shortVersion ? "сержант                 Ігор СТРУК" :
                                      "сержант                                                                                               Ігор СТРУК";
            return     shortVersion ? "штаб сержант     Олександр ОЛІЙНИК" :
                                      "штаб сержант                                                                                   Олександр ОЛІЙНИК";
        }

        public static string GetCurrency(this Vehicle vehicle)
        {
            if (vehicle.PriceUSD > 0)
                return string.Format("${0:N}", vehicle.PriceUSD);
            if (vehicle.PriceEUR > 0)
                return string.Format("€{0:N}", vehicle.PriceUSD);
            return "";
        }

        public static string GetOrder(this Vehicle vehicle)
        {
            var str = "";
            if (!string.IsNullOrEmpty(vehicle.Order))
                str += "№" + vehicle.Order;
            if (!string.IsNullOrEmpty(vehicle.Unit))
                str += "\n" + vehicle.Unit;
            return str.Trim();
        }

        public static decimal GetPrimaryPrice(this Vehicle vehicle)
        {
            return vehicle.Price * vehicle.Ki;
        }

        public static decimal GetEndPrice(this Vehicle vehicle)
        {
            return vehicle.Price * vehicle.Ki * vehicle.GetWearCoef();
        }

        public static decimal GetMileageCoef(this Vehicle vehicle)
        {
            if (vehicle.Mileage > 0)
            {
                if (vehicle.MileageUnits == Const.UnitsKm)
                    return Math.Round((decimal)vehicle.Mileage / 1000, 2);
                if (vehicle.MileageUnits == Const.UnitsMiles)
                    return Math.Round((decimal)(vehicle.Mileage * 1.6) / 1000, 2);
            }
            return 0;
        }

        public static decimal GetWearCoef(this Vehicle vehicle)
        {
            return 1 - (vehicle.H1 * vehicle.GetMileageCoef() + vehicle.H2 * (DateTime.Now.Year - vehicle.Year)) / 100;
        }

        public static decimal GetWear(this Vehicle vehicle)
        {
            return vehicle.Price * vehicle.Ki * (1 - vehicle.GetWearCoef());
        }

        public static string Format(this decimal value)
        {
            return string.Format("{0:N}", Math.Round(value, 2));
        }
    }
}
