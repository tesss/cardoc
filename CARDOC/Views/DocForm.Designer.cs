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
            this.btnZero = new System.Windows.Forms.Button();
            this.btnInOut = new System.Windows.Forms.Button();
            this.boxActOut = new System.Windows.Forms.TextBox();
            this.boxOrder = new System.Windows.Forms.TextBox();
            this.boxUnit = new System.Windows.Forms.TextBox();
            this.boxOutDate = new System.Windows.Forms.DateTimePicker();
            this.boxNom = new System.Windows.Forms.TextBox();
            this.panelVehicles = new System.Windows.Forms.FlowLayoutPanel();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.boxActIn = new System.Windows.Forms.TextBox();
            this.boxPriceUAH = new System.Windows.Forms.TextBox();
            this.boxH2 = new System.Windows.Forms.TextBox();
            this.boxH1 = new System.Windows.Forms.TextBox();
            this.boxPriceEUR = new System.Windows.Forms.TextBox();
            this.boxPriceUSD = new System.Windows.Forms.TextBox();
            this.boxRateEUR = new System.Windows.Forms.TextBox();
            this.boxRateUSD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnInOutGeneral = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnPrice = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnPriceCalc = new System.Windows.Forms.Button();
            this.boxKi = new System.Windows.Forms.TextBox();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.boxPrimaryPrice = new System.Windows.Forms.CheckBox();
            this.boxWear = new System.Windows.Forms.CheckBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZip
            // 
            this.btnZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZip.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZip.Location = new System.Drawing.Point(1607, 7);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(168, 84);
            this.btnZip.TabIndex = 200;
            this.btnZip.Text = "Відомість комплектації ЗІП";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIn.Location = new System.Drawing.Point(1607, 97);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(168, 84);
            this.btnIn.TabIndex = 201;
            this.btnIn.Text = "Акт техстану приймання";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnInGeneral
            // 
            this.btnInGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInGeneral.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInGeneral.Location = new System.Drawing.Point(1606, 582);
            this.btnInGeneral.Name = "btnInGeneral";
            this.btnInGeneral.Size = new System.Drawing.Size(168, 84);
            this.btnInGeneral.TabIndex = 207;
            this.btnInGeneral.Text = "Відомість надходження ОВТ";
            this.btnInGeneral.UseVisualStyleBackColor = true;
            this.btnInGeneral.Click += new System.EventHandler(this.btnInGeneral_Click);
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOut.Location = new System.Drawing.Point(1607, 187);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(168, 84);
            this.btnOut.TabIndex = 202;
            this.btnOut.Text = "Акт техстану передачі";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnZero
            // 
            this.btnZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZero.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZero.Location = new System.Drawing.Point(1607, 1032);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(168, 84);
            this.btnZero.TabIndex = 211;
            this.btnZero.Text = "0-й шаблон";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInOut
            // 
            this.btnInOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInOut.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInOut.Location = new System.Drawing.Point(1607, 277);
            this.btnInOut.Name = "btnInOut";
            this.btnInOut.Size = new System.Drawing.Size(168, 84);
            this.btnInOut.TabIndex = 203;
            this.btnInOut.Text = "Акт приймання\r\nпередачі";
            this.btnInOut.UseVisualStyleBackColor = true;
            this.btnInOut.Click += new System.EventHandler(this.btnInOut_Click);
            // 
            // boxActOut
            // 
            this.boxActOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxActOut.Location = new System.Drawing.Point(13, 63);
            this.boxActOut.Name = "boxActOut";
            this.boxActOut.PlaceholderText = "Поч № видачі";
            this.boxActOut.Size = new System.Drawing.Size(164, 39);
            this.boxActOut.TabIndex = 216;
            this.boxActOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // boxOrder
            // 
            this.boxOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOrder.Location = new System.Drawing.Point(325, 63);
            this.boxOrder.Name = "boxOrder";
            this.boxOrder.PlaceholderText = "2780 від 02.11.22";
            this.boxOrder.Size = new System.Drawing.Size(223, 39);
            this.boxOrder.TabIndex = 218;
            this.boxOrder.Enter += new System.EventHandler(this.boxOrder_Enter);
            // 
            // boxUnit
            // 
            this.boxUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxUnit.Location = new System.Drawing.Point(554, 63);
            this.boxUnit.Name = "boxUnit";
            this.boxUnit.PlaceholderText = "А0222 м. Київ";
            this.boxUnit.Size = new System.Drawing.Size(608, 39);
            this.boxUnit.TabIndex = 219;
            this.boxUnit.Enter += new System.EventHandler(this.boxUnit_Enter);
            // 
            // boxOutDate
            // 
            this.boxOutDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxOutDate.Location = new System.Drawing.Point(1168, 63);
            this.boxOutDate.Name = "boxOutDate";
            this.boxOutDate.Size = new System.Drawing.Size(192, 39);
            this.boxOutDate.TabIndex = 220;
            // 
            // boxNom
            // 
            this.boxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxNom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNom.Location = new System.Drawing.Point(183, 63);
            this.boxNom.Name = "boxNom";
            this.boxNom.PlaceholderText = "Д2111000Y";
            this.boxNom.Size = new System.Drawing.Size(136, 39);
            this.boxNom.TabIndex = 217;
            this.boxNom.Enter += new System.EventHandler(this.boxNom_Enter);
            // 
            // panelVehicles
            // 
            this.panelVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVehicles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelVehicles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelVehicles.Location = new System.Drawing.Point(12, 214);
            this.panelVehicles.Name = "panelVehicles";
            this.panelVehicles.Size = new System.Drawing.Size(1581, 616);
            this.panelVehicles.TabIndex = 3000;
            this.panelVehicles.WrapContents = false;
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 25;
            this.listFiles.Location = new System.Drawing.Point(13, 862);
            this.listFiles.Name = "listFiles";
            this.listFiles.ScrollAlwaysVisible = true;
            this.listFiles.Size = new System.Drawing.Size(1580, 229);
            this.listFiles.TabIndex = 4000;
            this.listFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseClick);
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            this.listFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseDoubleClick);
            this.listFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseUp);
            // 
            // boxActIn
            // 
            this.boxActIn.AcceptsReturn = true;
            this.boxActIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxActIn.Location = new System.Drawing.Point(13, 7);
            this.boxActIn.Name = "boxActIn";
            this.boxActIn.PlaceholderText = "Поч № прийм";
            this.boxActIn.Size = new System.Drawing.Size(164, 39);
            this.boxActIn.TabIndex = 207;
            this.boxActIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // boxPriceUAH
            // 
            this.boxPriceUAH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(229)))));
            this.boxPriceUAH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPriceUAH.Location = new System.Drawing.Point(937, 7);
            this.boxPriceUAH.Name = "boxPriceUAH";
            this.boxPriceUAH.PlaceholderText = "₴₴₴";
            this.boxPriceUAH.Size = new System.Drawing.Size(225, 39);
            this.boxPriceUAH.TabIndex = 212;
            this.boxPriceUAH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // boxH2
            // 
            this.boxH2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxH2.Location = new System.Drawing.Point(1300, 7);
            this.boxH2.Name = "boxH2";
            this.boxH2.PlaceholderText = "H2";
            this.boxH2.Size = new System.Drawing.Size(60, 39);
            this.boxH2.TabIndex = 215;
            this.boxH2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // boxH1
            // 
            this.boxH1.BackColor = System.Drawing.SystemColors.Window;
            this.boxH1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxH1.Location = new System.Drawing.Point(1234, 7);
            this.boxH1.Name = "boxH1";
            this.boxH1.PlaceholderText = "H1";
            this.boxH1.Size = new System.Drawing.Size(60, 39);
            this.boxH1.TabIndex = 214;
            this.boxH1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // boxPriceEUR
            // 
            this.boxPriceEUR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.boxPriceEUR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPriceEUR.Location = new System.Drawing.Point(554, 7);
            this.boxPriceEUR.Name = "boxPriceEUR";
            this.boxPriceEUR.PlaceholderText = "€€€";
            this.boxPriceEUR.Size = new System.Drawing.Size(239, 39);
            this.boxPriceEUR.TabIndex = 210;
            this.boxPriceEUR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // boxPriceUSD
            // 
            this.boxPriceUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.boxPriceUSD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPriceUSD.Location = new System.Drawing.Point(183, 7);
            this.boxPriceUSD.Name = "boxPriceUSD";
            this.boxPriceUSD.PlaceholderText = "$$$";
            this.boxPriceUSD.Size = new System.Drawing.Size(226, 39);
            this.boxPriceUSD.TabIndex = 208;
            this.boxPriceUSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // boxRateEUR
            // 
            this.boxRateEUR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.boxRateEUR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxRateEUR.Location = new System.Drawing.Point(799, 7);
            this.boxRateEUR.Name = "boxRateEUR";
            this.boxRateEUR.PlaceholderText = "Курс €";
            this.boxRateEUR.Size = new System.Drawing.Size(132, 39);
            this.boxRateEUR.TabIndex = 211;
            this.boxRateEUR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // boxRateUSD
            // 
            this.boxRateUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.boxRateUSD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxRateUSD.Location = new System.Drawing.Point(415, 7);
            this.boxRateUSD.Name = "boxRateUSD";
            this.boxRateUSD.PlaceholderText = "Курс $";
            this.boxRateUSD.Size = new System.Drawing.Size(132, 39);
            this.boxRateUSD.TabIndex = 209;
            this.boxRateUSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleDecimal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 1023;
            this.label1.Text = "№";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 1024;
            this.label2.Text = "Модель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 25);
            this.label3.TabIndex = 1025;
            this.label3.Text = "VIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 1026;
            this.label4.Text = "Акт прий";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(639, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 1027;
            this.label5.Text = "Акт перед";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(745, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 25);
            this.label6.TabIndex = 1028;
            this.label6.Text = "Номенклатура";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(889, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 25);
            this.label7.TabIndex = 1029;
            this.label7.Text = "МОУ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(976, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 25);
            this.label8.TabIndex = 1030;
            this.label8.Text = "USD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1084, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 25);
            this.label9.TabIndex = 1031;
            this.label9.Text = "EUR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1192, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 25);
            this.label10.TabIndex = 1032;
            this.label10.Text = "UAH";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1300, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 25);
            this.label11.TabIndex = 1033;
            this.label11.Text = "H1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1364, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 25);
            this.label12.TabIndex = 1034;
            this.label12.Text = "H2";
            // 
            // btnInOutGeneral
            // 
            this.btnInOutGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInOutGeneral.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInOutGeneral.Location = new System.Drawing.Point(1606, 402);
            this.btnInOutGeneral.Name = "btnInOutGeneral";
            this.btnInOutGeneral.Size = new System.Drawing.Size(168, 84);
            this.btnInOutGeneral.TabIndex = 205;
            this.btnInOutGeneral.Text = "Акт основних\r\nзасобів";
            this.btnInOutGeneral.UseVisualStyleBackColor = true;
            this.btnInOutGeneral.Click += new System.EventHandler(this.btnInOutGeneral_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(1500, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 84);
            this.btnUpdate.TabIndex = 220;
            this.btnUpdate.Text = "Оновити\r\n↓";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnPrice
            // 
            this.btnPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrice.Location = new System.Drawing.Point(1606, 672);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(168, 84);
            this.btnPrice.TabIndex = 208;
            this.btnPrice.Text = "Відомість визначення вартості";
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneral.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGeneral.Location = new System.Drawing.Point(1607, 852);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(168, 84);
            this.btnGeneral.TabIndex = 210;
            this.btnGeneral.Text = "Загальна відомість";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnPriceCalc
            // 
            this.btnPriceCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPriceCalc.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPriceCalc.Location = new System.Drawing.Point(1607, 762);
            this.btnPriceCalc.Name = "btnPriceCalc";
            this.btnPriceCalc.Size = new System.Drawing.Size(168, 84);
            this.btnPriceCalc.TabIndex = 209;
            this.btnPriceCalc.Text = "Визначення вартості з коефіцієнтами";
            this.btnPriceCalc.UseVisualStyleBackColor = true;
            this.btnPriceCalc.Click += new System.EventHandler(this.btnPriceCalc_click);
            // 
            // boxKi
            // 
            this.boxKi.BackColor = System.Drawing.SystemColors.Window;
            this.boxKi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxKi.Location = new System.Drawing.Point(1168, 7);
            this.boxKi.Name = "boxKi";
            this.boxKi.PlaceholderText = "Ki";
            this.boxKi.Size = new System.Drawing.Size(60, 39);
            this.boxKi.TabIndex = 213;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInvoice.Location = new System.Drawing.Point(1607, 492);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(168, 84);
            this.btnInvoice.TabIndex = 206;
            this.btnInvoice.Text = "Накладна";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // boxPrimaryPrice
            // 
            this.boxPrimaryPrice.AutoSize = true;
            this.boxPrimaryPrice.Location = new System.Drawing.Point(18, 125);
            this.boxPrimaryPrice.Name = "boxPrimaryPrice";
            this.boxPrimaryPrice.Size = new System.Drawing.Size(159, 29);
            this.boxPrimaryPrice.TabIndex = 221;
            this.boxPrimaryPrice.Text = "Первинна ціна";
            this.boxPrimaryPrice.UseVisualStyleBackColor = true;
            // 
            // boxWear
            // 
            this.boxWear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxWear.AutoSize = true;
            this.boxWear.Location = new System.Drawing.Point(1606, 367);
            this.boxWear.Name = "boxWear";
            this.boxWear.Size = new System.Drawing.Size(77, 29);
            this.boxWear.TabIndex = 204;
            this.boxWear.Text = "Знос";
            this.boxWear.UseVisualStyleBackColor = true;
            // 
            // btnReg
            // 
            this.btnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReg.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReg.Location = new System.Drawing.Point(1607, 942);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(168, 84);
            this.btnReg.TabIndex = 4001;
            this.btnReg.Text = "Заява ВІБДР";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1786, 1127);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.boxWear);
            this.Controls.Add(this.boxPrimaryPrice);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.boxKi);
            this.Controls.Add(this.btnPriceCalc);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.btnPrice);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInOutGeneral);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxRateEUR);
            this.Controls.Add(this.boxRateUSD);
            this.Controls.Add(this.boxPriceUAH);
            this.Controls.Add(this.boxH2);
            this.Controls.Add(this.boxH1);
            this.Controls.Add(this.boxPriceEUR);
            this.Controls.Add(this.boxPriceUSD);
            this.Controls.Add(this.boxActIn);
            this.Controls.Add(this.panelVehicles);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.boxNom);
            this.Controls.Add(this.boxOutDate);
            this.Controls.Add(this.boxUnit);
            this.Controls.Add(this.boxOrder);
            this.Controls.Add(this.boxActOut);
            this.Controls.Add(this.btnInOut);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnInGeneral);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnZip);
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
        private Button btnZero;
        private Button btnInOut;
        private TextBox boxActOut;
        private TextBox boxOrder;
        private TextBox boxUnit;
        private DateTimePicker boxOutDate;
        private TextBox boxNom;
        public FlowLayoutPanel panelVehicles;
        private ListBox listFiles;
        private TextBox boxActIn;
        private TextBox boxPriceUAH;
        private TextBox boxH2;
        private TextBox boxH1;
        private TextBox boxPriceEUR;
        private TextBox boxPriceUSD;
        private TextBox boxRateEUR;
        private TextBox boxRateUSD;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button btnInOutGeneral;
        private Button btnUpdate;
        private Button btnPrice;
        private Button btnGeneral;
        private Button btnPriceCalc;
        private TextBox boxKi;
        private Button btnInvoice;
        private CheckBox boxPrimaryPrice;
        private CheckBox boxWear;
        private Button btnReg;
    }
}