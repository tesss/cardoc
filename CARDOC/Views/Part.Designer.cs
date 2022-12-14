using System.ComponentModel;

namespace CARDOC.Views
{
    partial class Part
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
            this.boxName = new CARDOC.Views.CustomComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.boxUnits = new CARDOC.Views.CustomComboBox();
            this.boxType = new CARDOC.Views.CustomComboBox();
            this.boxNotes = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.boxQuantity = new System.Windows.Forms.NumericUpDown();
            this.boxNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // boxName
            // 
            this.boxName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxName.FormattingEnabled = true;
            this.boxName.Hint = "";
            this.boxName.Location = new System.Drawing.Point(45, 4);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(472, 40);
            this.boxName.TabIndex = 20;
            this.boxName.SelectedIndexChanged += new System.EventHandler(this.boxName_SelectedIndexChanged);
            this.boxName.Enter += new System.EventHandler(this.boxName_Enter);
            this.boxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxName_KeyPress);
            this.boxName.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.boxName.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            this.boxName.Validating += new System.ComponentModel.CancelEventHandler(this.boxName_Validating);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(1058, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 47);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "x";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnRemove.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.btnRemove.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            // 
            // boxUnits
            // 
            this.boxUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxUnits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxUnits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxUnits.FormattingEnabled = true;
            this.boxUnits.Hint = "Од";
            this.boxUnits.Location = new System.Drawing.Point(594, 4);
            this.boxUnits.Name = "boxUnits";
            this.boxUnits.Size = new System.Drawing.Size(98, 40);
            this.boxUnits.TabIndex = 22;
            this.boxUnits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxUnits_KeyPress);
            this.boxUnits.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.boxUnits.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            this.boxUnits.Validating += new System.ComponentModel.CancelEventHandler(this.boxUnits_Validating);
            // 
            // boxType
            // 
            this.boxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxType.FormattingEnabled = true;
            this.boxType.Hint = "Тип";
            this.boxType.Location = new System.Drawing.Point(698, 4);
            this.boxType.Name = "boxType";
            this.boxType.Size = new System.Drawing.Size(116, 40);
            this.boxType.TabIndex = 23;
            this.boxType.TextChanged += new System.EventHandler(this.boxType_TextChanged);
            this.boxType.Enter += new System.EventHandler(this.boxType_Enter);
            this.boxType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxType_KeyPress);
            this.boxType.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.boxType.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            this.boxType.Validating += new System.ComponentModel.CancelEventHandler(this.boxType_Validating);
            // 
            // boxNotes
            // 
            this.boxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNotes.Location = new System.Drawing.Point(963, 5);
            this.boxNotes.Name = "boxNotes";
            this.boxNotes.Size = new System.Drawing.Size(89, 39);
            this.boxNotes.TabIndex = 25;
            this.boxNotes.Enter += new System.EventHandler(this.boxNotes_Enter);
            this.boxNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxNotes_KeyPress);
            this.boxNotes.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.boxNotes.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            // 
            // lblIndex
            // 
            this.lblIndex.AllowDrop = true;
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIndex.Location = new System.Drawing.Point(0, 8);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(0, 32);
            this.lblIndex.TabIndex = 26;
            this.lblIndex.DragDrop += new System.Windows.Forms.DragEventHandler(this.PopulateDragDrop);
            this.lblIndex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopulateMouseDown);
            this.lblIndex.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.lblIndex.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            // 
            // boxQuantity
            // 
            this.boxQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxQuantity.Location = new System.Drawing.Point(523, 5);
            this.boxQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.boxQuantity.Name = "boxQuantity";
            this.boxQuantity.Size = new System.Drawing.Size(65, 39);
            this.boxQuantity.TabIndex = 21;
            this.boxQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxQuantity.ValueChanged += new System.EventHandler(this.boxQuantity_ValueChanged);
            this.boxQuantity.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.boxQuantity.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            this.boxQuantity.Enter += new System.EventHandler(this.boxQuantity_Enter);
            this.boxQuantity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boxQuantity_MouseDown);
            // 
            // boxNumber
            // 
            this.boxNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNumber.Location = new System.Drawing.Point(820, 5);
            this.boxNumber.Name = "boxNumber";
            this.boxNumber.Size = new System.Drawing.Size(137, 39);
            this.boxNumber.TabIndex = 24;
            this.boxNumber.Enter += new System.EventHandler(this.boxNumber_Enter);
            this.boxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxNumber_KeyPress);
            this.boxNumber.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.boxNumber.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            // 
            // Part
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.boxNumber);
            this.Controls.Add(this.boxQuantity);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.boxNotes);
            this.Controls.Add(this.boxType);
            this.Controls.Add(this.boxUnits);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.btnRemove);
            this.Name = "Part";
            this.Size = new System.Drawing.Size(1128, 47);
            this.Load += new System.EventHandler(this.Part_Load);
            this.Leave += new System.EventHandler(this.Part_Leave);
            this.MouseEnter += new System.EventHandler(this.Part_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Part_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.boxQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomComboBox boxName;
        private Button btnRemove;
        private CustomComboBox boxUnits;
        private CustomComboBox boxType;
        private TextBox boxNotes;
        private Label lblIndex;
        private NumericUpDown boxQuantity;
        private TextBox boxNumber;
    }
}
