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
            Documents.GenerateOut(Vehicles);
        }

        private void btnInGeneral_Click(object sender, EventArgs e)
        {
            Documents.GenerateInGeneral(Vehicles);
        }
    }
}
