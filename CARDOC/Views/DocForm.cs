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
            AddResults(Documents.GenerateInOut(Vehicles));
        }

        private void DocForm_Load(object sender, EventArgs e)
        {
            
            boxOutDate.Value = DateTime.Now.Date;
            var i = 0;
            foreach(var vehicle in Vehicles)
            {
                panelVehicles.Controls.Add(new VehicleItem
                {
                    Index = ++i,
                    Model = vehicle.TemplateName,
                    Vin = vehicle.Vin,
                    Mou = vehicle.Mou,
                    Price = vehicle.Price,
                    Nom = vehicle.Nom,
                    Act = vehicle.Act
                });
            }
            panelVehicles.Height = panelVehicles.Controls.Count * ((panelVehicles.Controls[0] as VehicleItem).Height + 6);
            listFiles.Top = panelVehicles.Top + panelVehicles.Height + 20;
        }

        private void boxAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxAct.HandleNumeric(e);
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
            int.TryParse(boxAct.Text, out int act);
            var i = 0;
            foreach (var vehicle in Vehicles)
            {
                var vehicleView = panelVehicles.Controls[i] as VehicleItem;
                if (act > 0)
                {
                    vehicle.Act = act.ToString();
                    vehicleView.Act = vehicle.Act;
                    act++;
                } else
                {
                    vehicle.Act = vehicleView.Act;
                }
                if (!string.IsNullOrEmpty(boxNom.Text))
                {
                    vehicle.Nom = boxNom.Text.Trim().ToUpper();
                    vehicleView.Nom = vehicle.Nom;
                } else
                {
                    vehicle.Nom = vehicleView.Nom;
                }
                if (!string.IsNullOrEmpty(boxOrder.Text))
                    vehicle.Order = boxOrder.Text.Trim().ToFirstUpperCase();
                if (!string.IsNullOrEmpty(boxUnit.Text))
                    vehicle.Unit = boxUnit.Text.Trim();
                vehicle.OutDate = boxOutDate.Value;
                vehicle.Mou = vehicleView.Mou;
                vehicle.Price = vehicleView.Price;
                vehicle.Updated = DateTime.Now;
                DataProvider.Write(vehicle);
                i++;
            }
            MainForm.InitVehicleUI(Vehicle.Empty);
        }
    }
}
