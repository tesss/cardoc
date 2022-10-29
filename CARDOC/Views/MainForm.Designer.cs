﻿using CARDOC.Views;

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
            this.btnToday = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // listHistory
            // 
            this.listHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listHistory.CheckBoxes = true;
            this.listHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listHistory.FullRowSelect = true;
            this.listHistory.Location = new System.Drawing.Point(12, 12);
            this.listHistory.MultiSelect = false;
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(1107, 384);
            this.listHistory.TabIndex = 0;
            this.listHistory.UseCompatibleStateImageBehavior = false;
            this.listHistory.View = System.Windows.Forms.View.Details;
            this.listHistory.SelectedIndexChanged += new System.EventHandler(this.listHistory_SelectedIndexChanged);
            // 
            // boxFilterDate
            // 
            this.boxFilterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxFilterDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxFilterDate.Location = new System.Drawing.Point(1138, 15);
            this.boxFilterDate.Name = "boxFilterDate";
            this.boxFilterDate.Size = new System.Drawing.Size(138, 39);
            this.boxFilterDate.TabIndex = 104;
            this.boxFilterDate.ValueChanged += new System.EventHandler(this.boxFilterDate_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(1137, 171);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 50);
            this.btnAdd.TabIndex = 101;
            this.btnAdd.Text = "➕ Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuplicate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDuplicate.Location = new System.Drawing.Point(1138, 241);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(137, 50);
            this.btnDuplicate.TabIndex = 102;
            this.btnDuplicate.Text = "⧉ Копіювати";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.Location = new System.Drawing.Point(1138, 311);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(137, 50);
            this.btnRemove.TabIndex = 103;
            this.btnRemove.Text = "➖ Видалити";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnToday
            // 
            this.btnToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToday.Location = new System.Drawing.Point(1138, 81);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(138, 50);
            this.btnToday.TabIndex = 105;
            this.btnToday.Text = "🗓 Сьогодні";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // boxVin
            // 
            this.boxVin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxVin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.boxVin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxVin.Location = new System.Drawing.Point(14, 527);
            this.boxVin.Name = "boxVin";
            this.boxVin.PlaceholderText = "VIN";
            this.boxVin.Size = new System.Drawing.Size(952, 39);
            this.boxVin.TabIndex = 5;
            this.boxVin.Validating += new System.ComponentModel.CancelEventHandler(this.boxVin_Validating);
            // 
            // boxDate
            // 
            this.boxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.boxDate.Location = new System.Drawing.Point(984, 474);
            this.boxDate.Name = "boxDate";
            this.boxDate.Size = new System.Drawing.Size(134, 39);
            this.boxDate.TabIndex = 4;
            // 
            // boxMileageK
            // 
            this.boxMileageK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMileageK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMileageK.Location = new System.Drawing.Point(678, 575);
            this.boxMileageK.Name = "boxMileageK";
            this.boxMileageK.PlaceholderText = "Пробіг км";
            this.boxMileageK.Size = new System.Drawing.Size(133, 39);
            this.boxMileageK.TabIndex = 8;
            this.boxMileageK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMileageK_KeyPress);
            this.boxMileageK.Validating += new System.ComponentModel.CancelEventHandler(this.boxMileageK_Validating);
            // 
            // boxMileageM
            // 
            this.boxMileageM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMileageM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMileageM.Location = new System.Drawing.Point(832, 575);
            this.boxMileageM.Name = "boxMileageM";
            this.boxMileageM.PlaceholderText = "Пробіг м";
            this.boxMileageM.Size = new System.Drawing.Size(133, 39);
            this.boxMileageM.TabIndex = 9;
            this.boxMileageM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMileageM_KeyPress);
            this.boxMileageM.Validating += new System.ComponentModel.CancelEventHandler(this.boxMileageM_Validating);
            // 
            // boxMileageH
            // 
            this.boxMileageH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMileageH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxMileageH.Location = new System.Drawing.Point(985, 575);
            this.boxMileageH.Name = "boxMileageH";
            this.boxMileageH.PlaceholderText = "Пробіг год";
            this.boxMileageH.Size = new System.Drawing.Size(133, 39);
            this.boxMileageH.TabIndex = 10;
            this.boxMileageH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxMileageH_KeyPress);
            this.boxMileageH.Validating += new System.ComponentModel.CancelEventHandler(this.boxMileageH_Validating);
            // 
            // boxNotes
            // 
            this.boxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNotes.Location = new System.Drawing.Point(13, 626);
            this.boxNotes.Name = "boxNotes";
            this.boxNotes.PlaceholderText = "Примітки";
            this.boxNotes.Size = new System.Drawing.Size(1107, 39);
            this.boxNotes.TabIndex = 11;
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
            this.boxManufacturer.Location = new System.Drawing.Point(14, 420);
            this.boxManufacturer.Name = "boxManufacturer";
            this.boxManufacturer.Size = new System.Drawing.Size(226, 40);
            this.boxManufacturer.TabIndex = 1;
            this.boxManufacturer.SelectedIndexChanged += new System.EventHandler(this.boxManufacturer_SelectedIndexChanged);
            this.boxManufacturer.TextChanged += new System.EventHandler(this.boxManufacturer_TextChanged);
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
            this.boxModel.Location = new System.Drawing.Point(262, 420);
            this.boxModel.Name = "boxModel";
            this.boxModel.Size = new System.Drawing.Size(858, 40);
            this.boxModel.TabIndex = 2;
            this.boxModel.SelectedIndexChanged += new System.EventHandler(this.boxModel_SelectedIndexChanged);
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
            this.boxYear.Location = new System.Drawing.Point(985, 526);
            this.boxYear.Name = "boxYear";
            this.boxYear.Size = new System.Drawing.Size(135, 40);
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
            this.boxColor.Location = new System.Drawing.Point(13, 574);
            this.boxColor.Name = "boxColor";
            this.boxColor.Size = new System.Drawing.Size(642, 40);
            this.boxColor.TabIndex = 7;
            this.boxColor.Validating += new System.ComponentModel.CancelEventHandler(this.boxColor_Validating);
            // 
            // panelParts
            // 
            this.panelParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParts.AutoScroll = true;
            this.panelParts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelParts.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelParts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelParts.Location = new System.Drawing.Point(13, 709);
            this.panelParts.Name = "panelParts";
            this.panelParts.Size = new System.Drawing.Size(1263, 285);
            this.panelParts.TabIndex = 33;
            this.panelParts.WrapContents = false;
            this.panelParts.Paint += new System.Windows.Forms.PaintEventHandler(this.panelParts_Paint);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line1.Location = new System.Drawing.Point(14, 688);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1264, 2);
            this.line1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1139, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 191);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "🖬 Зберегти";
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
            this.boxType.Location = new System.Drawing.Point(14, 474);
            this.boxType.Name = "boxType";
            this.boxType.Size = new System.Drawing.Size(952, 40);
            this.boxType.TabIndex = 3;
            this.boxType.Validating += new System.ComponentModel.CancelEventHandler(this.boxType_Validating);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTemplate.Location = new System.Drawing.Point(1138, 420);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(138, 40);
            this.btnTemplate.TabIndex = 106;
            this.btnTemplate.Text = "★ Шаблон";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 1006);
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
            this.Controls.Add(this.btnToday);
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
        private Button btnToday;
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
        private FlowLayoutPanel panelParts;
        private Label line1;
        public Button btnSave;
        private CustomComboBox boxType;
        private Button btnTemplate;
    }
}