using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWSPowerManager
{
    public partial class PreferencesFrm : Form
    {
        public PreferencesFrm()
        {
            InitializeComponent();

            try
            {

                Microsoft.Win32.RegistryKey AWSPowerManager = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AWSPowerManager");
                this.AccessKeyIDtextBox.Text = AWSPowerManager.GetValue("AccessKeyID").ToString();
                this.SecretAccessKeytextBox.Text = AWSPowerManager.GetValue("SecretAccessKey").ToString();
                this.sshtoolpathtextBox.Text = AWSPowerManager.GetValue("sshtool").ToString();
                this.sshkeypathtextBox.Text = AWSPowerManager.GetValue("sshkey").ToString();

                AWSPowerManager.Close();

                  }
            catch
            {

            }

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   


        public string AccessKeyIDTextboxStr
        {
            get { return this.AccessKeyIDtextBox.Text; }
            set { AccessKeyIDtextBox.Text = value; }


        }


        public string SecretAccessKeytextBoxStr
        {
            get { return this.SecretAccessKeytextBox.Text; }
            set { SecretAccessKeytextBox.Text = value; }


        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MainForm MFrm = new MainForm();
            Microsoft.Win32.RegistryKey AWSPowerManager = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("AWSPowerManager");
            AWSPowerManager.SetValue("AccessKeyID", AccessKeyIDtextBox.Text);
            AWSPowerManager.SetValue("SecretAccessKey", SecretAccessKeytextBox.Text);
            AWSPowerManager.SetValue("sshtool", sshtoolpathtextBox.Text);
            AWSPowerManager.SetValue("sshkey", sshkeypathtextBox.Text);
            AWSPowerManager.Close();

            MFrm.CredInit();

            this.Close();

           


            
        }

        private void button1_Click(object sender, EventArgs e)
            // select and save ssh tool exe
        {
            OpenFileDialog fd;

            try
            {
                fd = new OpenFileDialog();

                fd.Title = "Open SSH tool location";
                fd.Filter = "All files(*.*) | *.*| All files(*.*) | *.* ";
                fd.FilterIndex = 2;
                fd.RestoreDirectory = true;
                fd.InitialDirectory = ".";


                if (fd.ShowDialog() == DialogResult.OK)
                {
                    sshtoolpathtextBox.Text = fd.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void sshkeybutton_Click(object sender, EventArgs e)
            //open and save ssh key location
        {
            OpenFileDialog fd;

            try
            {
                fd = new OpenFileDialog();

                fd.Title = "Open SSH key location";
                fd.Filter = "All files(*.*) | *.*| All files(*.*) | *.* ";
                fd.FilterIndex = 2;
                fd.RestoreDirectory = true;
                fd.InitialDirectory = ".";


                if (fd.ShowDialog() == DialogResult.OK)
                {
                    sshkeypathtextBox.Text = fd.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }

}