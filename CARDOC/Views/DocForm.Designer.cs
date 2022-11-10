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
            this.boxZip = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.boxIn = new System.Windows.Forms.GroupBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.boxOut = new System.Windows.Forms.GroupBox();
            this.btnInGeneral = new System.Windows.Forms.Button();
            this.boxInGeneral = new System.Windows.Forms.GroupBox();
            this.boxZip.SuspendLayout();
            this.boxIn.SuspendLayout();
            this.boxOut.SuspendLayout();
            this.boxInGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZip
            // 
            this.btnZip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZip.Location = new System.Drawing.Point(769, 33);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(101, 70);
            this.btnZip.TabIndex = 107;
            this.btnZip.Text = "► Створити";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // boxZip
            // 
            this.boxZip.Controls.Add(this.btnZip);
            this.boxZip.Location = new System.Drawing.Point(12, 12);
            this.boxZip.Name = "boxZip";
            this.boxZip.Size = new System.Drawing.Size(891, 126);
            this.boxZip.TabIndex = 108;
            this.boxZip.TabStop = false;
            this.boxZip.Text = "Відомість комплектації ЗІП";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIn.Location = new System.Drawing.Point(769, 33);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(101, 70);
            this.btnIn.TabIndex = 107;
            this.btnIn.Text = "► Створити";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // boxIn
            // 
            this.boxIn.Controls.Add(this.btnIn);
            this.boxIn.Location = new System.Drawing.Point(12, 144);
            this.boxIn.Name = "boxIn";
            this.boxIn.Size = new System.Drawing.Size(891, 126);
            this.boxIn.TabIndex = 109;
            this.boxIn.TabStop = false;
            this.boxIn.Text = "Акт техстану приймання";
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOut.Location = new System.Drawing.Point(769, 33);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(101, 70);
            this.btnOut.TabIndex = 107;
            this.btnOut.Text = "► Створити";
            this.btnOut.UseVisualStyleBackColor = true;
            // 
            // boxOut
            // 
            this.boxOut.Controls.Add(this.btnOut);
            this.boxOut.Location = new System.Drawing.Point(12, 276);
            this.boxOut.Name = "boxOut";
            this.boxOut.Size = new System.Drawing.Size(891, 126);
            this.boxOut.TabIndex = 110;
            this.boxOut.TabStop = false;
            this.boxOut.Text = "Акт техстану передачі";
            // 
            // btnInGeneral
            // 
            this.btnInGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInGeneral.Location = new System.Drawing.Point(769, 33);
            this.btnInGeneral.Name = "btnInGeneral";
            this.btnInGeneral.Size = new System.Drawing.Size(101, 70);
            this.btnInGeneral.TabIndex = 107;
            this.btnInGeneral.Text = "► Створити";
            this.btnInGeneral.UseVisualStyleBackColor = true;
            // 
            // boxInGeneral
            // 
            this.boxInGeneral.Controls.Add(this.btnInGeneral);
            this.boxInGeneral.Location = new System.Drawing.Point(12, 408);
            this.boxInGeneral.Name = "boxInGeneral";
            this.boxInGeneral.Size = new System.Drawing.Size(891, 126);
            this.boxInGeneral.TabIndex = 111;
            this.boxInGeneral.TabStop = false;
            this.boxInGeneral.Text = "Відомість надходження ОВТ";
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 563);
            this.Controls.Add(this.boxInGeneral);
            this.Controls.Add(this.boxOut);
            this.Controls.Add(this.boxIn);
            this.Controls.Add(this.boxZip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocForm";
            this.Text = "Документи";
            this.boxZip.ResumeLayout(false);
            this.boxIn.ResumeLayout(false);
            this.boxOut.ResumeLayout(false);
            this.boxInGeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnZip;
        private GroupBox boxZip;
        private Button btnIn;
        private GroupBox boxIn;
        private Button btnOut;
        private GroupBox boxOut;
        private Button btnInGeneral;
        private GroupBox boxInGeneral;
    }
}