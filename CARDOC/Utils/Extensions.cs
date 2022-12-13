using CARDOC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDOC.Utils
{
    public static partial class Extensions
    {

        public static void HandleNumeric(this Control control, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void HandlePrice(this Control control, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
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
        public static bool Validate(this Control control, bool err, bool skipValidation = false, bool warning = false)
        {
            if (err)
            {
                control.BackColor = Color.FromArgb(255, 180, 128);
                if (!skipValidation)
                    InvalidControls.Add(control.GetFullName());
            }
            else if(warning)
            {
                control.BackColor = Color.FromArgb(255, 255, 179);
            }
            else
            {
                control.BackColor = SystemColors.Window;
                if (!skipValidation)
                    InvalidControls.Remove(control.GetFullName());
            }
            return !InvalidControls.Any();
        }
        public static bool ValidateVinByControlChar(string vin)
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
        public static bool ValidateVin(string vin)
        {
            return Regex.IsMatch(vin, "[A-HJ-NPR-Z0-9]{13}[0-9]{4}");
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
            var text = comboBox.Text;
            comboBox.ClearSuggestions();
            var res = new AutoCompleteStringCollection();
            res.AddRange(strings);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(strings);
            if (comboBox.Text != text)
                comboBox.Text = text;
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
            var text = comboBox.Text;
            comboBox.ClearSuggestions();
            var data = strings.ToArray();
            var res = new AutoCompleteStringCollection();
            res.AddRange(data);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(data);
            if(comboBox.Text != text)
                comboBox.Text = text;
        }

        public static void AddSuggestions(this CustomComboBox comboBox, SortedDictionary<string, SortedSet<string>> strings, bool force = false)
        {
            if (strings == null)
            {
                comboBox.ClearSuggestions();
                return;
            }
            if (strings == null || !force && comboBox.Items.Count == strings.Count)
                return;
            var text = comboBox.Text;
            comboBox.ClearSuggestions();
            var data = strings.Keys.ToArray();
            var res = new AutoCompleteStringCollection();
            res.AddRange(data);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(data);
            if (comboBox.Text != text)
                comboBox.Text = text;
        }

        public static string RemoveInvalidChars(this string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static string ToFirstLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return char.ToLower(str.First()) + str.Substring(1);
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
    }
}
