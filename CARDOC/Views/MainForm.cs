using CARDOC.Models;
using CARDOC.Utils;
using CARDOC.Views;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Part = CARDOC.Views.Part;

namespace CARDOC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitUI(bool first)
        {
            listHistory.Clear();
            listHistory.Columns.Add("✔", 50);
            listHistory.Columns.Add("Дата", 200);
            listHistory.Columns.Add("Виробник", 150);
            listHistory.Columns.Add("Модель", 300);
            listHistory.Columns.Add("Vin", 200);
            listHistory.Columns.Add("Рік", 100);
            listHistory.Columns.Add("Пробіг", 100);
            foreach (var vehicle in DataProvider.Vehicles)
            {
                ListViewItem lvi = new ListViewItem{ Checked = false };
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Дата") { Text = vehicle.Date.ToString(Const.DateFormat) });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Виробник") { Text = vehicle.Manufacturer });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Модель"){ Text = vehicle.Model });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Vin") { Text = vehicle.Vin });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Рік") { Text = vehicle.Year.ToString() });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Пробіг") { Text = vehicle.Mileage + vehicle.MileageUnits });
                listHistory.Items.Add(lvi);
            }
            if (first)
            {
                boxFilterDate.CustomFormat = boxDate.CustomFormat = "dd.MM.yy";
                var start = 1970;
                boxYear.AddSuggestions(Enumerable.Range(start, DateTime.Now.Year - start + 1).Select(x => x.ToString()).ToArray());
                for (var i = 0; i < 100; i++)
                    AddPart();
                    if (listHistory.Items.Count > 0)
                {
                    listHistory.Items[0].Selected = true;
                    listHistory.Select();
                }
                else
                    InitVehicleUI(Vehicle.Empty);
            }
            boxDate.MaxDate = boxFilterDate.MaxDate = DateTime.Today.Date.AddDays(1);
            boxType.AddSuggestions(DataProvider.Types);
            boxManufacturer.AddSuggestions(DataProvider.Models);
            boxColor.AddSuggestions(DataProvider.Colors);
        }

        private Part GetPartView(int index)
        {
            return panelParts.Controls[index] as Part;
        }

        private void InitVehicleUI(Vehicle vehicle)
        {
            boxManufacturer.Text = vehicle.Manufacturer;
            boxModel.Text = vehicle.Model;
            boxDate.Value = vehicle.Date;
            boxVin.Text = vehicle.Vin; 
            boxYear.Text = vehicle.Year > 0 ? vehicle.Year.ToString() : "";
            boxColor.Text = vehicle.Color;
            if (vehicle.MileageUnits?.ToLower() == "км" && vehicle.Mileage > 0)
                boxMileageK.Text = vehicle.Mileage.ToString();
            else if (vehicle.MileageUnits?.ToLower() == "миль" && vehicle.Mileage > 0)
                boxMileageM.Text = vehicle.Mileage.ToString();
            else
            {
                boxMileageK.Text = "";
                boxMileageM.Text = "";
            }
            if (vehicle.MileageH > 0)
                boxMileageH.Text = vehicle.MileageH.ToString();
            else
                boxMileageH.Text = "";

            int i = 0;
            if (vehicle.Parts != null && vehicle.Parts.Any())
            {
                for (i = 0; i < vehicle.Parts.Count; i++)
                {
                    var part = vehicle.Parts[i];
                    Part partView = GetPartView(i);
                    partView.Name = part.Name;
                    partView.Quantity = part.Quantity;
                    partView.Units = part.Units;
                    partView.Type = part.Type;
                    partView.Notes = part.Notes;
                    if(!partView.Visible)
                        partView.Visible = true;
                }
            }
            GetPartView(i).Clear();
            GetPartView(i).Visible = true;
            for (i = i + 1; i < panelParts.Controls.Count; i++)
                GetPartView(i).Clear();
            ValidateChildren();
            ActiveControl = boxManufacturer;
        }
        private Vehicle GetCurrentVehicle()
        {
            return listHistory.SelectedIndices.Count > 0 ? DataProvider.Vehicles[listHistory.SelectedIndices[0]] : Vehicle.Empty;
        }

        public void AddPart(Part part = null)
        {
            part ??= new Views.Part
                {
                    Quantity = 1,
                    Units = Const.DefaultPartUnits,
                    Type = Const.PartTypeZip,
                    Dock = DockStyle.Fill,
                    Name = ""
                };
            part.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //part.AllowDrop = true;
            //part.DragOver += (object sender, DragEventArgs e) =>
            //{
            //    base.OnDragOver(e);
            //    var from = e.Data.GetData(typeof(Part)) as Part;
            //    var to = sender as Part;
            //    if (from != null && !from.IsLast && !to.IsLast)
            //    {
            //        FlowLayoutPanel p = (FlowLayoutPanel)(sender as Part).Parent;
            //        p.Controls.SetChildIndex(from, p.Controls.GetChildIndex(to));
            //        var t = from.Index;
            //        from.Index = to.Index;
            //        to.Index = t;
            //    }
            //};
            //part.MouseDown += (object sender, MouseEventArgs e) =>
            //{
            //    base.OnMouseDown(e);
            //    DoDragDrop(sender, DragDropEffects.All);
            //};
            panelParts.Controls.Add(part);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitUI(true);
        }

        private void panelParts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listHistory.RemoveValidation();
            InitVehicleUI(Vehicle.Empty);
        }

        private bool IdleHandlerSet { get; set; }
        private void listHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IdleHandlerSet)
            {
                IdleHandlerSet = true;
                Application.Idle += listHistory_ItemSelectionChanged;
            }
        }

        private void listHistory_ItemSelectionChanged(object sender, EventArgs e)
        {
            IdleHandlerSet = false;
            Application.Idle -= listHistory_ItemSelectionChanged;
            listHistory.RemoveValidation();
            InitVehicleUI(GetCurrentVehicle());
        }

        private void boxType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxType.Validate(string.IsNullOrEmpty(boxType.Text));
        }

        private void boxManufacturer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxManufacturer.Validate(string.IsNullOrEmpty(boxManufacturer.Text));
        }
        private void boxManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataProvider.Models.TryGetValue(boxManufacturer.Text, out var strings);
            boxModel.AddSuggestions(strings);
        }

        private void boxModel_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxModel.Validate(string.IsNullOrEmpty(boxModel.Text));
        }

        private void boxVin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxVin.Validate(string.IsNullOrEmpty(boxVin.Text));
            boxVin.Validate(!Extensions.ValidateVin(boxVin.Text), true);
        }

        private void boxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxYear.HandleNumeric(e);
        }

        private void boxYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxYear.Validate(!int.TryParse(boxYear.Text, out int year) || year < 1900 || year > DateTime.Now.Year, true);
        }

        private void boxColor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxColor.Validate(string.IsNullOrEmpty(boxColor.Text));
        }

        private Vehicle GetVehicleFromView()
        {
            var vehicle = new Vehicle()
            {
                Vin = boxVin.Text.Trim().ToUpper(),
                Color = boxColor.Text.Trim(),
                Date = boxDate.Value,
                Manufacturer = boxManufacturer.Text.Trim(),
                Model = boxModel.Text.Trim(),
                Notes = boxNotes.Text.Trim(),
                Type = boxType.Text.Trim(),
                Year = 0,
                Parts = new List<Models.Part>()
            };
            if (int.TryParse(boxYear.Text, out var year))
                vehicle.Year = year;
            if (!string.IsNullOrEmpty(boxMileageK.Text))
            {
                vehicle.Mileage = int.Parse(boxMileageK.Text);
                vehicle.MileageUnits = Const.UnitsKm;
            }
            else if (!string.IsNullOrEmpty(boxMileageM.Text))
            {
                vehicle.Mileage = int.Parse(boxMileageM.Text);
                vehicle.MileageUnits = Const.UnitsMiles;
            }
            if (!string.IsNullOrEmpty(boxMileageH.Text))
            {
                vehicle.MileageH = int.Parse(boxMileageH.Text);
            }
            foreach (Part part in panelParts.Controls)
            {
                if (string.IsNullOrEmpty(part.Name) || !part.Visible)
                    continue;
                vehicle.Parts.Add(new Models.Part
                {
                    Name = part.Name,
                    Type = part.Type,
                    Quantity = part.Quantity,
                    Notes = part.Notes,
                    Units = part.Units
                });
            }
            return vehicle;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var vehicle = GetVehicleFromView();
            DataProvider.Write(vehicle, vehicle.Date);
            InitUI(false);
            InitVehicleUI(Vehicle.Empty);
        }

        private void boxMileageK_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var empty = string.IsNullOrEmpty(boxMileageK.Text) && string.IsNullOrEmpty(boxMileageM.Text) ||
                (!int.TryParse(boxMileageK.Text, out int m1) || m1 <= 0) &&
                (!int.TryParse(boxMileageM.Text, out int m2) || m2 <= 0);
            btnSave.Enabled = boxMileageK.Validate(empty, true) && boxMileageK.Validate(empty, true);
        }

        private void boxMileageM_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            boxMileageK_Validating(sender, e);
        }

        private void boxMileageH_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxMileageH.Validate(!string.IsNullOrEmpty(boxMileageH.Text) && (!int.TryParse(boxMileageH.Text, out int m) || m <= 0), true);
        }

        private void boxMileageK_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxMileageK.HandleNumeric(e);
        }

        private void boxMileageM_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxMileageM.HandleNumeric(e);
        }

        private void boxMileageH_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxMileageH.HandleNumeric(e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataProvider.Remove(GetCurrentVehicle());
            InitUI(false);
            InitVehicleUI(Vehicle.Empty);
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (DataProvider.Vehicles.Any()) {
                var vehicle = GetCurrentVehicle();
                IdleHandlerSet = true;
                if (vehicle.IsEmpty)
                    vehicle = DataProvider.Vehicles.OrderByDescending(x => x.Updated).FirstOrDefault();
                else
                    listHistory.SelectedItems.Clear();
                vehicle = vehicle.Clone();
                vehicle.Vin = "";
                vehicle.Date = DateTime.Now.Date;
                vehicle.Updated = DateTime.Now;
                InitVehicleUI(vehicle);
                IdleHandlerSet = false;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            foreach (Part control in panelParts.Controls)
                control.Width = Width - 100;
        }

        private void boxFilterDate_ValueChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listHistory.Items)
                item.Checked = DateTime.ParseExact(item.SubItems[1].Text, Const.DateFormat, CultureInfo.InvariantCulture).Date == boxFilterDate.Value.Date;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            boxFilterDate.Value = DateTime.Today;
            boxFilterDate_ValueChanged(sender, e);
        }

        private void boxManufacturer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataProvider.WriteTemplate(GetVehicleFromView());
        }

        private void boxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var templateName = GetVehicleFromView().GetTemplateName();
            if(templateName != null && DataProvider.Templates.TryGetValue(GetVehicleFromView().GetTemplateName(), out Vehicle vehicle))
                InitVehicleUI(vehicle);
        }
    }
}