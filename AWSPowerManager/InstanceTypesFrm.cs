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
    public partial class InstanceTypesFrm : Form      
        
    {
        protected IAmazonEC2 ec2;
        AWSServices MyAWSService;

        public InstanceTypesFrm()             
        {

            MyAWSService = new AWSServices();
            List<string> EC2Types;
            InitializeComponent();

            MessageBox.Show("TEST");

           // EC2Types = MyAWSService.GetEC2InstanceList()
           
             

        }



        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
