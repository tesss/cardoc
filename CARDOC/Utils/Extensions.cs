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
