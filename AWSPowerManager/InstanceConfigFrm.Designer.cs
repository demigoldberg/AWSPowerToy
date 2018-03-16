namespace AWSPowerManager
{
    partial class InstanceConfigFrm
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
            this.InstTypeslistBox = new System.Windows.Forms.ListBox();
            this.Close = new System.Windows.Forms.Button();
            this.InstNumcomboBox = new System.Windows.Forms.ComboBox();
            this.PubIPcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AMItextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SGtextBox = new System.Windows.Forms.TextBox();
            this.KeytextBox = new System.Windows.Forms.TextBox();
            this.keylbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InstNametextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PrivateIPtextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RoodDiskSizetextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SubnetIdtextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InstTypeslistBox
            // 
            this.InstTypeslistBox.FormattingEnabled = true;
            this.InstTypeslistBox.Location = new System.Drawing.Point(205, 36);
            this.InstTypeslistBox.Name = "InstTypeslistBox";
            this.InstTypeslistBox.Size = new System.Drawing.Size(163, 394);
            this.InstTypeslistBox.Sorted = true;
            this.InstTypeslistBox.TabIndex = 1;
            this.InstTypeslistBox.SelectedIndexChanged += new System.EventHandler(this.InstTypeslistBox_SelectedIndexChanged);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(150, 458);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 2;
            this.Close.Text = "Create";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // InstNumcomboBox
            // 
            this.InstNumcomboBox.FormattingEnabled = true;
            this.InstNumcomboBox.Location = new System.Drawing.Point(12, 80);
            this.InstNumcomboBox.Name = "InstNumcomboBox";
            this.InstNumcomboBox.Size = new System.Drawing.Size(164, 21);
            this.InstNumcomboBox.TabIndex = 3;
            this.InstNumcomboBox.SelectedIndexChanged += new System.EventHandler(this.InstNumcomboBox_SelectedIndexChanged);
            // 
            // PubIPcomboBox
            // 
            this.PubIPcomboBox.FormattingEnabled = true;
            this.PubIPcomboBox.Location = new System.Drawing.Point(12, 301);
            this.PubIPcomboBox.Name = "PubIPcomboBox";
            this.PubIPcomboBox.Size = new System.Drawing.Size(164, 21);
            this.PubIPcomboBox.TabIndex = 4;
            this.PubIPcomboBox.SelectedIndexChanged += new System.EventHandler(this.PubIPcomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Instances";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Public IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Instance Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Image ID";
            // 
            // AMItextBox
            // 
            this.AMItextBox.Location = new System.Drawing.Point(12, 213);
            this.AMItextBox.Name = "AMItextBox";
            this.AMItextBox.Size = new System.Drawing.Size(164, 20);
            this.AMItextBox.TabIndex = 9;
            this.AMItextBox.TextChanged += new System.EventHandler(this.AMItextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Security Group";
            // 
            // SGtextBox
            // 
            this.SGtextBox.Location = new System.Drawing.Point(12, 169);
            this.SGtextBox.Name = "SGtextBox";
            this.SGtextBox.Size = new System.Drawing.Size(164, 20);
            this.SGtextBox.TabIndex = 11;
            this.SGtextBox.TextChanged += new System.EventHandler(this.SGtextBox_TextChanged);
            // 
            // KeytextBox
            // 
            this.KeytextBox.Location = new System.Drawing.Point(12, 125);
            this.KeytextBox.Name = "KeytextBox";
            this.KeytextBox.Size = new System.Drawing.Size(164, 20);
            this.KeytextBox.TabIndex = 12;
            this.KeytextBox.TextChanged += new System.EventHandler(this.KeytextBox_TextChanged);
            // 
            // keylbl
            // 
            this.keylbl.AutoSize = true;
            this.keylbl.Location = new System.Drawing.Point(12, 109);
            this.keylbl.Name = "keylbl";
            this.keylbl.Size = new System.Drawing.Size(24, 13);
            this.keylbl.TabIndex = 13;
            this.keylbl.Text = "key";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Instance Name";
            // 
            // InstNametextBox
            // 
            this.InstNametextBox.Location = new System.Drawing.Point(12, 36);
            this.InstNametextBox.Name = "InstNametextBox";
            this.InstNametextBox.Size = new System.Drawing.Size(164, 20);
            this.InstNametextBox.TabIndex = 15;
            this.InstNametextBox.TextChanged += new System.EventHandler(this.InstNametextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Private IP";
            // 
            // PrivateIPtextBox
            // 
            this.PrivateIPtextBox.Location = new System.Drawing.Point(12, 346);
            this.PrivateIPtextBox.Name = "PrivateIPtextBox";
            this.PrivateIPtextBox.Size = new System.Drawing.Size(164, 20);
            this.PrivateIPtextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Root Disk Size(GB)";
            // 
            // RoodDiskSizetextBox
            // 
            this.RoodDiskSizetextBox.Location = new System.Drawing.Point(12, 390);
            this.RoodDiskSizetextBox.Name = "RoodDiskSizetextBox";
            this.RoodDiskSizetextBox.Size = new System.Drawing.Size(164, 20);
            this.RoodDiskSizetextBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "subnet id";
            // 
            // SubnetIdtextBox
            // 
            this.SubnetIdtextBox.Location = new System.Drawing.Point(12, 257);
            this.SubnetIdtextBox.Name = "SubnetIdtextBox";
            this.SubnetIdtextBox.Size = new System.Drawing.Size(164, 20);
            this.SubnetIdtextBox.TabIndex = 21;
            // 
            // InstanceConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 493);
            this.Controls.Add(this.SubnetIdtextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RoodDiskSizetextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PrivateIPtextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.InstNametextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.keylbl);
            this.Controls.Add(this.KeytextBox);
            this.Controls.Add(this.SGtextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AMItextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PubIPcomboBox);
            this.Controls.Add(this.InstNumcomboBox);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.InstTypeslistBox);
            this.Name = "InstanceConfigFrm";
            this.Text = "InstanceTypes";
            this.Load += new System.EventHandler(this.InstanceConfigFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox InstTypeslistBox;
        public System.Windows.Forms.ComboBox InstNumcomboBox;
        public System.Windows.Forms.ComboBox PubIPcomboBox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox AMItextBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox SGtextBox;
        private System.Windows.Forms.Label keylbl;
        public System.Windows.Forms.TextBox KeytextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox PrivateIPtextBox;
        public System.Windows.Forms.TextBox InstNametextBox;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox RoodDiskSizetextBox;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox SubnetIdtextBox;
    }
}