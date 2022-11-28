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
            this.boxAct = new System.Windows.Forms.TextBox();
            this.boxOrder = new System.Windows.Forms.TextBox();
            this.boxUnit = new System.Windows.Forms.TextBox();
            this.boxOutDate = new System.Windows.Forms.DateTimePicker();
            this.boxNom = new System.Windows.Forms.TextBox();
            this.panelVehicles = new System.Windows.Forms.FlowLayoutPanel();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZip
            // 
            this.btnZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZip.Location = new System.Drawing.Point(1222, 7);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(168, 70);
            this.btnZip.TabIndex = 200;
            this.btnZip.Text = "Відомість комплектації ЗІП";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIn.Location = new System.Drawing.Point(1222, 83);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(168, 70);
            this.btnIn.TabIndex = 201;
            this.btnIn.Text = "Акт техстану приймання";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnInGeneral
            // 
            this.btnInGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInGeneral.Location = new System.Drawing.Point(1222, 311);
            this.btnInGeneral.Name = "btnInGeneral";
            this.btnInGeneral.Size = new System.Drawing.Size(168, 70);
            this.btnInGeneral.TabIndex = 203;
            this.btnInGeneral.Text = "Відомість надходження ОВТ";
            this.btnInGeneral.UseVisualStyleBackColor = true;
            this.btnInGeneral.Click += new System.EventHandler(this.btnInGeneral_Click);
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOut.Location = new System.Drawing.Point(1222, 159);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(168, 70);
            this.btnOut.TabIndex = 202;
            this.btnOut.Text = "Акт техстану передачі";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(1222, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 70);
            this.button1.TabIndex = 204;
            this.button1.Text = "0-й шаблон";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInOut
            // 
            this.btnInOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInOut.Location = new System.Drawing.Point(1222, 235);
            this.btnInOut.Name = "btnInOut";
            this.btnInOut.Size = new System.Drawing.Size(168, 70);
            this.btnInOut.TabIndex = 205;
            this.btnInOut.Text = "Акт приймання-передачі";
            this.btnInOut.UseVisualStyleBackColor = true;
            this.btnInOut.Click += new System.EventHandler(this.btnInOut_Click);
            // 
            // boxAct
            // 
            this.boxAct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxAct.Location = new System.Drawing.Point(13, 12);
            this.boxAct.Name = "boxAct";
            this.boxAct.PlaceholderText = "Поч № акту";
            this.boxAct.Size = new System.Drawing.Size(139, 39);
            this.boxAct.TabIndex = 207;
            this.boxAct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // boxOrder
            // 
            this.boxOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOrder.Location = new System.Drawing.Point(300, 12);
            this.boxOrder.Name = "boxOrder";
            this.boxOrder.PlaceholderText = "2780 від 02.11.22";
            this.boxOrder.Size = new System.Drawing.Size(230, 39);
            this.boxOrder.TabIndex = 209;
            this.boxOrder.Enter += new System.EventHandler(this.boxOrder_Enter);
            // 
            // boxUnit
            // 
            this.boxUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxUnit.Location = new System.Drawing.Point(536, 12);
            this.boxUnit.Name = "boxUnit";
            this.boxUnit.PlaceholderText = "А0222 м. Київ";
            this.boxUnit.Size = new System.Drawing.Size(322, 39);
            this.boxUnit.TabIndex = 210;
            this.boxUnit.Enter += new System.EventHandler(this.boxUnit_Enter);
            // 
            // boxOutDate
            // 
            this.boxOutDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxOutDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxOutDate.Location = new System.Drawing.Point(864, 12);
            this.boxOutDate.Name = "boxOutDate";
            this.boxOutDate.Size = new System.Drawing.Size(165, 39);
            this.boxOutDate.TabIndex = 211;
            // 
            // boxNom
            // 
            this.boxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxNom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNom.Location = new System.Drawing.Point(158, 12);
            this.boxNom.Name = "boxNom";
            this.boxNom.PlaceholderText = "Д2111000Y";
            this.boxNom.Size = new System.Drawing.Size(136, 39);
            this.boxNom.TabIndex = 208;
            this.boxNom.Enter += new System.EventHandler(this.boxNom_Enter);
            // 
            // panelVehicles
            // 
            this.panelVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVehicles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelVehicles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelVehicles.Location = new System.Drawing.Point(12, 69);
            this.panelVehicles.Name = "panelVehicles";
            this.panelVehicles.Size = new System.Drawing.Size(1191, 495);
            this.panelVehicles.TabIndex = 213;
            this.panelVehicles.WrapContents = false;
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 25;
            this.listFiles.Location = new System.Drawing.Point(13, 573);
            this.listFiles.Name = "listFiles";
            this.listFiles.ScrollAlwaysVisible = true;
            this.listFiles.Size = new System.Drawing.Size(1190, 204);
            this.listFiles.TabIndex = 212;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            this.listFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseDoubleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(1035, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(168, 53);
            this.btnUpdate.TabIndex = 214;
            this.btnUpdate.Text = "Оновити";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1500, 789);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panelVehicles);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.boxNom);
            this.Controls.Add(this.boxOutDate);
            this.Controls.Add(this.boxUnit);
            this.Controls.Add(this.boxOrder);
            this.Controls.Add(this.boxAct);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private TextBox boxAct;
        private TextBox boxOrder;
        private TextBox boxUnit;
        private DateTimePicker boxOutDate;
        private TextBox boxNom;
        public FlowLayoutPanel panelVehicles;
        private ListBox listFiles;
        private Button btnUpdate;
    }
}