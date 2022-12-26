using CARDOC.Models;
using CARDOC.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace CARDOC.Views
{
    public partial class DocForm : Form
    {
        public DocForm()
        {
            InitializeComponent();
        }

        public List<Vehicle> Vehicles { get; set; }
        public MainForm MainForm { get; set; }

        private void AddResults(List<string> files)
        {
            listFiles.Items.Clear();
            listFiles.Items.AddRange(files.ToArray());
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateZip(Vehicles));
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateIn(Vehicles));
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateOut(Vehicles));
        }

        private void btnInGeneral_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateInGeneral(Vehicles));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateZero(Vehicles));
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            FillKi();
            AddResults(Documents.GenerateInOut(Vehicles));
        }

        private void btnInOutGeneral_Click(object sender, EventArgs e)
        {
            FillKi();
            AddResults(Documents.GenerateInOutGeneral(Vehicles, boxWear.Checked));
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateGeneral(Vehicles));
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            decimal.TryParse(boxRateUSD.Text, out decimal rateUSD);
            decimal.TryParse(boxRateEUR.Text, out decimal rateEUR);
            var rate = rateUSD > 0 ? rateUSD : rateEUR;
            AddResults(Documents.GeneratePrice(Vehicles, rate));
        }
        private void btnPriceCalc_click(object sender, EventArgs e)
        {
            FillKi();
            AddResults(Documents.GeneratePriceCalc(Vehicles));
        }

        private void DocForm_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                    textBox.MouseClick += new MouseEventHandler(SelectAll);
            }
            var first = Vehicles.FirstOrDefault();
            if (first != null)
            {
                bool allSame = Vehicles.All(x => x.Order == first.Order && x.Unit == first.Unit && x.OutDate == first.OutDate);
                boxKi.Text = string.Format("{0:N}", 0.7);
                boxH1.Text = string.Format("{0:N}", 0.3);
                boxH2.Text = string.Format("{0:N}", 1.56);
                boxOutDate.Value = DateTime.Now.Date;
                boxNom.Text = first.Nom;
                boxNom.Text = string.IsNullOrEmpty(boxNom.Text) ? DataProvider.Vehicles.FirstOrDefault(x => x.TemplateName == first.TemplateName && !string.IsNullOrEmpty(x.Nom))?.Nom : first.Nom;
                if (allSame)
                {
                    boxOrder.Text = first.Order;
                    boxUnit.Text = first.Unit;
                    if(first.OutDate != Vehicle.EmptyDate)
                        boxOutDate.Value = first.OutDate;
                }
                var i = 0;
                foreach (var vehicle in Vehicles)
                {
                    panelVehicles.Controls.Add(new VehicleItem
                    {
                        Index = ++i,
                        Model = vehicle.TemplateName,
                        Vin = vehicle.Vin,
                        Mou = vehicle.Mou,
                        PriceUAH = vehicle.Price,
                        PriceUSD = vehicle.PriceUSD,
                        PriceEUR = vehicle.PriceEUR,
                        Nom = vehicle.Nom,
                        Act = vehicle.Act,
                        ActIn = vehicle.ActIn,
                        H1 = vehicle.H1,
                        H2 = vehicle.H2
                    });
                }
                panelVehicles.Height = panelVehicles.Controls.Count * ((panelVehicles.Controls[0] as VehicleItem).Height + 6);
            }
            listFiles.Top = panelVehicles.Top + panelVehicles.Height + 20;
            boxFrom.MinDate = boxTo.MinDate = boxFrom.Value = DataProvider.Vehicles.Min(x => x.Date).Date;
            boxFrom.MaxDate = boxTo.MaxDate = boxTo.Value = DataProvider.Vehicles.Max(x => x.Date).Date;
        }

        private void boxAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxActOut.HandleNumeric(e);
        }

        private void boxUnit_Enter(object sender, EventArgs e)
        {
            MainForm.SwitchLanguage(false);
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listFiles.SelectedItem == null)
                Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Const.ExportFolder);
            else
                new Process
                {
                    StartInfo = new ProcessStartInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + (listFiles.SelectedItem as string).Replace("/", "\\"))
                    {
                        UseShellExecute = true
                    }
                }.Start();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int.TryParse(boxActOut.Text, out int act);
            int.TryParse(boxActIn.Text, out int actIn);
            decimal.TryParse(boxPriceUSD.Text, out decimal priceUSD);
            decimal.TryParse(boxPriceEUR.Text, out decimal priceEUR);
            decimal.TryParse(boxPriceUAH.Text, out decimal priceUAH);
            decimal.TryParse(boxRateUSD.Text, out decimal rateUSD);
            decimal.TryParse(boxRateEUR.Text, out decimal rateEUR);
            decimal.TryParse(boxKi.Text, out decimal ki);
            decimal.TryParse(boxH1.Text, out decimal h1);
            decimal.TryParse(boxH2.Text, out decimal h2);
            var i = 0;
            foreach (var vehicle in Vehicles)
            {
                var vehicleView = panelVehicles.Controls[i] as VehicleItem;
                if (act > 0)
                {
                    vehicleView.Act = vehicle.Act = act.ToString();
                    act++;
                } else
                    vehicle.Act = vehicleView.Act;

                if (actIn > 0)
                {
                    vehicleView.ActIn = vehicle.ActIn = actIn.ToString();
                    actIn++;
                }
                else
                    vehicle.ActIn = vehicleView.ActIn;

                if (!string.IsNullOrEmpty(boxNom.Text))
                    vehicleView.Nom = vehicle.Nom = boxNom.Text.Trim().ToUpper();
                else
                    vehicle.Nom = vehicleView.Nom;

                if (!string.IsNullOrEmpty(boxOrder.Text))
                    vehicle.Order = boxOrder.Text.Trim().ToFirstUpperCase();
                if (!string.IsNullOrEmpty(boxUnit.Text))
                    vehicle.Unit = boxUnit.Text.Trim();

                if (!string.IsNullOrEmpty(vehicle.Order) && !string.IsNullOrEmpty(vehicle.Unit))
                    vehicle.OutDate = boxOutDate.Value;
                vehicle.Mou = vehicleView.Mou;
                vehicleView.PriceUAH = vehicle.Price = priceUAH > 0 ? priceUAH : vehicleView.PriceUAH;
                vehicleView.PriceUSD = vehicle.PriceUSD = priceUSD > 0 ? priceUSD : vehicleView.PriceUSD;
                vehicleView.PriceEUR = vehicle.PriceEUR = priceEUR > 0 ? priceEUR : vehicleView.PriceEUR;
                if(vehicle.PriceUSD > 0 && rateUSD > 0)
                    vehicleView.PriceUAH = vehicle.Price = vehicle.PriceUSD * rateUSD;
                else if (vehicle.PriceEUR > 0 && rateEUR > 0)
                    vehicleView.PriceUAH = vehicle.Price = vehicle.PriceEUR * rateEUR;
                if (boxPrimaryPrice.Checked && ki > 0)
                    vehicleView.PriceUAH = vehicle.Price = vehicle.Price / ki;

                if (h1 > 0)
                    vehicleView.H1 = vehicle.H1 = h1;
                else
                    vehicle.H1 = vehicleView.H1;
                if (h2 > 0)
                    vehicleView.H2 = vehicle.H2 = h2;
                else
                    vehicle.H2 = vehicleView.H2;
                vehicle.Updated = DateTime.Now;
                DataProvider.Write(vehicle);
                i++;
            }
            MainForm.InitUI(false);
            MainForm.InitVehicleUI(Vehicle.Empty);
        }

        private void boxNom_Enter(object sender, EventArgs e)
        {
            MainForm.SwitchLanguage(false);
        }

        private void boxOrder_Enter(object sender, EventArgs e)
        {
            MainForm.SwitchLanguage(false);
        }

        private void HandleDecimal(object sender, KeyPressEventArgs e)
        {
            boxPriceUAH.HandlePrice(e);
        }

        public void SelectAll(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FillKi();
            AddResults(Documents.GenerateInvoice(Vehicles, boxWear.Checked));
        }

        private void FillKi()
        {
            decimal.TryParse(boxKi.Text, out decimal ki);
            foreach (var vehicle in Vehicles)
                vehicle.Ki = ki;
        }

        private void listFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (listFiles.SelectedIndex < 0 || !listFiles.GetItemRectangle(listFiles.SelectedIndex).Contains(e.Location))
                listFiles.SelectedIndex = -1;
            
        }

        private void listFiles_MouseUp(object sender, MouseEventArgs e)
        {
            listFiles.SelectedIndex = listFiles.IndexFromPoint(e.X, e.Y);
            if (e.Button == MouseButtons.Right && listFiles.SelectedItem != null)
            {
                var fileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + (listFiles.SelectedItem as string).Replace("/", "\\");
                string args = string.Format("/e, /select, \"{0}\"", fileName);
                new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = "explorer",
                        Arguments = args
                    }
                }.Start();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            AddResults(Documents.GenerateReg(Vehicles));
        }

        private void btnAT1_click(object sender, EventArgs e)
        {
            var from = boxFrom.Value;
            var to = boxTo.Value;
            AddResults(Documents.GenerateCounts(from, to));
        }
    }
}
