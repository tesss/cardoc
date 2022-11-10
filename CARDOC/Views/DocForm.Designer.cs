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
            this.SuspendLayout();
            // 
            // btnZip
            // 
            this.btnZip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZip.Location = new System.Drawing.Point(31, 26);
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
            this.btnIn.Location = new System.Drawing.Point(306, 26);
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
            this.btnInGeneral.Location = new System.Drawing.Point(306, 102);
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
            this.btnOut.Location = new System.Drawing.Point(31, 102);
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
            this.button1.Location = new System.Drawing.Point(31, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 70);
            this.button1.TabIndex = 204;
            this.button1.Text = "Шаблон приймання";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 281);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInGeneral);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnZip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocForm";
            this.Text = "Шаблон приймання";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnZip;
        private Button btnIn;
        private Button btnInGeneral;
        private Button btnOut;
        private Button button1;
    }
}