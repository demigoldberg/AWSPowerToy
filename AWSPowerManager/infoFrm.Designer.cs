namespace AWSPowerManager
{
    partial class infoFrm
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
            this.InfotextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InfotextBox
            // 
            this.InfotextBox.Location = new System.Drawing.Point(9, 33);
            this.InfotextBox.Multiline = true;
            this.InfotextBox.Name = "InfotextBox";
            this.InfotextBox.Size = new System.Drawing.Size(640, 397);
            this.InfotextBox.TabIndex = 0;
            // 
            // infoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 452);
            this.Controls.Add(this.InfotextBox);
            this.Name = "infoFrm";
            this.Text = "infoFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox InfotextBox;
    }
}