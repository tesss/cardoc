using CARDOC.Models;
using CARDOC.Utils;
using CARDOC.Views;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Part = CARDOC.Views.Part;
using TextBox = System.Windows.Forms.TextBox;

namespace CARDOC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Vehicle _currentVehicle;
        private List<Vehicle> _vehicles;

        private void InitUI(bool first)
        {
            _vehicles = DataProvider.Vehicles;
            if (!string.IsNullOrEmpty(boxFilter.Text))
            {
                var filter = boxFilter.Text.Trim();
                _vehicles = _vehicles.Where(x => JsonConvert.SerializeObject(x).Contains(filter)).ToList();
            }
            listHistory.Clear();
            listHistory.Columns.Add("✔", 50);
            listHistory.Columns.Add("Дата", 200);
            listHistory.Columns.Add("Виробник", 150);
            listHistory.Columns.Add("Модель", 300);
            listHistory.Columns.Add("Vin", 200);
            listHistory.Columns.Add("Рік", 100);
            listHistory.Columns.Add("Пробіг", 100);
            listHistory.Columns.Add("Оновлено", 100);
            foreach (var vehicle in _vehicles)
            {
                ListViewItem lvi = new ListViewItem{ Checked = false };
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Дата") { Text = vehicle.Date.ToString(Const.DateFormat) });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Виробник") { Text = vehicle.Manufacturer });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Модель"){ Text = vehicle.Model });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Vin") { Text = vehicle.Vin });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Рік") { Text = vehicle.Year.ToString() });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Пробіг") { Text = vehicle.Mileage + " " + vehicle.MileageUnits });
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Оновлено") { Text = vehicle.Updated.ToString("dd.MM.yyyy HH:mm:ss") });
                listHistory.Items.Add(lvi);
            }
            listHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            if (first)
            {
                foreach(var control in Controls)
                {
                    TextBox textBox = control as TextBox;
                    if(textBox != null && textBox.Name != boxVin.Name)
                        textBox.MouseClick += new MouseEventHandler(this.SelectAll);
                }
                boxFilterDate.CustomFormat = boxDate.CustomFormat = boxOutDate.CustomFormat = Const.DateShortFormat;
                var start = 1970;
                boxYear.AddSuggestions(Enumerable.Range(start, DateTime.Now.Year - start + 1).Reverse().Select(x => x.ToString()).ToArray());
                var c = DataProvider.Vehicles.Any() ? DataProvider.Vehicles.Max(x => x.Parts.Count) + 3 : 50;
                for (var i = 0; i < c; i++)
                    AddPart();
                    if (listHistory.Items.Count > 0)
                {
                    listHistory.Items[0].Selected = true;
                    listHistory.Select();
                }
                else
                    InitVehicleUI(Vehicle.Empty);
                WindowState = FormWindowState.Maximized;
                boxDate.MaxDate = boxFilterDate.MaxDate = boxOutDate.MaxDate = DateTime.Today.Date.AddMonths(1);
                ActiveControl = boxFilter;
            }
            AddSuggestions();
        }

        private void AddSuggestions()
        {
            boxType.AddSuggestions(DataProvider.Types);
            boxManufacturer.AddSuggestions(DataProvider.Models);
            boxColor.AddSuggestions(DataProvider.Colors);
            foreach (Part part in panelParts.Controls)
                part.AddSuggestions();
        }

        private Part GetPartView(int index)
        {
            if (panelParts.Controls.Count == index)
                AddPart();
            return panelParts.Controls[index] as Part;
        }

        private async void InitVehicleUI(Vehicle vehicle, bool fromTemplate = false)
        {
            _vehicleUpdate = true;
            if(!fromTemplate)
                _currentVehicle = vehicle;
            boxManufacturer.Text = vehicle.Manufacturer;
            boxModel.Text = vehicle.Model;
            boxType.Text = vehicle.Type;
            boxDate.Value = vehicle.Date;
            boxVin.Text = vehicle.Vin; 
            boxYear.Text = vehicle.Year > 0 ? vehicle.Year.ToString() : "";
            boxColor.Text = vehicle.Color;
            boxNotes.Text = vehicle.Notes;
            boxMedical.Checked = vehicle.Medical;
            boxRao.Checked = vehicle.Rao;
            boxCommunication.Checked = vehicle.Сommunication;

            boxAct.Text = vehicle.Act;
            boxNom.Text = vehicle.Nom;
            boxOrder.Text = vehicle.Order;
            boxMou.Text = vehicle.Mou;
            boxUnit.Text = vehicle.Unit;
            boxOutDate.Value = vehicle.OutDate;

            boxPrice.Text = string.Format("{0:N}", vehicle.Price);

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
            Part partView;
            if (vehicle.Parts != null && vehicle.Parts.Any())
            {
                for (i = 0; i < vehicle.Parts.Count; i++)
                {
                    var part = vehicle.Parts[i];
                    partView = GetPartView(i);
                    partView.Name = part.Name;
                    partView.Quantity = part.Quantity;
                    partView.Units = part.Units;
                    partView.Type = part.Type;
                    partView.Number = part.Number;
                    partView.Notes = part.Notes;
                    partView.UpdateColor();
                    partView.Index = i + 1;
                }
            }
            partView = GetPartView(i);
            partView.Clear();
            partView.Index = i + 1;
            for (i = i + 1; i < panelParts.Controls.Count; i++)
            {
                partView = GetPartView(i);
                partView.Clear();
                partView.Index = i + 1;
            }
            ValidateChildren();
            ActiveControl = boxManufacturer;
            _vehicleUpdate = false;
        }
        private Vehicle GetCurrentVehicle()
        {
            return listHistory.SelectedIndices.Count > 0 ? _vehicles[listHistory.SelectedIndices[0]] : Vehicle.Empty;
        }

        public Part AddPart(Part part = null)
        {
            part ??= new Views.Part
                {
                    Quantity = 1,
                    Units = Const.DefaultPartUnits,
                    Type = PartType.Zip.GetDescription(),
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
                if (from != null)
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
            part.Index = panelParts.Controls.Count + 1;
            panelParts.Controls.Add(part);
            return part;
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
            listHistory.SelectedItems.Clear();
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
            var vin = listHistory.SelectedItems.Count > 0 ? listHistory.SelectedItems[0].SubItems[3].Text : null;
            var viewVehicle = GetVehicleFromView();
            var showConfirm = !viewVehicle.IsEmpty && !viewVehicle.Equals(Vehicle.Empty) && !viewVehicle.Equals(_currentVehicle);
            if (showConfirm)
            {
                var confirmResult = MessageBox.Show("Є незбережені зміни. Зберегти?",
                                     "",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var vehicle = GetVehicleFromView();
                    DataProvider.Write(vehicle);
                    InitUI(false);
                    if (vin != null)
                        foreach (ListViewItem item in listHistory.Items)
                            if (item.SubItems[3].Text == vin)
                                item.Selected = true;
                }
            }
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
            boxModel.AddSuggestions(strings, true);
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
        }

        private Vehicle GetVehicleFromView()
        {
            var vehicle = new Vehicle()
            {
                Vin = boxVin.Text.Trim().ToUpper(),
                Color = boxColor.Text.Trim(),
                Date = boxDate.Value,
                Manufacturer = boxManufacturer.Text.Trim().ToUpper(),
                Model = boxModel.Text.Trim().ToTitleCase().ToUpper(),
                Notes = boxNotes.Text.Trim(),
                Medical = boxMedical.Checked,
                Сommunication = boxCommunication.Checked,
                Rao = boxRao.Checked,
                Type = boxType.Text.Trim().ToFirstUpperCase(),
                Act = boxAct.Text,
                Nom = boxNom.Text.Trim().ToUpper(),
                Order = boxOrder.Text.Trim().ToFirstUpperCase(),
                Mou = boxMou.Text,
                Unit = boxUnit.Text.Trim(),
                OutDate = boxOutDate.Value,
                Parts = new List<Models.Part>(),
                Updated = DateTime.Now
            };
            if (int.TryParse(boxYear.Text, out var year))
                vehicle.Year = year;
            if (decimal.TryParse(boxPrice.Text, out var price))
                vehicle.Price = price;
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
                if (part.IsEmpty)
                    continue;
                vehicle.Parts.Add(new Models.Part
                {
                    Name = part.Name.ToFirstUpperCase(),
                    Type = part.Type.ToFirstUpperCase(),
                    Quantity = part.Quantity,
                    Number = part.Number.ToUpper(),
                    Notes = part.Notes.ToLower(),
                    Units = part.Units.ToLower(),
                    Index = part.Index
                });
            }
            vehicle.Parts = vehicle.Parts.OrderBy(x => x.PartType).ThenBy(x => x.Index).ToList();
            return vehicle;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var vehicle = GetVehicleFromView();
            var selectedVehicle = GetCurrentVehicle();
            if (selectedVehicle.Vin != vehicle.Vin)
            {
                if (DataProvider.Exists(vehicle))
                {
                    var confirmResult = MessageBox.Show("Такий VIN існує. Перезаписати?", "", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.No)
                        return;
                }
                DataProvider.Remove(selectedVehicle);
            }
            DataProvider.Write(vehicle);
            InitUI(false);
            /* add clone from the last */
            vehicle = vehicle.Clone();
            vehicle.Updated = DateTime.Now;
            InitVehicleUI(vehicle);
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

        public void DoResize(bool resetAutoScroll)
        {
            panelParts.Width = Width - 50;
            foreach (Part control in panelParts.Controls)
                control.Width = panelParts.Width - 5;
            if (panelParts.Controls.Count > 0)
                panelParts.Height = panelParts.Controls.Count * ((panelParts.Controls[0] as Part).Height + 6);
            if(resetAutoScroll)
                AutoScrollPosition = new Point(0, panelParts.Top);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            DoResize(true);
        }

        private void boxFilterDate_ValueChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listHistory.Items)
                item.Checked = DateTime.ParseExact(item.SubItems[1].Text, Const.DateFormat, CultureInfo.InvariantCulture).Date == boxFilterDate.Value.Date;
        }

        private void boxManufacturer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataProvider.WriteTemplate(GetVehicleFromView());
            AddSuggestions();
        }

        private bool _vehicleUpdate;
        private void boxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_vehicleUpdate)
            {
                _vehicleUpdate = false;
                return;
            }
            var templateName = GetVehicleFromView().TemplateName;
            if (templateName != null && DataProvider.Templates.TryGetValue(GetVehicleFromView().TemplateName, out Vehicle vehicle))
            {
                vehicle.Date = vehicle.OutDate = DateTime.Now.Date;
                InitVehicleUI(vehicle, true);
            }
        }

        private int panelPartsHeight = 0;
        private void panelParts_Leave(object sender, EventArgs e)
        {
            panelParts.Top = 709;
            panelParts.Height = panelPartsHeight;
            panelParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void panelParts_Enter(object sender, EventArgs e)
        {
            panelParts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelParts.Top = 0;
            panelPartsHeight = panelParts.Height;
            panelParts.Height = 400;
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            var docDialog = new DocForm();
            var vehicles = new List<Vehicle>();
            foreach (int index in listHistory.CheckedIndices)
                vehicles.Add(_vehicles[index]);
            docDialog.Vehicles = vehicles;
            docDialog.ShowDialog(this);
            docDialog.Dispose();
        }

        private void listHistory_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnDoc.Enabled = listHistory.CheckedIndices.Count > 0;
        }

        public void SwitchLanguage(bool en)
        {
            try
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(en ? "en-US" : "uk-UA"));
            }
            catch { }
        }

        private void boxManufacturer_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(true);
        }

        private void boxModel_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(true);
        }

        private void boxType_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(false);
        }

        private void boxVin_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(true);
        }

        private void boxColor_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(false);
        }

        private void boxNotes_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(false);
        }

        public void Upper(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public void Lower(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void boxAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxAct.HandleNumeric(e);
        }

        private void boxMou_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxMou.HandleNumeric(e);
        }

        private void boxUnit_Enter(object sender, EventArgs e)
        {
            SwitchLanguage(false);
        }

        public void SelectAll(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void boxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxPrice.HandlePrice(e);
        }

        private void boxFilter_TextChanged(object sender, EventArgs e)
        {
            InitUI(false);
        }
    }
}