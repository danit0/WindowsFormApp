namespace WindowsFormsAppProjekt
{
    partial class startform
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startform));
            System.Windows.Forms.Button info;
            System.Windows.Forms.Button klienti;
            label1 = new System.Windows.Forms.Label();
            info = new System.Windows.Forms.Button();
            klienti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.SystemColors.Control;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Cursor = System.Windows.Forms.Cursors.Default;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Name = "label1";
            label1.UseMnemonic = false;
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // info
            // 
            resources.ApplyResources(info, "info");
            info.Cursor = System.Windows.Forms.Cursors.Default;
            info.Name = "info";
            info.UseMnemonic = false;
            info.UseVisualStyleBackColor = true;
            info.Click += new System.EventHandler(this.info_Click);
            // 
            // klienti
            // 
            resources.ApplyResources(klienti, "klienti");
            klienti.Cursor = System.Windows.Forms.Cursors.Default;
            klienti.Name = "klienti";
            klienti.UseVisualStyleBackColor = true;
            klienti.Click += new System.EventHandler(this.Klienti_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = global::WindowsFormsAppProjekt.Properties.Resources.preview_62928VWhv2ri94T_0012;
            this.Controls.Add(klienti);
            this.Controls.Add(info);
            this.Controls.Add(label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

