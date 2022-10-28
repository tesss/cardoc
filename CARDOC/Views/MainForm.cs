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

        private void InitUI()
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
            //listHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            if (listHistory.Items.Count > 0)
            {
                listHistory.Items[0].Selected = true;
                listHistory.Select();
            }
            else
                InitVehicleUI(Vehicle.Empty);
            boxDate.MaxDate = boxFilterDate.MaxDate = DateTime.Today.Date.AddDays(1);
            boxType.AddSuggestions(DataProvider.Types);
            boxManufacturer.AddSuggestions(DataProvider.Models);
            boxColor.AddSuggestions(DataProvider.Colors);
        }

        private void InitVehicleUI(Vehicle vehicle)
        {
            boxType.Text = vehicle.Type;
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
            boxNotes.Text = vehicle.Notes;
            panelParts.Controls.Clear();
            if (vehicle.Parts != null && vehicle.Parts.Any())
            {
                foreach (var part in vehicle.Parts)
                    AddPart(new Views.Part
                    {
                        Name = part.Name,
                        Quantity = part.Quantity,
                        Units = part.Units,
                        Type = part.Type,
                        Notes = part.Notes
                    });
            }
            else
            {
                AddPart(new Views.Part { Name = "Кузов", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Двигун (дизельний)", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Передній міст", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Коробка передач", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Задній міст", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Роздавальна коробка", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Кермовий механізм", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeGeneral });
                AddPart(new Views.Part { Name = "Автомобільні шини", Quantity = 5, Units = Const.DefaultPartUnits, Type = Const.PartTypeTire });
                AddPart(new Views.Part { Name = "Акумулятрні батареї 12В 6СТ Ah", Quantity = 1, Units = Const.DefaultPartUnits, Type = Const.PartTypeBattery });
            }
            AddPart();
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
            part.AllowDrop = true;
            part.DragOver += (object sender, DragEventArgs e) =>
            {
                base.OnDragOver(e);
                var from = e.Data.GetData(typeof(Part)) as Part;
                var to = sender as Part;
                if (from != null && !from.IsLast && !to.IsLast)
                {
                    FlowLayoutPanel p = (FlowLayoutPanel)(sender as Part).Parent;
                    p.Controls.SetChildIndex(from, p.Controls.GetChildIndex(to));
                    var t = from.Index;
                    from.Index = to.Index;
                    to.Index = t;
                }
            };
            part.MouseDown += (object sender, MouseEventArgs e) =>
            {
                base.OnMouseDown(e);
                DoDragDrop(sender, DragDropEffects.All);
            };
            panelParts.Controls.Add(part);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void panelParts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listHistory.RemoveValidation();
            InitVehicleUI(Vehicle.Empty);
        }

        private void listHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHistory.RemoveValidation();
            InitVehicleUI(GetCurrentVehicle());
        }

        private void listHistory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

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
            btnSave.Enabled = boxYear.Validate(!int.TryParse(boxYear.Text, out int year) || year < 1900 || year > DateTime.Now.Year);
        }

        private void boxColor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxColor.Validate(string.IsNullOrEmpty(boxColor.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                Year = int.Parse(boxYear.Text),
                Parts = new List<Models.Part>()
            };
            if(!string.IsNullOrEmpty(boxMileageK.Text))
            {
                vehicle.Mileage = int.Parse(boxMileageK.Text);
                vehicle.MileageUnits = Const.UnitsKm;
            } else if (!string.IsNullOrEmpty(boxMileageM.Text))
            {
                vehicle.Mileage = int.Parse(boxMileageM.Text);
                vehicle.MileageUnits = Const.UnitsMiles;
            }
            if (!string.IsNullOrEmpty(boxMileageH.Text))
            {
                vehicle.MileageH = int.Parse(boxMileageH.Text);
            }
            foreach(Part part in panelParts.Controls)
            {
                if (string.IsNullOrEmpty(part.Name))
                    break;
                vehicle.Parts.Add(new Models.Part
                {
                    Name = part.Name,
                    Type = part.Type,
                    Quantity = part.Quantity,
                    Notes = part.Notes,
                    Units = part.Units
                });
            }
            DataProvider.Write(vehicle, vehicle.Date);
            InitUI();
            InitVehicleUI(Vehicle.Empty);
        }

        private void boxMileageK_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var empty = string.IsNullOrEmpty(boxMileageK.Text) && string.IsNullOrEmpty(boxMileageM.Text) ||
                (!int.TryParse(boxMileageK.Text, out int m1) || m1 <= 0) &&
                (!int.TryParse(boxMileageM.Text, out int m2) || m2 <= 0);
            btnSave.Enabled = boxMileageK.Validate(empty) && boxMileageK.Validate(empty);
        }

        private void boxMileageM_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            boxMileageK_Validating(sender, e);
        }

        private void boxMileageH_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Enabled = boxMileageH.Validate(!string.IsNullOrEmpty(boxMileageH.Text) && (!int.TryParse(boxMileageH.Text, out int m) || m <= 0));
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
            InitUI();
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (DataProvider.Vehicles.Any()) {
                var vehicle = GetCurrentVehicle();
                if (vehicle.IsEmpty)
                    vehicle = DataProvider.Vehicles.OrderByDescending(x => x.Updated).FirstOrDefault();
                vehicle = vehicle.Clone();
                vehicle.Vin = "";
                vehicle.Date = DateTime.Now.Date;
                vehicle.Updated = DateTime.Now;
                InitVehicleUI(vehicle);
                listHistory.SelectedItems.Clear();
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
    }
}