using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


using System.IO;

using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
//using Amazon.SimpleDB;
//using Amazon.SimpleDB.Model;
using Amazon.S3;
using Amazon.S3.Model;


//https://docs.aws.amazon.com/general/latest/gr/rande.html

namespace AWSPowerManager
{

    
    public partial class MainForm : Form
    {
        string version = "AWSPowermanager v1.3.0  27.10.2017"; //add info text on server + sg groups
        //string version = "AWSPowermanager v1.2.0  27.10.2017"; //add ssh to server
        //string version = "AWSPowermanager v1.0.1  18.10.2017"; //fix bug - faild to load when no key and secret in registry
        //string version = "AWSPowermanager v1.0  7.6.2017"; //add preference for diffrent keys
       // string version = "AWSPowermanager v1.0  25.4.2017"; // init version
        string Author = "Demi Goldberg - demi.goldberg@gmail.com";
        protected IAmazonEC2 ec2;
        protected IAmazonS3 s3;

        string AccessKeyID = "";
        string SecretAccessKey="";
        string sshtool = "";
        string sshkey = "";


        AWSServices MyAWSService;
        Amazon.Runtime.AWSCredentials credentials;

        clsResize _form_resize;

        private ListViewColumnSorter lvwColumnSorter = null;


        int CW;
        int CH;
        int IW;
        int IH;

        //private PreferencesFrm Preform;

        public MainForm()
        {


            CW = this.Width; //' Current Width
            CH = this.Height; //Current Height
            IW = this.Width; //Initial Width
            IH = this.Height; //Initial Height

            IW = this.Width;
            IH = this.Height;

            InitializeComponent();

            myInitializeComponent();

            MyAWSService = new AWSServices();

            
         try
            
            {
               
                Microsoft.Win32.RegistryKey AWSPowerManager = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AWSPowerManager");
                AccessKeyID = AWSPowerManager.GetValue("AccessKeyID").ToString();
                SecretAccessKey = AWSPowerManager.GetValue("SecretAccessKey").ToString();
                sshtool = AWSPowerManager.GetValue("sshtool").ToString();
                sshkey = AWSPowerManager.GetValue("sshkey").ToString();
                AWSPowerManager.Close();

                
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Please configure Access and Secret keys" + ex.Message);
                




            }

            Amazon.Util.ProfileManager.RegisterProfile("DemiProfile", AccessKeyID, SecretAccessKey);

            credentials = new Amazon.Runtime.StoredProfileAWSCredentials("DemiProfile");

            //Amazon.Util.ProfileManager.RegisterProfile("DemiProfile", "AKIAJRS2CHZPD4EFX3PA", "WAOIQ/zsZmdwsvhK4MHr+gT3ZmpdF8jdcAd2+nky");


            //AmazonEC2Config config = new AmazonEC2Config();


            //get list of all AWS Regions
            RegionlistView.View = View.Details;
            RegionlistView.FullRowSelect = true;
            RegionlistView.HideSelection = false;
            RegionlistView.LabelEdit = true;
            RegionlistView.Sorting = SortOrder.Ascending;
            RegionlistView.HeaderStyle = ColumnHeaderStyle.Clickable;
            RegionlistView.Columns.Add("Region", 100, HorizontalAlignment.Left);
            RegionlistView.Columns.Add("Region Name", 150, HorizontalAlignment.Left);

            ListViewItem lvitem;
            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions) 
            {
                lvitem = RegionlistView.Items.Add(region.SystemName);
                lvitem.SubItems.Add(region.DisplayName);
            }


            regionslabel.Text = "No. of Regions:" + RegionlistView.Items.Count;


            EC2listView.View = View.Details;
            EC2listView.FullRowSelect = true;
            EC2listView.HideSelection = false;
            EC2listView.LabelEdit = true;
            // EC2listView.Sorting = SortOrder.Ascending;
            EC2listView.HeaderStyle = ColumnHeaderStyle.Clickable;
            EC2listView.Columns.Add("Id", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Tag Name", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("State", 50, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Type", 100, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Platform", 80, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Private DNS Name", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Private IP", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Public DNS Name", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Public IP", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Zone", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("VPC", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("Key Name", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("subnetID", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("ImageID", 150, HorizontalAlignment.Left);
            EC2listView.Columns.Add("SecurityGroups", 300, HorizontalAlignment.Left);







            _form_resize = new clsResize(this);
            this.Load += _Load;
            this.Resize += _Resize;

        }

        public void CredInit()
        {
            Microsoft.Win32.RegistryKey AWSPowerManager = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AWSPowerManager");
            AccessKeyID = AWSPowerManager.GetValue("AccessKeyID").ToString();
            SecretAccessKey = AWSPowerManager.GetValue("SecretAccessKey").ToString();
            AWSPowerManager.Close();

            Amazon.Util.ProfileManager.RegisterProfile("DemiProfile", AccessKeyID, SecretAccessKey);
            credentials = new Amazon.Runtime.StoredProfileAWSCredentials("DemiProfile");



        }



        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            


        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

            _form_resize._resize();


        }



        private void RegionlistView_SelectedIndexChanged(object sender, EventArgs e)
        {

            AmazonEC2Config config = new AmazonEC2Config();

            CredInit();
            EC2listView.Items.Clear();


            //config.RegionEndpoint = RegionEndpoint.EUWest1;


            foreach ( ListViewItem item in RegionlistView.SelectedItems)
                
            {
                RegionEndpoint region =  RegionEndpoint.GetBySystemName(item.SubItems[0].Text) ;
                config.RegionEndpoint = region;
                ec2 = new AmazonEC2Client(credentials, config);


                try
                {

                    //ec2 = new AmazonEC2Client();
                   // List<string> ec2inst_list = MyAWSService.WriteEC2Info(ec2);
                    List<AWSServices.EC2Instance> ec2obj_list = MyAWSService.GetEC2InstanceList(ec2);
                    //MyAWSService.WriteEC2Info(ec2);
                    //MyAWSService.GetEC2InstanceList(ec2);

                    ListViewItem lvitem;
                    foreach (AWSServices.EC2Instance ec2obj in ec2obj_list)
                    {

                        lvitem = EC2listView.Items.Add(ec2obj.getid());
                        lvitem.SubItems.Add(ec2obj.getTagName());
                        lvitem.SubItems.Add(ec2obj.getState());
                        lvitem.SubItems.Add(ec2obj.getType());
                        lvitem.SubItems.Add(ec2obj.getPlatforms());
                        lvitem.SubItems.Add(ec2obj.getPrivateDNSName());
                        lvitem.SubItems.Add(ec2obj.getPrivateIP());
                        lvitem.SubItems.Add(ec2obj.getPublicDNSName());
                        lvitem.SubItems.Add(ec2obj.getPublicIP());
                        lvitem.SubItems.Add(ec2obj.getPlacment());
                        lvitem.SubItems.Add(ec2obj.getVpcId());
                        lvitem.SubItems.Add(ec2obj.getKeyName());
                        lvitem.SubItems.Add(ec2obj.getSubnetId());
                        lvitem.SubItems.Add(ec2obj.getAmiId());

                        string sgstr = "";
                        foreach (string sg in ec2obj.getSG())
                        {
                            sgstr = sgstr + sg + ",";
                        }

                        lvitem.SubItems.Add(sgstr);

                        // lvitem.SubItems.Add(ec2obj.getTokenName());




                    }

                }
                catch (AmazonEC2Exception ex)
                {
                    if (ex.ErrorCode != null && ex.ErrorCode.Equals("AuthFailure"))
                    {
                        MessageBox.Show("The account you are using is not signed up for Amazon EC2.\n please check your preferneces");


                    }
                    else
                    {
                        MessageBox.Show("Caught Exception: " + ex.Message + "/n" + "Response Status Code: " + ex.StatusCode + " " + ex.ErrorCode + " " + ex.ErrorType + " " + ex.RequestId);


                    }


                    
                }

                instanseslabel.Text = "No. of Instances:" + EC2listView.Items.Count;

            }





        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void myInitializeComponent()
        {
            lvwColumnSorter = new ListViewColumnSorter();
            this.EC2listView.ListViewItemSorter = lvwColumnSorter;
            this.EC2listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.EC2listView.AutoArrange = true;

            lvwColumnSorter._SortModifier = ListViewColumnSorter.SortModifiers.SortByText;
            //this.listView_example.Sort();
        }

        private void EC2listView_ColumnClick(object sender, ColumnClickEventArgs e)

        {
           
            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.ColumnToSort)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.OrderOfSort == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.OrderOfSort = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.OrderOfSort = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.ColumnToSort = e.Column;
                lvwColumnSorter.OrderOfSort = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }



        private void EC2listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (EC2listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {

                   // MessageBox.Show("tes - indext");
                    //contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }


        private void EC2listView_MouseDown (object sender, MouseEventArgs e)

    {
            if (e.Button == MouseButtons.Right)
            {
                if (EC2listView.FocusedItem.Bounds.Contains(e.Location) == true)

                {

                 
                    if (EC2listView.SelectedItems.Count > 1)
                    {
                        
                        EC2MultiSelectContextMenuStrip.Show(Cursor.Position);

                    }
                    else
                    {
                       // EC2WincontextMenuStrip.
                        EC2WincontextMenuStrip.Show(Cursor.Position);


                    }

                }


            }


        }

    
        
        private void EC2listView_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("tes - indext");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string tooldetails;
            tooldetails = Application.ProductName + "\n" + Application.CompanyName + "\n" + Application.ProductVersion + "\n" +
            version +"\n";     
            
       
            MessageBox.Show(tooldetails);


        }

        private void rDPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Shell("mstsc -f -v " & ipstr(0), AppWinStyle.MaximizedFocus)
            //string col = EC2listView.SelectedItems[0].Text;

            string col = EC2listView.SelectedItems[0].SubItems[6].Text;
            if (col != "")
            {
                RDPtoHost(col);
            }
            else
            {
                MessageBox.Show("No private IP");
            }

        }

        private void rDPPublicIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string col = EC2listView.SelectedItems[0].SubItems[8].Text;

            if (col != "")
            {
                RDPtoHost(col);
            }
            else {
                MessageBox.Show("No public IP");
            }
                        
        }


        private void RDPtoHost(string host)
            //RDP to host
        {


            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "mstsc.exe",
                    Arguments = "-f -v " + host,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
          /*  while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                // do something with line
            }
            */

        }


        private void SSHtoHost(string host,string sshtool,string sshkey)
        //SSH to host
        {

            string args;

            if (sshkey.Length > 0)
            {
                args = "-i " + sshkey + " " + host;
            }
            else
            {
                args = host;

            }



            Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = sshtool,
                        // Arguments = "-i " + sshkey + " " + host,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }

                };
                proc.Start();
            
            

            /*  while (!proc.StandardOutput.EndOfStream)
              {
                  string line = proc.StandardOutput.ReadLine();
                  // do something with line
              }
              */

        }



        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ReturnMsg = "";

            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {

                string instId = lvitem.SubItems[0].Text;
                ReturnMsg = MyAWSService.RebbotInstance(ec2, instId);

              
            }

            if (ReturnMsg != "Done")
            {

                MessageBox.Show("Problem: " + ReturnMsg);

            }
            //string instId = EC2listView.SelectedItems[0].SubItems[0].Text;
            refreshToolStripMenuItem_Click(sender, e);



        }

        private void startInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ReturnMsg = "";
            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {
                string instId = lvitem.SubItems[0].Text;
                ReturnMsg = MyAWSService.StartInstance(ec2, instId);
            }

            if (ReturnMsg != "Done")
            {

                MessageBox.Show("Problem: " + ReturnMsg);

            }

            //   string instId = EC2listView.SelectedItems[0].SubItems[0].Text;

            refreshToolStripMenuItem_Click(sender, e);



        }

        private void stopInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ReturnMsg = "";
            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {
                string instId = lvitem.SubItems[0].Text;
                ReturnMsg = MyAWSService.StopInstance(ec2, instId);
            }


            if (ReturnMsg != "Done")
            {

                MessageBox.Show("Problem: " + ReturnMsg);

            }

            //string instId = EC2listView.SelectedItems[0].SubItems[0].Text;
            //MyAWSService.StopInstance(ec2, instId);
            refreshToolStripMenuItem_Click(sender, e);

        }

        private void terminateInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string ReturnMsg = "";
            string instId = "";
            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {
                instId = lvitem.SubItems[0].Text;
                
            }

            DialogResult dialogResult = MessageBox.Show("sure","You are about to terminate instance:"+ instId , MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReturnMsg = MyAWSService.TerminateInstance(ec2, instId);

                if (ReturnMsg != "Done")
                {
                    MessageBox.Show("Problem: " + ReturnMsg);
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            //string instId = EC2listView.SelectedItems[0].SubItems[0].Text;
            //MyAWSService.StopInstance(ec2, instId);
            refreshToolStripMenuItem_Click(sender, e);


        }




        private void createImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ReturnMsg="";
            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {
                string instId = lvitem.SubItems[0].Text;
                ReturnMsg=MyAWSService.CreateImage(ec2, instId);
            }

            //string instId = EC2listView.SelectedItems[0].SubItems[0].Text;
            //MyAWSService.StopInstance(ec2, instId);

            if (ReturnMsg != "Done") {

                MessageBox.Show("Problem: " + ReturnMsg);

            }
            refreshToolStripMenuItem_Click(sender, e);

        }


        private void newInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //(IAmazonEC2 ec2, string ami,string subnetid,string Key,string insttype,string secgroupid)
            string ReturnMsg = "";
            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {
                string instId = lvitem.SubItems[0].Text;
                string subnetId = lvitem.SubItems[11].Text;
                string amiId = lvitem.SubItems[12].Text;
                string key = lvitem.SubItems[10].Text;
                string insttype = lvitem.SubItems[3].Text;
                string gsecid = lvitem.SubItems[13].Text;
                gsecid.Replace(",", "");
                ReturnMsg = MyAWSService.lunchInstance(ec2,amiId,subnetId,key,insttype,gsecid);
            }

            //string instId = EC2listView.SelectedItems[0].SubItems[0].Text;
            //MyAWSService.StopInstance(ec2, instId);

            if (ReturnMsg != "Done")
            {

                MessageBox.Show("Problem: " + ReturnMsg);

            }
            refreshToolStripMenuItem_Click(sender, e);

        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionlistView_SelectedIndexChanged(sender, e);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PreferencesFrm PrefForm = new PreferencesFrm();


              PrefForm.Show();

           

        }

        private void EC2WincontextMenuStrip_Opening(object sender, CancelEventArgs e)
        {



        }

        private void rebootInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rebootToolStripMenuItem_Click(sender, e);

        }

        private void startInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startInstanceToolStripMenuItem_Click(sender, e);
        }

        private void stopInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopInstanceToolStripMenuItem_Click(sender, e);
        }

        private void createImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createImageToolStripMenuItem_Click(sender, e);
        }

        private void sSHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {

                // Shell("mstsc -f -v " & ipstr(0), AppWinStyle.MaximizedFocus)
                //string col = EC2listView.SelectedItems[0].Text;

                string col = EC2listView.SelectedItems[0].SubItems[6].Text;
                if (col != "")
                {
                    SSHtoHost(col,sshtool,sshkey);
                    
                }
                else
                {
                    MessageBox.Show("No private IP");
                }

            }
        }

        private void modifyInstanceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstanceTypesFrm itypesForm = new InstanceTypesFrm();
            List<string> EC2Types =  new List<string> { };
            EC2Types = MyAWSService.GetListOfEC2Types();

            
            itypesForm.Show();


           
        }


        private void instanceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            infoFrm infoForm = new infoFrm();
           
           // List<AWSServices.EC2Instance> ec2obj_list = MyAWSService.GetEC2InstanceList(ec2);

            infoForm.InfotextBox.Clear();

            foreach (ListViewItem lvitem in EC2listView.SelectedItems)
            {
                //string instId = lvitem.SubItems[0].Text;

           // foreach (AWSServices.EC2Instance ec2obj in ec2obj_list)
           // {

                infoForm.InfotextBox.Text = lvitem.SubItems[0].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[1].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[3].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[5].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[6].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[7].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[8].Text + "\r\n";  
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[9].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[10].Text  + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[11].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[12].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[13].Text + "\r\n";
                infoForm.InfotextBox.Text = infoForm.InfotextBox.Text + lvitem.SubItems[14].Text + "\r\n";


            }




            infoForm.Show();



        }

       
    }
}


        



  /*  Private Sub ServiceListView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ServiceListView.MouseDown
        If e.Button = MouseButtons.Right Then

           If Me.ServiceListView.Items.Count > 0 Then
               If Not Me.ServiceListView.FocusedItem Is Nothing Then
                    Dim lvItem As ListViewItem
                    lvItem = Me.ServiceListView.GetItemAt(e.X, e.Y)
                    'Me.ElementContextMenu.MenuItems.Item(0).Text = lvItem.Text() 'Or what ever item?
                    If viewTab.SelectedTab.Name = "ServiceTab" Then
                       Me.ServiceContextMenu.Show(Me.ServiceListView, New Point(e.X, e.Y))
                    End If
                    */


        //AWSConfigs 




    /*   private List<string> WriteS3Info()
       {
           //StringBuilder output = new StringBuilder();
           List<string> s3list = new List<string>();
           ListBucketsResponse response = s3.ListBuckets();
           if (response.Buckets != null && response.Buckets.Count > 0)
               foreach (S3Bucket theBucket in response.Buckets)
               {
                   //output.AppendFormat("<li>{0}</li>", theBucket.BucketName);
                   s3list.Add(theBucket.BucketName);
               }
           //this.s3Placeholder.Text = output.ToString();
           return s3list;
       } */










