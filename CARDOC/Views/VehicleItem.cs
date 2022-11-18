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
    public partial class VehicleItem : UserControl
    {
        public VehicleItem()
        {
            InitializeComponent();
        }

        public string Model
        {
            get
            {
                return boxModel.Text;
            }
            set
            {
                boxModel.Text = value;
            }
        }

        public string Vin
        {
            get
            {
                return boxVin.Text;
            }
            set
            {
                boxVin.Text = value;
            }
        }

        public string Act
        {
            get
            {
                return boxAct.Text;
            }
            set
            {
                boxAct.Text = value;
            }
        }

        public string Nom
        {
            get
            {
                return boxNom.Text;
            }
            set
            {
                boxNom.Text = value;
            }
        }

        public string Mou
        {
            get
            {
                return boxMou.Text;
            }
            set
            {
                boxMou.Text = value;
            }
        }

        public decimal Price
        {
            get
            {
                return decimal.Parse(boxPrice.Text);
            }
            set
            {
                boxPrice.Text = string.Format("{0:N}", value);
            }
        }
        public int Index
        {
            get { return int.Parse(lblIndex.Text.Substring(0, lblIndex.Text.Length - 1)); }
            set { lblIndex.Text = value.ToString() + "."; }
        }

        private void boxAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxAct.HandleNumeric(e);
        }

        private void boxMou_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxMou.HandleNumeric(e);
        }

        private void boxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxPrice.HandlePrice(e);
        }
    }
}
