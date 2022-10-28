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
            this.boxQuantity = new System.Windows.Forms.TextBox();
            this.boxUnits = new CARDOC.Views.CustomComboBox();
            this.boxType = new CARDOC.Views.CustomComboBox();
            this.boxNotes = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boxName
            // 
            this.boxName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxName.FormattingEnabled = true;
            this.boxName.Hint = "ОБЛАДНАННЯ";
            this.boxName.Location = new System.Drawing.Point(45, 5);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(454, 40);
            this.boxName.TabIndex = 20;
            this.boxName.SelectedIndexChanged += new System.EventHandler(this.boxName_SelectedIndexChanged);
            this.boxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxName_KeyPress);
            this.boxName.Validating += new System.ComponentModel.CancelEventHandler(this.boxName_Validating);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.Location = new System.Drawing.Point(1144, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 48);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "⨯";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // boxQuantity
            // 
            this.boxQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxQuantity.Location = new System.Drawing.Point(525, 5);
            this.boxQuantity.Name = "boxQuantity";
            this.boxQuantity.PlaceholderText = "К-ТЬ";
            this.boxQuantity.Size = new System.Drawing.Size(65, 39);
            this.boxQuantity.TabIndex = 21;
            this.boxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxQuantity_KeyPress);
            this.boxQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.boxQuantity_Validating);
            // 
            // boxUnits
            // 
            this.boxUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxUnits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxUnits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxUnits.FormattingEnabled = true;
            this.boxUnits.Hint = "ОД";
            this.boxUnits.Location = new System.Drawing.Point(616, 5);
            this.boxUnits.Name = "boxUnits";
            this.boxUnits.Size = new System.Drawing.Size(62, 40);
            this.boxUnits.TabIndex = 22;
            this.boxUnits.Validating += new System.ComponentModel.CancelEventHandler(this.boxUnits_Validating);
            // 
            // boxType
            // 
            this.boxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxType.FormattingEnabled = true;
            this.boxType.Hint = "ТИП";
            this.boxType.Location = new System.Drawing.Point(704, 5);
            this.boxType.Name = "boxType";
            this.boxType.Size = new System.Drawing.Size(119, 40);
            this.boxType.TabIndex = 23;
            this.boxType.Validating += new System.ComponentModel.CancelEventHandler(this.boxType_Validating);
            this.boxType.TextChanged += new System.EventHandler(this.boxType_TextChanged);
            // 
            // boxNotes
            // 
            this.boxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxNotes.Location = new System.Drawing.Point(849, 6);
            this.boxNotes.Name = "boxNotes";
            this.boxNotes.PlaceholderText = "ПРИМІТКИ";
            this.boxNotes.Size = new System.Drawing.Size(261, 39);
            this.boxNotes.TabIndex = 24;
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
            // 
            // Part
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.boxNotes);
            this.Controls.Add(this.boxType);
            this.Controls.Add(this.boxUnits);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.boxQuantity);
            this.Name = "Part";
            this.Size = new System.Drawing.Size(1214, 48);
            this.Load += new System.EventHandler(this.Part_Load);

            this.lblIndex.DragDrop += new System.Windows.Forms.DragEventHandler(this.PopulateDragDrop);
            this.lblIndex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopulateMouseDown);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomComboBox boxName;
        private Button btnRemove;
        private TextBox boxQuantity;
        private CustomComboBox boxUnits;
        private CustomComboBox boxType;
        private TextBox boxNotes;
        private Label lblIndex;
    }
}
