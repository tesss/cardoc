using CARDOC.Views;
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
    public static class Extensions
    {

        public static void HandleNumeric(this Control control, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private static HashSet<string> InvalidControls = new HashSet<string>();

        public static bool RemoveValidation(this Control control)
        {
            InvalidControls.RemoveWhere(x => x.StartsWith(control.Parent.GetFullName()));
            return !InvalidControls.Any();
        }
        public static bool Validate(this Control control, bool err, bool skipValidation = false)
        {
            if (err)
            {
                control.BackColor = Color.FromArgb(255, 180, 128);
                if (!skipValidation)
                    InvalidControls.Add(control.GetFullName());
            }
            else
            {
                control.BackColor = SystemColors.Window;
                if (!skipValidation)
                    InvalidControls.Remove(control.GetFullName());
            }
            return !InvalidControls.Any();
        }
        public static bool ValidateVin(string vin)
        {
            if (vin.Length != 17)
                return false;
            var result = 0;
            var index = 0;
            var checkDigit = 0;
            var checkSum = 0;
            var weight = 0;
            foreach (var c in vin.ToCharArray())
            {
                index++;
                var character = c.ToString().ToLower();
                if (char.IsNumber(c))
                    result = int.Parse(character);
                else
                {
                    switch (character)
                    {
                        case "a":
                        case "j":
                            result = 1;
                            break;
                        case "b":
                        case "k":
                        case "s":
                            result = 2;
                            break;
                        case "c":
                        case "l":
                        case "t":
                            result = 3;
                            break;
                        case "d":
                        case "m":
                        case "u":
                            result = 4;
                            break;
                        case "e":
                        case "n":
                        case "v":
                            result = 5;
                            break;
                        case "f":
                        case "w":
                            result = 6;
                            break;
                        case "g":
                        case "p":
                        case "x":
                            result = 7;
                            break;
                        case "h":
                        case "y":
                            result = 8;
                            break;
                        case "r":
                        case "z":
                            result = 9;
                            break;
                    }
                }

                if (index >= 1 && index <= 7 || index == 9)
                    weight = 9 - index;
                else if (index == 8)
                    weight = 10;
                else if (index >= 10 && index <= 17)
                    weight = 19 - index;
                if (index == 9)
                    checkDigit = character == "x" ? 10 : result;
                checkSum += (result * weight);
            }

            return checkSum % 11 == checkDigit;
        }

        public static string GetFullName(this Control control)
        {
            if (control.Parent == null) return control.Name;
            return control.Parent.GetFullName() + "." + control.Name;
        }

        private static void ClearSuggestions(this CustomComboBox comboBox)
        {
            comboBox.AutoCompleteCustomSource.Clear();
            comboBox.Items.Clear();
        }

        public static void AddSuggestions(this CustomComboBox comboBox, string[] strings, bool force = false)
        {
            if (strings == null)
            {
                comboBox.ClearSuggestions();
                return;
            }
            if (!force && comboBox.Items.Count == strings.Length)
                return;
            comboBox.ClearSuggestions();
            var res = new AutoCompleteStringCollection();
            res.AddRange(strings);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(strings);
        }

        public static void AddSuggestions(this CustomComboBox comboBox, SortedSet<string> strings, bool force = false)
        {
            if(strings == null)
            {
                comboBox.ClearSuggestions();
                return;
            }
            if (strings == null || !force && comboBox.Items.Count == strings.Count)
                return;
            comboBox.ClearSuggestions();
            var data = strings.ToArray();
            var res = new AutoCompleteStringCollection();
            res.AddRange(data);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(data);
        }

        public static void AddSuggestions(this CustomComboBox comboBox, Dictionary<string, SortedSet<string>> strings, bool force = false)
        {
            if (strings == null)
            {
                comboBox.ClearSuggestions();
                return;
            }
            if (strings == null || !force && comboBox.Items.Count == strings.Count)
                return;
            comboBox.ClearSuggestions();
            var data = strings.Keys.ToArray();
            var res = new AutoCompleteStringCollection();
            res.AddRange(data);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(data);
        }

        public static string RemoveInvalidChars(this string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static string ToFirstUpperCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return char.ToUpper(str.First()) + str.Substring(1);
        }

        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }

        public static SortedSet<T> ToSortedSet<T>(this IEnumerable<T> t)
        {
            SortedSet<T> retval = new SortedSet<T>();

            t.ToList().ForEach(x => retval.Add(x));

            return retval;
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
    }
}
