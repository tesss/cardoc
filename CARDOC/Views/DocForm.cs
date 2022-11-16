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

        private void btnZip_Click(object sender, EventArgs e)
        {
            Documents.GenerateZip(Vehicles);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Documents.GenerateIn(Vehicles);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            int.TryParse(boxAct.Text, out int act);
            foreach(var vehicle in Vehicles)
            {
                if (act > 0)
                {
                    vehicle.Act = act.ToString();
                    act++;
                }
                if (!string.IsNullOrEmpty(boxNom.Text))
                    vehicle.Nom = boxNom.Text.Trim().ToUpper();
                if (!string.IsNullOrEmpty(boxOrder.Text))
                    vehicle.Order = boxOrder.Text.Trim().ToFirstUpperCase();
                if (!string.IsNullOrEmpty(boxUnit.Text))
                    vehicle.Unit = boxUnit.Text.Trim();
                vehicle.OutDate = boxOutDate.Value;
                DataProvider.Write(vehicle);
            }
            MainForm.InitVehicleUI(Vehicle.Empty);
            Documents.GenerateOut(Vehicles);
        }

        private void btnInGeneral_Click(object sender, EventArgs e)
        {
            Documents.GenerateInGeneral(Vehicles);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Documents.GenerateZero(Vehicles);
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            Documents.GenerateInOut(Vehicles);
        }

        private void DocForm_Load(object sender, EventArgs e)
        {
            boxInfo.Text = "";
            foreach(var g in Vehicles.GroupBy(x => x.ExportFolder))
            {
                boxInfo.AppendText(g.Key.Replace(Const.ExportFolder + "/", "").PadRight(50) + g.Count().ToString() + "\n");
                boxInfo.AppendText(Environment.NewLine);
            }
            boxOutDate.Value = DateTime.Now.Date;
        }

        private void boxAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxAct.HandleNumeric(e);
        }

        private void boxUnit_Enter(object sender, EventArgs e)
        {
            MainForm.SwitchLanguage(false);
        }
    }
}
