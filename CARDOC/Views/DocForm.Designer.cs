namespace CARDOC.Views
{
    partial class DocForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnZip = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnInGeneral = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInOut = new System.Windows.Forms.Button();
            this.boxInfo = new System.Windows.Forms.TextBox();
            this.boxAct = new System.Windows.Forms.TextBox();
            this.boxOrder = new System.Windows.Forms.TextBox();
            this.boxUnit = new System.Windows.Forms.TextBox();
            this.boxOutDate = new System.Windows.Forms.DateTimePicker();
            this.boxNom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnZip
            // 
            this.btnZip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZip.Location = new System.Drawing.Point(1123, 6);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(269, 70);
            this.btnZip.TabIndex = 200;
            this.btnZip.Text = "Відомість комплектації ЗІП";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIn.Location = new System.Drawing.Point(1123, 82);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(269, 70);
            this.btnIn.TabIndex = 201;
            this.btnIn.Text = "Акт техстану приймання";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnInGeneral
            // 
            this.btnInGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInGeneral.Location = new System.Drawing.Point(1123, 310);
            this.btnInGeneral.Name = "btnInGeneral";
            this.btnInGeneral.Size = new System.Drawing.Size(269, 70);
            this.btnInGeneral.TabIndex = 203;
            this.btnInGeneral.Text = "Відомість надходження ОВТ";
            this.btnInGeneral.UseVisualStyleBackColor = true;
            this.btnInGeneral.Click += new System.EventHandler(this.btnInGeneral_Click);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOut.Location = new System.Drawing.Point(1123, 158);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(269, 70);
            this.btnOut.TabIndex = 202;
            this.btnOut.Text = "Акт техстану передачі";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(1123, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 70);
            this.button1.TabIndex = 204;
            this.button1.Text = "0-й шаблон";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInOut
            // 
            this.btnInOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInOut.Location = new System.Drawing.Point(1123, 234);
            this.btnInOut.Name = "btnInOut";
            this.btnInOut.Size = new System.Drawing.Size(269, 70);
            this.btnInOut.TabIndex = 205;
            this.btnInOut.Text = "Акт приймання-передачі";
            this.btnInOut.UseVisualStyleBackColor = true;
            this.btnInOut.Click += new System.EventHandler(this.btnInOut_Click);
            // 
            // boxInfo
            // 
            this.boxInfo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxInfo.Location = new System.Drawing.Point(12, 6);
            this.boxInfo.Multiline = true;
            this.boxInfo.Name = "boxInfo";
            this.boxInfo.ReadOnly = true;
            this.boxInfo.Size = new System.Drawing.Size(1105, 146);
            this.boxInfo.TabIndex = 206;
            // 
            // boxAct
            // 
            this.boxAct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxAct.Location = new System.Drawing.Point(12, 173);
            this.boxAct.Name = "boxAct";
            this.boxAct.PlaceholderText = "Поч № акту";
            this.boxAct.Size = new System.Drawing.Size(139, 39);
            this.boxAct.TabIndex = 207;
            this.boxAct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // boxOrder
            // 
            this.boxOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOrder.Location = new System.Drawing.Point(299, 173);
            this.boxOrder.Name = "boxOrder";
            this.boxOrder.PlaceholderText = "Наряд ком. А0222 №2780 від 02.11.22";
            this.boxOrder.Size = new System.Drawing.Size(425, 39);
            this.boxOrder.TabIndex = 208;
            // 
            // boxUnit
            // 
            this.boxUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxUnit.Location = new System.Drawing.Point(730, 173);
            this.boxUnit.Name = "boxUnit";
            this.boxUnit.PlaceholderText = "в/ч А0222 м. Київ";
            this.boxUnit.Size = new System.Drawing.Size(216, 39);
            this.boxUnit.TabIndex = 209;
            this.boxUnit.Enter += new System.EventHandler(this.boxUnit_Enter);
            // 
            // boxOutDate
            // 
            this.boxOutDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxOutDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxOutDate.Location = new System.Drawing.Point(952, 173);
            this.boxOutDate.Name = "boxOutDate";
            this.boxOutDate.Size = new System.Drawing.Size(165, 39);
            this.boxOutDate.TabIndex = 210;
            // 
            // boxNom
            // 
            this.boxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxNom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNom.Location = new System.Drawing.Point(157, 173);
            this.boxNom.Name = "boxNom";
            this.boxNom.PlaceholderText = "Д2111000Y";
            this.boxNom.Size = new System.Drawing.Size(136, 39);
            this.boxNom.TabIndex = 211;
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 464);
            this.Controls.Add(this.boxNom);
            this.Controls.Add(this.boxOutDate);
            this.Controls.Add(this.boxUnit);
            this.Controls.Add(this.boxOrder);
            this.Controls.Add(this.boxAct);
            this.Controls.Add(this.boxInfo);
            this.Controls.Add(this.btnInOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInGeneral);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnZip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocForm";
            this.Text = "Документи";
            this.Load += new System.EventHandler(this.DocForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnZip;
        private Button btnIn;
        private Button btnInGeneral;
        private Button btnOut;
        private Button button1;
        private Button btnInOut;
        private TextBox boxInfo;
        private TextBox boxAct;
        private TextBox boxOrder;
        private TextBox boxUnit;
        private DateTimePicker boxOutDate;
        private TextBox boxNom;
    }
}