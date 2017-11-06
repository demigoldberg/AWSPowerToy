namespace AWSPowerManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.EC2listView = new System.Windows.Forms.ListView();
            this.RegionlistView = new System.Windows.Forms.ListView();
            this.Closebtn = new System.Windows.Forms.Button();
            this.regionslabel = new System.Windows.Forms.Label();
            this.instanseslabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EC2WincontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RDPPublicIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EC2MultiSelectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rebootInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyInstanceTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminateInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.EC2WincontextMenuStrip.SuspendLayout();
            this.EC2MultiSelectContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EC2listView
            // 
            this.EC2listView.Location = new System.Drawing.Point(321, 43);
            this.EC2listView.Name = "EC2listView";
            this.EC2listView.Size = new System.Drawing.Size(819, 384);
            this.EC2listView.TabIndex = 2;
            this.EC2listView.UseCompatibleStateImageBehavior = false;
            this.EC2listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.EC2listView_ColumnClick);
            this.EC2listView.SelectedIndexChanged += new System.EventHandler(this.EC2listView_SelectedIndexChanged);
            this.EC2listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EC2listView_MouseClick);
            this.EC2listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EC2listView_MouseDown);
            // 
            // RegionlistView
            // 
            this.RegionlistView.Location = new System.Drawing.Point(12, 43);
            this.RegionlistView.Name = "RegionlistView";
            this.RegionlistView.Size = new System.Drawing.Size(285, 384);
            this.RegionlistView.TabIndex = 3;
            this.RegionlistView.UseCompatibleStateImageBehavior = false;
            this.RegionlistView.SelectedIndexChanged += new System.EventHandler(this.RegionlistView_SelectedIndexChanged);
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(536, 458);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(131, 23);
            this.Closebtn.TabIndex = 5;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // regionslabel
            // 
            this.regionslabel.AutoSize = true;
            this.regionslabel.Location = new System.Drawing.Point(12, 430);
            this.regionslabel.Name = "regionslabel";
            this.regionslabel.Size = new System.Drawing.Size(41, 13);
            this.regionslabel.TabIndex = 6;
            this.regionslabel.Text = "regions";
            // 
            // instanseslabel
            // 
            this.instanseslabel.AutoSize = true;
            this.instanseslabel.Location = new System.Drawing.Point(318, 430);
            this.instanseslabel.Name = "instanseslabel";
            this.instanseslabel.Size = new System.Drawing.Size(52, 13);
            this.instanseslabel.TabIndex = 7;
            this.instanseslabel.Text = "instances";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Regions";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // EC2WincontextMenuStrip
            // 
            this.EC2WincontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RDPToolStripMenuItem,
            this.RDPPublicIPToolStripMenuItem,
            this.SSHToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.startInstanceToolStripMenuItem,
            this.stopInstanceToolStripMenuItem,
            this.createImageToolStripMenuItem,
            this.terminateInstanceToolStripMenuItem,
            this.modifyInstanceTypeToolStripMenuItem,
            this.newInstanceToolStripMenuItem,
            this.instanceInfoToolStripMenuItem});
            this.EC2WincontextMenuStrip.Name = "EC2WincontextMenuStrip";
            this.EC2WincontextMenuStrip.Size = new System.Drawing.Size(189, 246);
            this.EC2WincontextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.EC2WincontextMenuStrip_Opening);
            // 
            // RDPToolStripMenuItem
            // 
            this.RDPToolStripMenuItem.Name = "RDPToolStripMenuItem";
            this.RDPToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.RDPToolStripMenuItem.Text = "RDP Private IP";
            this.RDPToolStripMenuItem.Click += new System.EventHandler(this.rDPToolStripMenuItem_Click);
            // 
            // RDPPublicIPToolStripMenuItem
            // 
            this.RDPPublicIPToolStripMenuItem.Name = "RDPPublicIPToolStripMenuItem";
            this.RDPPublicIPToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.RDPPublicIPToolStripMenuItem.Text = "RDP Public IP";
            this.RDPPublicIPToolStripMenuItem.Click += new System.EventHandler(this.rDPPublicIPToolStripMenuItem_Click);
            // 
            // SSHToolStripMenuItem
            // 
            this.SSHToolStripMenuItem.Name = "SSHToolStripMenuItem";
            this.SSHToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.SSHToolStripMenuItem.Text = "SSH Private IP";
            this.SSHToolStripMenuItem.Click += new System.EventHandler(this.sSHToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.rebootToolStripMenuItem.Text = "Reboot Instance";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.rebootToolStripMenuItem_Click);
            // 
            // startInstanceToolStripMenuItem
            // 
            this.startInstanceToolStripMenuItem.Name = "startInstanceToolStripMenuItem";
            this.startInstanceToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.startInstanceToolStripMenuItem.Text = "Start Instance";
            this.startInstanceToolStripMenuItem.Click += new System.EventHandler(this.startInstanceToolStripMenuItem_Click);
            // 
            // stopInstanceToolStripMenuItem
            // 
            this.stopInstanceToolStripMenuItem.Name = "stopInstanceToolStripMenuItem";
            this.stopInstanceToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.stopInstanceToolStripMenuItem.Text = "Stop Instance";
            this.stopInstanceToolStripMenuItem.Click += new System.EventHandler(this.stopInstanceToolStripMenuItem_Click);
            // 
            // createImageToolStripMenuItem
            // 
            this.createImageToolStripMenuItem.Name = "createImageToolStripMenuItem";
            this.createImageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.createImageToolStripMenuItem.Text = "Create Image";
            this.createImageToolStripMenuItem.Click += new System.EventHandler(this.createImageToolStripMenuItem_Click);
            // 
            // EC2MultiSelectContextMenuStrip
            // 
            this.EC2MultiSelectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rebootInstancesToolStripMenuItem,
            this.startInstancesToolStripMenuItem,
            this.stopInstancesToolStripMenuItem,
            this.createImagesToolStripMenuItem});
            this.EC2MultiSelectContextMenuStrip.Name = "EC2MultiSelectContextMenuStrip";
            this.EC2MultiSelectContextMenuStrip.Size = new System.Drawing.Size(165, 92);
            // 
            // rebootInstancesToolStripMenuItem
            // 
            this.rebootInstancesToolStripMenuItem.Name = "rebootInstancesToolStripMenuItem";
            this.rebootInstancesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rebootInstancesToolStripMenuItem.Text = "Reboot Instances";
            this.rebootInstancesToolStripMenuItem.Click += new System.EventHandler(this.rebootInstancesToolStripMenuItem_Click);
            // 
            // startInstancesToolStripMenuItem
            // 
            this.startInstancesToolStripMenuItem.Name = "startInstancesToolStripMenuItem";
            this.startInstancesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.startInstancesToolStripMenuItem.Text = "Start Instances";
            this.startInstancesToolStripMenuItem.Click += new System.EventHandler(this.startInstancesToolStripMenuItem_Click);
            // 
            // stopInstancesToolStripMenuItem
            // 
            this.stopInstancesToolStripMenuItem.Name = "stopInstancesToolStripMenuItem";
            this.stopInstancesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.stopInstancesToolStripMenuItem.Text = "Stop Instances";
            this.stopInstancesToolStripMenuItem.Click += new System.EventHandler(this.stopInstancesToolStripMenuItem_Click);
            // 
            // createImagesToolStripMenuItem
            // 
            this.createImagesToolStripMenuItem.Name = "createImagesToolStripMenuItem";
            this.createImagesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.createImagesToolStripMenuItem.Text = "Create Images";
            this.createImagesToolStripMenuItem.Click += new System.EventHandler(this.createImagesToolStripMenuItem_Click);
            // 
            // modifyInstanceTypeToolStripMenuItem
            // 
            this.modifyInstanceTypeToolStripMenuItem.Name = "modifyInstanceTypeToolStripMenuItem";
            this.modifyInstanceTypeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.modifyInstanceTypeToolStripMenuItem.Text = "Modify Instance Type";
            this.modifyInstanceTypeToolStripMenuItem.Click += new System.EventHandler(this.modifyInstanceTypeToolStripMenuItem_Click);
            // 
            // instanceInfoToolStripMenuItem
            // 
            this.instanceInfoToolStripMenuItem.Name = "instanceInfoToolStripMenuItem";
            this.instanceInfoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.instanceInfoToolStripMenuItem.Text = "instance info";
            this.instanceInfoToolStripMenuItem.Click += new System.EventHandler(this.instanceInfoToolStripMenuItem_Click);
            // 
            // newInstanceToolStripMenuItem
            // 
            this.newInstanceToolStripMenuItem.Name = "newInstanceToolStripMenuItem";
            this.newInstanceToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newInstanceToolStripMenuItem.Text = "New Instance like this";
            this.newInstanceToolStripMenuItem.Click += new System.EventHandler(this.newInstanceToolStripMenuItem_Click);
            // 
            // terminateInstanceToolStripMenuItem
            // 
            this.terminateInstanceToolStripMenuItem.Name = "terminateInstanceToolStripMenuItem";
            this.terminateInstanceToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.terminateInstanceToolStripMenuItem.Text = "Terminate Instance";
            this.terminateInstanceToolStripMenuItem.Click += new System.EventHandler(this.terminateInstanceToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 522);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.instanseslabel);
            this.Controls.Add(this.regionslabel);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.RegionlistView);
            this.Controls.Add(this.EC2listView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "AWS Console";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EC2WincontextMenuStrip.ResumeLayout(false);
            this.EC2MultiSelectContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView EC2listView;
        private System.Windows.Forms.ListView RegionlistView;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Label regionslabel;
        private System.Windows.Forms.Label instanseslabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip EC2WincontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RDPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SSHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RDPPublicIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip EC2MultiSelectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rebootInstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startInstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopInstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyInstanceTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instanceInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminateInstanceToolStripMenuItem;
    }
}

