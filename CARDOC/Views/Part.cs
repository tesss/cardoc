using CARDOC.Models;
using CARDOC.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Index = Parent.Controls.IndexOf(this) + 1;
            boxName.AddSuggestions(DataProvider.PartNames);
            boxType.AddSuggestions(DataProvider.PartTypes);
            boxUnits.AddSuggestions(DataProvider.PartUnits);
        }

        public string Name
        {
            get
            {
                return this.boxName.Text;
            }

            set
            {
                this.boxName.Text = value;
            }
        }

        public int Quantity
        {
            get
            {
                return int.Parse(this.boxQuantity.Text);
            }

            set
            {
                this.boxQuantity.Text = value.ToString();
            }
        }

        public string Units
        {
            get
            {
                return this.boxUnits.Text;
            }

            set
            {
                this.boxUnits.Text = value;
            }
        }

        public string Type
        {
            get
            {
                return this.boxType.Text;
            }

            set
            {
                this.boxType.Text = value;
            }
        }

        public string Notes
        {
            get
            {
                return this.boxNotes.Text;
            }

            set
            {
                this.boxNotes.Text = value;
            }
        }

        public int Index
        {
            get { return int.Parse(lblIndex.Text.Substring(0, lblIndex.Text.Length - 1)); }
            set { lblIndex.Text = value.ToString() + "."; }
        }

        public Part Previous
        {
            get 
            {
                if (Index == 1)
                    return null;
                foreach (Part part in Parent.Controls)
                    if (part.Index == Index - 1 && part.Visible)
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
                    if (part.Index == Index + 1 && part.Visible)
                        return part;
                return null;
            }
        }

        public Part NextActual
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
                return Next == null || !Next.Visible;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(!IsLast)
            {
                Previous?.Focus();
                this.RemoveValidation();
                foreach (Part part in Parent.Controls)
                    if (part.Index > Index)
                        part.Index--;
                this.Clear();
            }
        }

        private MainForm GetMainForm()
        {
            return Parent.Parent as MainForm;
        }

        private void boxName_Validating(object sender, CancelEventArgs e)
        {
            if (!IsLast)
                GetMainForm().btnSave.Enabled = boxName.Validate(string.IsNullOrEmpty(boxName.Text));
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

        private void boxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsLast && !char.IsControl(e.KeyChar) && NextActual != null)
                NextActual.Visible = true;
            if (e.KeyChar == (char)Keys.Back && boxName.Text == "")
                btnRemove_Click(sender, e);
        }

        private void boxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLast && NextActual != null)
                NextActual.Visible = true;
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
                    Next.Focus();
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

        private void boxType_TextChanged(object sender, EventArgs e)
        {
            switch (boxType.Text)
            {
                case Const.PartTypeGeneral:
                case Const.PartTypeTire:
                case Const.PartTypeBattery:
                    BackColor = Color.LightYellow;
                    break;
                default:
                    BackColor = SystemColors.Window;
                    break;
            }
        }

        public void Clear()
        {
            Quantity = 1;
            Units = Const.DefaultPartUnits;
            Type = Const.PartTypeZip;
            Dock = DockStyle.Fill;
            Name = "";
            if(Visible)
                Visible = false;
        }
    }
}
