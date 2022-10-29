﻿using CARDOC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void AddSuggestions(this CustomComboBox comboBox, string[] strings)
        {
            comboBox.ClearSuggestions();
            var res = new AutoCompleteStringCollection();
            res.AddRange(strings);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(strings);
        }

        public static void AddSuggestions(this CustomComboBox comboBox, HashSet<string> strings)
        {
            comboBox.ClearSuggestions();
            if (strings == null)
                return;
            var data = strings.ToArray();
            var res = new AutoCompleteStringCollection();
            res.AddRange(data);
            comboBox.AutoCompleteCustomSource = res;
            comboBox.Items.AddRange(data);
        }

        public static void AddSuggestions(this CustomComboBox comboBox, Dictionary<string, HashSet<string>> strings)
        {
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
    }
}