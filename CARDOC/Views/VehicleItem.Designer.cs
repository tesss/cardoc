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
            this.boxPrice = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.boxNom = new System.Windows.Forms.TextBox();
            this.boxAct = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // boxModel
            // 
            this.boxModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxModel.Location = new System.Drawing.Point(46, 3);
            this.boxModel.Name = "boxModel";
            this.boxModel.ReadOnly = true;
            this.boxModel.Size = new System.Drawing.Size(215, 39);
            this.boxModel.TabIndex = 1000;
            // 
            // boxVin
            // 
            this.boxVin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxVin.Location = new System.Drawing.Point(267, 3);
            this.boxVin.Name = "boxVin";
            this.boxVin.ReadOnly = true;
            this.boxVin.Size = new System.Drawing.Size(244, 39);
            this.boxVin.TabIndex = 1001;
            this.boxVin.Text = "JM1BG2241R0797923";
            // 
            // boxMou
            // 
            this.boxMou.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMou.Location = new System.Drawing.Point(823, 3);
            this.boxMou.Name = "boxMou";
            this.boxMou.PlaceholderText = "МОУ";
            this.boxMou.Size = new System.Drawing.Size(184, 39);
            this.boxMou.TabIndex = 1004;
            this.boxMou.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMou_KeyPress);
            // 
            // boxPrice
            // 
            this.boxPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPrice.Location = new System.Drawing.Point(1013, 3);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.PlaceholderText = "Ціна";
            this.boxPrice.Size = new System.Drawing.Size(229, 39);
            this.boxPrice.TabIndex = 1006;
            this.boxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
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
            this.boxNom.Location = new System.Drawing.Point(623, 3);
            this.boxNom.Name = "boxNom";
            this.boxNom.PlaceholderText = "Д2111000Y";
            this.boxNom.Size = new System.Drawing.Size(194, 39);
            this.boxNom.TabIndex = 1003;
            // 
            // boxAct
            // 
            this.boxAct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxAct.Location = new System.Drawing.Point(517, 3);
            this.boxAct.Name = "boxAct";
            this.boxAct.PlaceholderText = "№ акту";
            this.boxAct.Size = new System.Drawing.Size(100, 39);
            this.boxAct.TabIndex = 1002;
            this.boxAct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // VehicleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxAct);
            this.Controls.Add(this.boxNom);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.boxPrice);
            this.Controls.Add(this.boxMou);
            this.Controls.Add(this.boxVin);
            this.Controls.Add(this.boxModel);
            this.Name = "VehicleItem";
            this.Size = new System.Drawing.Size(1243, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox boxModel;
        private TextBox boxVin;
        private TextBox boxMou;
        private TextBox boxPrice;
        private Label lblIndex;
        private TextBox boxNom;
        private TextBox boxAct;
    }
}
