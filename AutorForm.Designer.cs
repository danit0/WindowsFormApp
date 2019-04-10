namespace WindowsFormsAppProjekt
{
    partial class AutorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutorForm));
            this.създател = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // създател
            // 
            this.създател.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.създател.AutoSize = true;
            this.създател.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.създател.Location = new System.Drawing.Point(12, 19);
            this.създател.Name = "създател";
            this.създател.Size = new System.Drawing.Size(685, 290);
            this.създател.TabIndex = 0;
            this.създател.Text = resources.GetString("създател.Text");
            this.създател.Click += new System.EventHandler(this.създател_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 318);
            this.Controls.Add(this.създател);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.Text = "Автор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label създател;
    }
}