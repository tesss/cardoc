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
                return boxActOut.Text;
            }
            set
            {
                boxActOut.Text = value;
            }
        }

        public string ActIn
        {
            get
            {
                return boxActIn.Text;
            }
            set
            {
                boxActIn.Text = value;
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

        public decimal PriceUAH
        {
            get
            {
                if (decimal.TryParse(boxPriceUAH.Text, out decimal price))
                    return price;
                return 0;
            }
            set
            {
                boxPriceUAH.Text = string.Format("{0:N}", value);
            }
        }
        public decimal PriceUSD
        {
            get
            {
                if (decimal.TryParse(boxPriceUSD.Text, out decimal price))
                    return price;
                return 0;
            }
            set
            {
                boxPriceUSD.Text = string.Format("{0:N}", value);
            }
        }
        public decimal PriceEUR
        {
            get
            {
                if (decimal.TryParse(boxPriceEUR.Text, out decimal price))
                    return price;
                return 0;
            }
            set
            {
                boxPriceEUR.Text = string.Format("{0:N}", value);
            }
        }
        public decimal H1
        {
            get
            {
                if (decimal.TryParse(boxH1.Text, out decimal d))
                    return d;
                return 0;
            }
            set
            {
                boxH1.Text = string.Format("{0:N}", value);
            }
        }
        public decimal H2
        {
            get
            {
                if (decimal.TryParse(boxH2.Text, out decimal d))
                    return d;
                return 0;
            }
            set
            {
                boxH2.Text = string.Format("{0:N}", value);
            }
        }
        public int Index
        {
            get { return int.Parse(lblIndex.Text.Substring(0, lblIndex.Text.Length - 1)); }
            set { lblIndex.Text = value.ToString() + "."; }
        }

        private void boxAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxActIn.HandleNumeric(e);
        }

        private void boxMou_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxMou.HandleNumeric(e);
        }

        private void boxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            boxPriceUSD.HandlePrice(e);
        }

        private void VehicleItem_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                    textBox.MouseClick += new MouseEventHandler(SelectAll);
            }
        }

        public void SelectAll(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }
}
