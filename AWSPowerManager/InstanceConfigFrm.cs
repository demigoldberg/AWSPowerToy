using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.EC2;

namespace AWSPowerManager

    

{
    public partial class InstanceConfigFrm : Form      
        
    {
      //  protected IAmazonEC2 ec2;
       // AWSServices MyAWSService;

        public InstanceConfigFrm()             
        {

           // MyAWSService = new AWSServices();
           // List<string> EC2Types;
            InitializeComponent();

           // MessageBox.Show("TEST");

            // EC2Types = MyAWSService.GetEC2InstanceList()

            for (int i = 0; i < 20; i++)
            {
                this.InstNumcomboBox.Items.Add(i);

            }

            this.PubIPcomboBox.Items.Add("False");
            this.PubIPcomboBox.Items.Add("True");

            this.PubIPcomboBox.Text = "True";
            this.SGtextBox.Text = "AccessSG";


            this.InstTypeslistBox.Items.Add("t2.micro");
            this.InstTypeslistBox.Items.Add("t2.small");
            this.InstTypeslistBox.Items.Add("t2.medium");
            this.InstTypeslistBox.Items.Add("t2.large");
            this.InstTypeslistBox.Items.Add("t2.2xlarge");
            this.InstTypeslistBox.Items.Add("m3.medium");
            this.InstTypeslistBox.Items.Add("m3.large");
            this.InstTypeslistBox.Items.Add("m4.large");
            this.InstTypeslistBox.Items.Add("m4.xlarge");
            this.InstTypeslistBox.Items.Add("m4.2xlarge");
            this.InstTypeslistBox.Items.Add("g2.2xlarge");
            this.InstTypeslistBox.Items.Add("g2.4xlarge");
            this.InstTypeslistBox.Items.Add("g3.4xlarge");
            this.InstTypeslistBox.Items.Add("g3.8xlarge");
            this.InstTypeslistBox.Items.Add("g3.16xlarge");
            this.InstTypeslistBox.Items.Add("p2.xlarge");
            this.InstTypeslistBox.Items.Add("p2.8xlarge");
            this.InstTypeslistBox.Items.Add("p3.2xlarge");
            this.InstTypeslistBox.Items.Add("p3.8xlarge");

          
        }

        //ubuntu 16 ami-97e953f8

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InstTypeslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PubIPcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InstNumcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void KeytextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InstNametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SGtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AMItextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InstanceConfigFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
