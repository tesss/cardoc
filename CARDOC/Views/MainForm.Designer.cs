using CARDOC.Views;

namespace CARDOC
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listHistory = new System.Windows.Forms.ListView();
            this.boxFilterDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.boxVin = new System.Windows.Forms.TextBox();
            this.boxDate = new System.Windows.Forms.DateTimePicker();
            this.boxMileageK = new System.Windows.Forms.TextBox();
            this.boxMileageM = new System.Windows.Forms.TextBox();
            this.boxMileageH = new System.Windows.Forms.TextBox();
            this.boxNotes = new System.Windows.Forms.TextBox();
            this.boxManufacturer = new CARDOC.Views.CustomComboBox();
            this.boxModel = new CARDOC.Views.CustomComboBox();
            this.boxYear = new CARDOC.Views.CustomComboBox();
            this.boxColor = new CARDOC.Views.CustomComboBox();
            this.panelParts = new System.Windows.Forms.FlowLayoutPanel();
            this.line1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.boxType = new CARDOC.Views.CustomComboBox();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.btnDoc = new System.Windows.Forms.Button();
            this.boxMedical = new System.Windows.Forms.CheckBox();
            this.boxRao = new System.Windows.Forms.CheckBox();
            this.boxCommunication = new System.Windows.Forms.CheckBox();
            this.boxAct = new System.Windows.Forms.TextBox();
            this.boxNom = new System.Windows.Forms.TextBox();
            this.boxMou = new System.Windows.Forms.TextBox();
            this.boxOrder = new System.Windows.Forms.TextBox();
            this.boxUnit = new System.Windows.Forms.TextBox();
            this.boxOutDate = new System.Windows.Forms.DateTimePicker();
            this.boxPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listHistory
            // 
            this.listHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listHistory.CheckBoxes = true;
            this.listHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listHistory.FullRowSelect = true;
            this.listHistory.Location = new System.Drawing.Point(12, 0);
            this.listHistory.MultiSelect = false;
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(1032, 384);
            this.listHistory.TabIndex = 0;
            this.listHistory.UseCompatibleStateImageBehavior = false;
            this.listHistory.View = System.Windows.Forms.View.Details;
            this.listHistory.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listHistory_ItemChecked);
            this.listHistory.SelectedIndexChanged += new System.EventHandler(this.listHistory_SelectedIndexChanged);
            // 
            // boxFilterDate
            // 
            this.boxFilterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxFilterDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxFilterDate.Location = new System.Drawing.Point(1052, 0);
            this.boxFilterDate.Name = "boxFilterDate";
            this.boxFilterDate.Size = new System.Drawing.Size(99, 39);
            this.boxFilterDate.TabIndex = 104;
            this.boxFilterDate.ValueChanged += new System.EventHandler(this.boxFilterDate_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(1052, 235);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 92);
            this.btnAdd.TabIndex = 101;
            this.btnAdd.Text = "+ \r\nДодати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuplicate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDuplicate.Location = new System.Drawing.Point(12, 0);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(100, 70);
            this.btnDuplicate.TabIndex = 102;
            this.btnDuplicate.Text = "║ \r\nКопія";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Visible = false;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(1052, 333);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 51);
            this.btnRemove.TabIndex = 103;
            this.btnRemove.Text = "―\r\n";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // boxVin
            // 
            this.boxVin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxVin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxVin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxVin.Location = new System.Drawing.Point(12, 510);
            this.boxVin.Name = "boxVin";
            this.boxVin.PlaceholderText = "VIN";
            this.boxVin.Size = new System.Drawing.Size(900, 39);
            this.boxVin.TabIndex = 5;
            this.boxVin.Enter += new System.EventHandler(this.boxVin_Enter);
            this.boxVin.Validating += new System.ComponentModel.CancelEventHandler(this.boxVin_Validating);
            // 
            // boxDate
            // 
            this.boxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxDate.Location = new System.Drawing.Point(918, 460);
            this.boxDate.Name = "boxDate";
            this.boxDate.Size = new System.Drawing.Size(126, 39);
            this.boxDate.TabIndex = 4;
            // 
            // boxMileageK
            // 
            this.boxMileageK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMileageK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMileageK.Location = new System.Drawing.Point(653, 560);
            this.boxMileageK.Name = "boxMileageK";
            this.boxMileageK.PlaceholderText = "Кілометри";
            this.boxMileageK.Size = new System.Drawing.Size(126, 39);
            this.boxMileageK.TabIndex = 8;
            this.boxMileageK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectAll);
            this.boxMileageK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMileageK_KeyPress);
            this.boxMileageK.Validating += new System.ComponentModel.CancelEventHandler(this.boxMileageK_Validating);
            // 
            // boxMileageM
            // 
            this.boxMileageM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMileageM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMileageM.Location = new System.Drawing.Point(789, 560);
            this.boxMileageM.Name = "boxMileageM";
            this.boxMileageM.PlaceholderText = "Милі";
            this.boxMileageM.Size = new System.Drawing.Size(123, 39);
            this.boxMileageM.TabIndex = 9;
            this.boxMileageM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectAll);
            this.boxMileageM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMileageM_KeyPress);
            this.boxMileageM.Validating += new System.ComponentModel.CancelEventHandler(this.boxMileageM_Validating);
            // 
            // boxMileageH
            // 
            this.boxMileageH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMileageH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMileageH.Location = new System.Drawing.Point(918, 560);
            this.boxMileageH.Name = "boxMileageH";
            this.boxMileageH.PlaceholderText = "Мото/год";
            this.boxMileageH.Size = new System.Drawing.Size(126, 39);
            this.boxMileageH.TabIndex = 10;
            this.boxMileageH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMileageH_KeyPress);
            this.boxMileageH.Validating += new System.ComponentModel.CancelEventHandler(this.boxMileageH_Validating);
            // 
            // boxNotes
            // 
            this.boxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNotes.Location = new System.Drawing.Point(12, 610);
            this.boxNotes.Name = "boxNotes";
            this.boxNotes.PlaceholderText = "Примітки";
            this.boxNotes.Size = new System.Drawing.Size(635, 39);
            this.boxNotes.TabIndex = 11;
            this.boxNotes.Enter += new System.EventHandler(this.boxNotes_Enter);
            // 
            // boxManufacturer
            // 
            this.boxManufacturer.AutoCompleteCustomSource.AddRange(new string[] {
            "PEUGEOUT",
            "RENAULT",
            "HMMWV"});
            this.boxManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxManufacturer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxManufacturer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxManufacturer.FormattingEnabled = true;
            this.boxManufacturer.Hint = "Виробник";
            this.boxManufacturer.Location = new System.Drawing.Point(12, 408);
            this.boxManufacturer.Name = "boxManufacturer";
            this.boxManufacturer.Size = new System.Drawing.Size(256, 40);
            this.boxManufacturer.TabIndex = 1;
            this.boxManufacturer.SelectedIndexChanged += new System.EventHandler(this.boxManufacturer_SelectedIndexChanged);
            this.boxManufacturer.TextChanged += new System.EventHandler(this.boxManufacturer_TextChanged);
            this.boxManufacturer.Enter += new System.EventHandler(this.boxManufacturer_Enter);
            this.boxManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Upper);
            this.boxManufacturer.Validating += new System.ComponentModel.CancelEventHandler(this.boxManufacturer_Validating);
            // 
            // boxModel
            // 
            this.boxModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxModel.AutoCompleteCustomSource.AddRange(new string[] {
            "PEUGEOUT",
            "RENAULT",
            "HMMWV"});
            this.boxModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxModel.FormattingEnabled = true;
            this.boxModel.Hint = "Модель";
            this.boxModel.Location = new System.Drawing.Point(274, 408);
            this.boxModel.Name = "boxModel";
            this.boxModel.Size = new System.Drawing.Size(770, 40);
            this.boxModel.TabIndex = 2;
            this.boxModel.SelectedIndexChanged += new System.EventHandler(this.boxModel_SelectedIndexChanged);
            this.boxModel.Enter += new System.EventHandler(this.boxModel_Enter);
            this.boxModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Upper);
            this.boxModel.Validating += new System.ComponentModel.CancelEventHandler(this.boxModel_Validating);
            // 
            // boxYear
            // 
            this.boxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxYear.AutoCompleteCustomSource.AddRange(new string[] {
            "1970",
            "1971"});
            this.boxYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxYear.FormattingEnabled = true;
            this.boxYear.Hint = "Рік";
            this.boxYear.Location = new System.Drawing.Point(918, 509);
            this.boxYear.Name = "boxYear";
            this.boxYear.Size = new System.Drawing.Size(126, 40);
            this.boxYear.TabIndex = 6;
            this.boxYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxYear_KeyPress);
            this.boxYear.Validating += new System.ComponentModel.CancelEventHandler(this.boxYear_Validating);
            // 
            // boxColor
            // 
            this.boxColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxColor.AutoCompleteCustomSource.AddRange(new string[] {
            "PEUGEOUT",
            "RENAULT",
            "HMMWV"});
            this.boxColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxColor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxColor.FormattingEnabled = true;
            this.boxColor.Hint = "Колір";
            this.boxColor.Location = new System.Drawing.Point(12, 560);
            this.boxColor.Name = "boxColor";
            this.boxColor.Size = new System.Drawing.Size(635, 40);
            this.boxColor.TabIndex = 7;
            this.boxColor.Enter += new System.EventHandler(this.boxColor_Enter);
            this.boxColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Lower);
            this.boxColor.Validating += new System.ComponentModel.CancelEventHandler(this.boxColor_Validating);
            // 
            // panelParts
            // 
            this.panelParts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelParts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelParts.Location = new System.Drawing.Point(0, 730);
            this.panelParts.Name = "panelParts";
            this.panelParts.Size = new System.Drawing.Size(1288, 276);
            this.panelParts.TabIndex = 33;
            this.panelParts.WrapContents = false;
            this.panelParts.Paint += new System.Windows.Forms.PaintEventHandler(this.panelParts_Paint);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line1.Location = new System.Drawing.Point(0, 725);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1288, 2);
            this.line1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1050, 560);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 144);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "▼ Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // boxType
            // 
            this.boxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxType.AutoCompleteCustomSource.AddRange(new string[] {
            "PEUGEOUT",
            "RENAULT",
            "HMMWV"});
            this.boxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxType.FormattingEnabled = true;
            this.boxType.Hint = "Тип транспорту";
            this.boxType.Location = new System.Drawing.Point(12, 459);
            this.boxType.Name = "boxType";
            this.boxType.Size = new System.Drawing.Size(900, 40);
            this.boxType.TabIndex = 3;
            this.boxType.Enter += new System.EventHandler(this.boxType_Enter);
            this.boxType.Validating += new System.ComponentModel.CancelEventHandler(this.boxType_Validating);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTemplate.Location = new System.Drawing.Point(1052, 407);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(100, 91);
            this.btnTemplate.TabIndex = 106;
            this.btnTemplate.Text = "★ Шаблон";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDoc.Location = new System.Drawing.Point(1052, 45);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(100, 91);
            this.btnDoc.TabIndex = 107;
            this.btnDoc.Text = "▒  Документ";
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // boxMedical
            // 
            this.boxMedical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMedical.AutoSize = true;
            this.boxMedical.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMedical.Location = new System.Drawing.Point(653, 612);
            this.boxMedical.Name = "boxMedical";
            this.boxMedical.Size = new System.Drawing.Size(142, 36);
            this.boxMedical.TabIndex = 12;
            this.boxMedical.Text = "Медична";
            this.boxMedical.UseVisualStyleBackColor = true;
            // 
            // boxRao
            // 
            this.boxRao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxRao.AutoSize = true;
            this.boxRao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxRao.Location = new System.Drawing.Point(928, 612);
            this.boxRao.Name = "boxRao";
            this.boxRao.Size = new System.Drawing.Size(86, 36);
            this.boxRao.TabIndex = 14;
            this.boxRao.Text = "РАО";
            this.boxRao.UseVisualStyleBackColor = true;
            // 
            // boxCommunication
            // 
            this.boxCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxCommunication.AutoSize = true;
            this.boxCommunication.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxCommunication.Location = new System.Drawing.Point(801, 612);
            this.boxCommunication.Name = "boxCommunication";
            this.boxCommunication.Size = new System.Drawing.Size(121, 36);
            this.boxCommunication.TabIndex = 13;
            this.boxCommunication.Text = "Зв\'язок";
            this.boxCommunication.UseVisualStyleBackColor = true;
            // 
            // boxAct
            // 
            this.boxAct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxAct.Location = new System.Drawing.Point(12, 665);
            this.boxAct.Name = "boxAct";
            this.boxAct.PlaceholderText = "№ акту";
            this.boxAct.Size = new System.Drawing.Size(100, 39);
            this.boxAct.TabIndex = 15;
            this.boxAct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxAct_KeyPress);
            // 
            // boxNom
            // 
            this.boxNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxNom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNom.Location = new System.Drawing.Point(118, 665);
            this.boxNom.Name = "boxNom";
            this.boxNom.PlaceholderText = "Д2111000Y";
            this.boxNom.Size = new System.Drawing.Size(194, 39);
            this.boxNom.TabIndex = 16;
            // 
            // boxMou
            // 
            this.boxMou.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMou.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMou.Location = new System.Drawing.Point(591, 665);
            this.boxMou.Name = "boxMou";
            this.boxMou.PlaceholderText = "МОУ №";
            this.boxMou.Size = new System.Drawing.Size(99, 39);
            this.boxMou.TabIndex = 18;
            this.boxMou.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMou_KeyPress);
            // 
            // boxOrder
            // 
            this.boxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOrder.Location = new System.Drawing.Point(318, 665);
            this.boxOrder.Name = "boxOrder";
            this.boxOrder.PlaceholderText = "Наряд ком. А0222 №2780 від 02.11.22";
            this.boxOrder.Size = new System.Drawing.Size(16, 39);
            this.boxOrder.TabIndex = 17;
            // 
            // boxUnit
            // 
            this.boxUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxUnit.Location = new System.Drawing.Point(696, 665);
            this.boxUnit.Name = "boxUnit";
            this.boxUnit.PlaceholderText = "в/ч А0222 м. Київ";
            this.boxUnit.Size = new System.Drawing.Size(216, 39);
            this.boxUnit.TabIndex = 19;
            this.boxUnit.Enter += new System.EventHandler(this.boxUnit_Enter);
            // 
            // boxOutDate
            // 
            this.boxOutDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxOutDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxOutDate.Location = new System.Drawing.Point(918, 665);
            this.boxOutDate.Name = "boxOutDate";
            this.boxOutDate.Size = new System.Drawing.Size(126, 39);
            this.boxOutDate.TabIndex = 20;
            // 
            // boxPrice
            // 
            this.boxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxPrice.Location = new System.Drawing.Point(340, 665);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.PlaceholderText = "Ціна";
            this.boxPrice.Size = new System.Drawing.Size(245, 39);
            this.boxPrice.TabIndex = 110;
            this.boxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPrice_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1288, 1006);
            this.Controls.Add(this.boxPrice);
            this.Controls.Add(this.boxMou);
            this.Controls.Add(this.boxOutDate);
            this.Controls.Add(this.boxUnit);
            this.Controls.Add(this.boxOrder);
            this.Controls.Add(this.boxNom);
            this.Controls.Add(this.boxAct);
            this.Controls.Add(this.boxCommunication);
            this.Controls.Add(this.boxRao);
            this.Controls.Add(this.boxMedical);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.boxType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panelParts);
            this.Controls.Add(this.boxColor);
            this.Controls.Add(this.boxYear);
            this.Controls.Add(this.boxModel);
            this.Controls.Add(this.boxManufacturer);
            this.Controls.Add(this.boxNotes);
            this.Controls.Add(this.boxMileageH);
            this.Controls.Add(this.boxMileageM);
            this.Controls.Add(this.boxMileageK);
            this.Controls.Add(this.boxDate);
            this.Controls.Add(this.boxVin);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.boxFilterDate);
            this.Controls.Add(this.listHistory);
            this.MinimumSize = new System.Drawing.Size(1310, 900);
            this.Name = "MainForm";
            this.Text = "CARDOC 0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listHistory;
        private DateTimePicker boxFilterDate;
        private Button btnAdd;
        private Button btnDuplicate;
        private Button btnRemove;
        private TextBox boxVin;
        private DateTimePicker boxDate;
        private TextBox boxMileageK;
        private TextBox boxMileageM;
        private TextBox boxMileageH;
        private TextBox boxNotes;
        private CustomComboBox boxManufacturer;
        private CustomComboBox boxModel;
        private CustomComboBox boxYear;
        private CustomComboBox boxColor;
        public FlowLayoutPanel panelParts;
        private Label line1;
        public Button btnSave;
        private CustomComboBox boxType;
        private Button btnTemplate;
        private Button btnDoc;
        private CheckBox boxMedical;
        private CheckBox boxRao;
        private CheckBox boxCommunication;
        private TextBox boxAct;
        private TextBox boxNom;
        private TextBox boxMou;
        private TextBox boxOrder;
        private TextBox boxUnit;
        private DateTimePicker boxOutDate;
        private TextBox boxPrice;
    }
}