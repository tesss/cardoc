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
            this.chkDocuments = new System.Windows.Forms.CheckedListBox();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkDocuments
            // 
            this.chkDocuments.CheckOnClick = true;
            this.chkDocuments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkDocuments.FormattingEnabled = true;
            this.chkDocuments.Items.AddRange(new object[] {
            "ЗІП",
            "Акт прийому",
            "Акт передачі",
            "Акт прийому загальний"});
            this.chkDocuments.Location = new System.Drawing.Point(12, 12);
            this.chkDocuments.Name = "chkDocuments";
            this.chkDocuments.Size = new System.Drawing.Size(406, 148);
            this.chkDocuments.TabIndex = 0;
            // 
            // btnTemplate
            // 
            this.btnTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTemplate.Location = new System.Drawing.Point(434, 12);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(138, 148);
            this.btnTemplate.TabIndex = 107;
            this.btnTemplate.Text = "★ Генерувати";
            this.btnTemplate.UseVisualStyleBackColor = true;
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 173);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.chkDocuments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocForm";
            this.Text = "Документи";
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox chkDocuments;
        private Button btnTemplate;
    }
}