using CARDOC.Models;
using CARDOC.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDOC.Views
{
    public partial class Part : UserControl
    {
        public Part()
        {
            InitializeComponent();
        }

        private void Part_Load(object sender, EventArgs e)
        {
            boxNumber.MouseClick += new MouseEventHandler(GetMainForm().SelectAll);
            boxNotes.MouseClick += new MouseEventHandler(GetMainForm().SelectAll);
            AddSuggestions();
        }

        public string Name
        {
            get
            {
                return boxName.Text;
            }

            set
            {
                boxName.Text = value;
            }
        }

        public int Quantity
        {
            get
            {
                if(int.TryParse(boxQuantity.Text, out int quantity))
                    return quantity;
                return 1;
            }

            set
            {
                boxQuantity.Text = value.ToString();
            }
        }

        public string Units
        {
            get
            {
                return boxUnits.Text;
            }

            set
            {
                boxUnits.Text = value;
            }
        }

        public string Type
        {
            get
            {
                return boxType.Text;
            }

            set
            {
                boxType.Text = value;
            }
        }

        public string Number
        {
            get
            {
                return boxNumber.Text;
            }

            set
            {
                boxNumber.Text = value;
            }
        }

        public string Notes
        {
            get
            {
                return boxNotes.Text;
            }

            set
            {
                boxNotes.Text = value;
            }
        }

        public int Index
        {
            get { return int.Parse(lblIndex.Text.Substring(0, lblIndex.Text.Length - 1)); }
            set { lblIndex.Text = value.ToString() + "."; }
        }

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(Name);
            }
        }

        public Part Previous
        {
            get 
            {
                if (Index == 1)
                    return null;
                foreach (Part part in Parent.Controls)
                    if (part.Index == Index - 1)
                        return part;
                return null;
            }
        }

        public Part Next
        {
            get
            {
                if (Index == Parent.Controls.Count)
                    return null;
                foreach (Part part in Parent.Controls)
                    if (part.Index == Index + 1)
                        return part;
                return null;
            }
        }

        public void GetFocus()
        {
            boxName.Focus();
        }

        public bool IsLast
        {
            get
            {
                return Next == null;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Previous?.Focus();
            this.RemoveValidation();
            var i = 0;
            foreach (Part part in Parent.Controls)
                part.Index = ++i;
            Clear();
        }

        private MainForm GetMainForm()
        {
            return Parent.Parent as MainForm;
        }

        private void boxName_Validating(object sender, CancelEventArgs e)
        {
            UpdateColor();
            GetMainForm().btnSave.Enabled = boxName.Validate(boxName.Text == " " || boxName.Text == "6СТ-");
        }

        private void boxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxQuantity.HandleNumeric(e);
        }

        private void boxUnits_Validating(object sender, CancelEventArgs e)
        {
            GetMainForm().btnSave.Enabled = boxUnits.Validate(string.IsNullOrEmpty(boxUnits.Text));
        }

        private void boxType_Validating(object sender, CancelEventArgs e)
        {
            GetMainForm().btnSave.Enabled = boxType.Validate(string.IsNullOrEmpty(boxType.Text));
        }

        private async void AddNewPart(int index)
        {
            if (Next != null)
            {
            }
            else
            {
                var part = GetMainForm().AddPart();
                part.Index = index;
                GetMainForm().DoResize(false);
            }
        }

        private void boxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && (Type == PartType.Tire.GetDescription() || Type == PartType.Battery.GetDescription()))
                e.KeyChar = char.ToUpper(e.KeyChar);
            if (IsLast && !char.IsControl(e.KeyChar))
                AddNewPart(Index + 1);
            if (e.KeyChar == (char)Keys.Back && boxName.Text == "")
                btnRemove_Click(sender, e);
        }

        private void boxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLast)
                AddNewPart(Index + 1);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                if (Previous != null)
                {
                    Previous.Focus();
                }
                return true;
            }
            else if (keyData == Keys.Down)
            {
                if (Next != null)
                {
                    Next.Focus();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PopulateDragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(e);
        }

        private void PopulateMouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        public void UpdateColor()
        {
            if (boxName.Text == "")
                BackColor = SystemColors.Control;
            else if (boxType.Text == PartType.Aggregate.GetDescription())
                BackColor = Color.LightGray;
            else if (boxType.Text == PartType.Tire.GetDescription() || boxType.Text == PartType.Battery.GetDescription())
                BackColor = Color.FromArgb(179, 179, 179);
            else if (boxType.Text == PartType.Equipment.GetDescription())
                BackColor = Color.FromArgb(255, 255, 179);
            else if (boxType.Text == PartType.Zip.GetDescription())
                BackColor = Color.LightYellow;
            else
                BackColor = SystemColors.Control;
        }

        private void boxType_TextChanged(object sender, EventArgs e)
        {
            UpdateColor();
        }

        public void AddSuggestions()
        {
            boxName.AddSuggestions(DataProvider.PartNames);
            boxType.AddSuggestions(DataProvider.PartTypes);
            boxUnits.AddSuggestions(DataProvider.PartUnits);
        }

        public void Clear()
        {
            Quantity = 1;
            Units = Const.DefaultPartUnits;
            Type = PartType.Zip.GetDescription();
            Dock = DockStyle.Fill;
            Name = "";
            UpdateColor();
        }

        private void boxType_Enter(object sender, EventArgs e)
        {
            GetMainForm().SwitchLanguage(false);
        }

        public void boxName_Enter(object sender, EventArgs e)
        {
            GetMainForm().SwitchLanguage(Type == PartType.Tire.GetDescription());
        }

        private void boxNumber_Enter(object sender, EventArgs e)
        {
            GetMainForm().SwitchLanguage(true);
        }

        private void boxNotes_Enter(object sender, EventArgs e)
        {
            GetMainForm().SwitchLanguage(false);
        }

        private void boxUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void boxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void boxType_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void boxNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void boxQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        bool selectByMouse = false;
        private void boxQuantity_Enter(object sender, EventArgs e)
        {
            NumericUpDown box = sender as NumericUpDown;
            box.Select();
            box.Select(0, box.Text.Length);
            if (MouseButtons == MouseButtons.Left)
            {
                selectByMouse = true;
            }
        }

        private void boxQuantity_MouseDown(object sender, MouseEventArgs e)
        {
            NumericUpDown box = sender as NumericUpDown;
            if (selectByMouse)
            {
                box.Select(0, box.Text.Length);
                selectByMouse = false;
            }
        }

        private void Part_MouseHover(object sender, EventArgs e)
        {
        }

        private void Part_Leave(object sender, EventArgs e)
        {

        }
        private void Part_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(60, 60, 60);
        }

        private void Part_MouseLeave(object sender, EventArgs e)
        {
            UpdateColor();
        }
    }
}
