namespace CARDOC.Views
{
    partial class VehicleItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxModel = new System.Windows.Forms.TextBox();
            this.boxVin = new System.Windows.Forms.TextBox();
            this.boxMou = new System.Windows.Forms.TextBox();
            this.boxPriceUSD = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.boxNom = new System.Windows.Forms.TextBox();
            this.boxActIn = new System.Windows.Forms.TextBox();
            this.boxPriceEUR = new System.Windows.Forms.TextBox();
            this.boxH1 = new System.Windows.Forms.TextBox();
            this.boxH2 = new System.Windows.Forms.TextBox();
            this.boxPriceUAH = new System.Windows.Forms.TextBox();
            this.boxActOut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // boxModel
            // 
            this.boxModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxModel.Location = new System.Drawing.Point(46, 3);
            this.boxModel.Name = "boxModel";
            this.boxModel.ReadOnly = true;
            this.boxModel.Size = new System.Drawing.Size(214, 39);
            this.boxModel.TabIndex = 1000;
            // 
            // boxVin
            // 
            this.boxVin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxVin.Location = new System.Drawing.Point(266, 3);
            this.boxVin.Name = "boxVin";
            this.boxVin.ReadOnly = true;
            this.boxVin.Size = new System.Drawing.Size(250, 39);
            this.boxVin.TabIndex = 1001;
            this.boxVin.Text = "JM1BG2241R0797923";
            // 
            // boxMou
            // 
            this.boxMou.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMou.Location = new System.Drawing.Point(878, 3);
            this.boxMou.Name = "boxMou";
            this.boxMou.PlaceholderText = "МОУ";
            this.boxMou.Size = new System.Drawing.Size(84, 39);
            this.boxMou.TabIndex = 1005;
            this.boxMou.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMou_KeyPress);
            // 
            // boxPriceUSD
            // 
            this.boxPriceUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.boxPriceUSD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPriceUSD.Location = new System.Drawing.Point(968, 3);
            this.boxPriceUSD.Name = "boxPriceUSD";
            this.boxPriceUSD.PlaceholderText = "$$$.$$";
            this.boxPriceUSD.Size = new System.Drawing.Size(101, 39);
            this.boxPriceUSD.TabIndex = 1006;
            this.boxPriceUSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
            // 
            // lblIndex
            // 
            this.lblIndex.AllowDrop = true;
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIndex.Location = new System.Drawing.Point(3, 6);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(0, 32);
            this.lblIndex.TabIndex = 112;
            // 
            // boxNom
            // 
            this.boxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxNom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNom.Location = new System.Drawing.Point(734, 3);
            this.boxNom.Name = "boxNom";
            this.boxNom.PlaceholderText = "Д2111000Y";
            this.boxNom.Size = new System.Drawing.Size(138, 39);
            this.boxNom.TabIndex = 1004;
            // 
            // boxActIn
            // 
            this.boxActIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxActIn.Location = new System.Drawing.Point(522, 3);
            this.boxActIn.Name = "boxActIn";
            this.boxActIn.PlaceholderText = "№ прийм";
            this.boxActIn.Size = new System.Drawing.Size(100, 39);
            this.boxActIn.TabIndex = 1002;
            this.boxActIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // boxPriceEUR
            // 
            this.boxPriceEUR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.boxPriceEUR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPriceEUR.Location = new System.Drawing.Point(1075, 3);
            this.boxPriceEUR.Name = "boxPriceEUR";
            this.boxPriceEUR.PlaceholderText = "€€€.€€";
            this.boxPriceEUR.Size = new System.Drawing.Size(101, 39);
            this.boxPriceEUR.TabIndex = 1007;
            this.boxPriceEUR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
            // 
            // boxH1
            // 
            this.boxH1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxH1.Location = new System.Drawing.Point(1289, 3);
            this.boxH1.Name = "boxH1";
            this.boxH1.PlaceholderText = "H1";
            this.boxH1.Size = new System.Drawing.Size(58, 39);
            this.boxH1.TabIndex = 1009;
            this.boxH1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
            // 
            // boxH2
            // 
            this.boxH2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxH2.Location = new System.Drawing.Point(1353, 3);
            this.boxH2.Name = "boxH2";
            this.boxH2.PlaceholderText = "H2";
            this.boxH2.Size = new System.Drawing.Size(58, 39);
            this.boxH2.TabIndex = 1010;
            this.boxH2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
            // 
            // boxPriceUAH
            // 
            this.boxPriceUAH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(229)))));
            this.boxPriceUAH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPriceUAH.Location = new System.Drawing.Point(1182, 3);
            this.boxPriceUAH.Name = "boxPriceUAH";
            this.boxPriceUAH.PlaceholderText = "₴₴₴.₴₴";
            this.boxPriceUAH.Size = new System.Drawing.Size(101, 39);
            this.boxPriceUAH.TabIndex = 1008;
            this.boxPriceUAH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
            // 
            // boxActOut
            // 
            this.boxActOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxActOut.Location = new System.Drawing.Point(628, 3);
            this.boxActOut.Name = "boxActOut";
            this.boxActOut.PlaceholderText = "№ видачі";
            this.boxActOut.Size = new System.Drawing.Size(100, 39);
            this.boxActOut.TabIndex = 1003;
            this.boxActOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // VehicleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxActOut);
            this.Controls.Add(this.boxPriceUAH);
            this.Controls.Add(this.boxH2);
            this.Controls.Add(this.boxH1);
            this.Controls.Add(this.boxPriceEUR);
            this.Controls.Add(this.boxActIn);
            this.Controls.Add(this.boxNom);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.boxPriceUSD);
            this.Controls.Add(this.boxMou);
            this.Controls.Add(this.boxVin);
            this.Controls.Add(this.boxModel);
            this.Name = "VehicleItem";
            this.Size = new System.Drawing.Size(1414, 47);
            this.Load += new System.EventHandler(this.VehicleItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox boxModel;
        private TextBox boxVin;
        private TextBox boxMou;
        private TextBox boxPriceUSD;
        private Label lblIndex;
        private TextBox boxNom;
        private TextBox boxActIn;
        private TextBox boxPriceEUR;
        private TextBox boxH1;
        private TextBox boxH2;
        private TextBox boxPriceUAH;
        private TextBox boxActOut;
    }
}
