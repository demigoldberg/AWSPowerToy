namespace AWSPowerManager
{
    partial class PreferencesFrm
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AccessKeyIDtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SecretAccessKeytextBox = new System.Windows.Forms.TextBox();
            this.sshtoolbutton = new System.Windows.Forms.Button();
            this.sshtoolpathtextBox = new System.Windows.Forms.TextBox();
            this.sshkeypathtextBox = new System.Windows.Forms.TextBox();
            this.sshkeybutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(166, 293);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(128, 23);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(439, 293);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(134, 23);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Access Key ID";
            // 
            // AccessKeyIDtextBox
            // 
            this.AccessKeyIDtextBox.Location = new System.Drawing.Point(31, 42);
            this.AccessKeyIDtextBox.Name = "AccessKeyIDtextBox";
            this.AccessKeyIDtextBox.Size = new System.Drawing.Size(330, 20);
            this.AccessKeyIDtextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Secret access key";
            // 
            // SecretAccessKeytextBox
            // 
            this.SecretAccessKeytextBox.Location = new System.Drawing.Point(31, 101);
            this.SecretAccessKeytextBox.Name = "SecretAccessKeytextBox";
            this.SecretAccessKeytextBox.Size = new System.Drawing.Size(509, 20);
            this.SecretAccessKeytextBox.TabIndex = 5;
            // 
            // sshtoolbutton
            // 
            this.sshtoolbutton.Location = new System.Drawing.Point(389, 156);
            this.sshtoolbutton.Name = "sshtoolbutton";
            this.sshtoolbutton.Size = new System.Drawing.Size(75, 23);
            this.sshtoolbutton.TabIndex = 6;
            this.sshtoolbutton.Text = "SSH Tool";
            this.sshtoolbutton.UseVisualStyleBackColor = true;
            this.sshtoolbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sshtoolpathtextBox
            // 
            this.sshtoolpathtextBox.Location = new System.Drawing.Point(31, 159);
            this.sshtoolpathtextBox.Name = "sshtoolpathtextBox";
            this.sshtoolpathtextBox.Size = new System.Drawing.Size(352, 20);
            this.sshtoolpathtextBox.TabIndex = 7;
            // 
            // sshkeypathtextBox
            // 
            this.sshkeypathtextBox.Location = new System.Drawing.Point(31, 199);
            this.sshkeypathtextBox.Name = "sshkeypathtextBox";
            this.sshkeypathtextBox.Size = new System.Drawing.Size(352, 20);
            this.sshkeypathtextBox.TabIndex = 8;
            // 
            // sshkeybutton
            // 
            this.sshkeybutton.Location = new System.Drawing.Point(389, 197);
            this.sshkeybutton.Name = "sshkeybutton";
            this.sshkeybutton.Size = new System.Drawing.Size(75, 23);
            this.sshkeybutton.TabIndex = 9;
            this.sshkeybutton.Text = "SSH Key";
            this.sshkeybutton.UseVisualStyleBackColor = true;
            this.sshkeybutton.Click += new System.EventHandler(this.sshkeybutton_Click);
            // 
            // PreferencesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 360);
            this.Controls.Add(this.sshkeybutton);
            this.Controls.Add(this.sshkeypathtextBox);
            this.Controls.Add(this.sshtoolpathtextBox);
            this.Controls.Add(this.sshtoolbutton);
            this.Controls.Add(this.SecretAccessKeytextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AccessKeyIDtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SaveBtn);
            this.Name = "PreferencesFrm";
            this.Text = "preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AccessKeyIDtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SecretAccessKeytextBox;
        private System.Windows.Forms.Button sshtoolbutton;
        private System.Windows.Forms.TextBox sshtoolpathtextBox;
        private System.Windows.Forms.TextBox sshkeypathtextBox;
        private System.Windows.Forms.Button sshkeybutton;
    }
}