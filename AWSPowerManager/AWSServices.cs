using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
//using Amazon.SimpleDB;
//using Amazon.SimpleDB.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace AWSPowerManager
{
    class AWSServices


    {


        public List<string> WriteEC2Info(IAmazonEC2 ec2)
        {

            List<string> ec2list = new List<string>();
            DescribeInstancesRequest ec2Request = new DescribeInstancesRequest();
            DescribeInstancesResponse ec2Response = ec2.DescribeInstances(ec2Request);
            foreach (Reservation reservation in ec2Response.Reservations)
            {
                foreach (Instance instance in reservation.Instances)
                {
                    ec2list.Add(instance.InstanceId);
                    // instance.pr
                }
            }
            return ec2list;
        }


        public List<EC2Instance> GetEC2InstanceList(IAmazonEC2 ec2)
        {

            // List<string> ec2list = new List<string>();
            List<EC2Instance> ec2list;
            ec2list = new List<EC2Instance>();
            List<GroupIdentifier> sg;
            List<string> sgstrlist;
           
           
            DescribeInstancesRequest ec2Request = new DescribeInstancesRequest();
            DescribeInstancesResponse ec2Response = ec2.DescribeInstances(ec2Request);
            foreach (Reservation reservation in ec2Response.Reservations)
            {
                foreach (Instance instance in reservation.Instances)
                {
                    EC2Instance EC2Ins;
                    EC2Ins = new EC2Instance();
                    sg = new List<GroupIdentifier>();
                    sgstrlist = new List<string>();

                    EC2Ins.setid(instance.InstanceId);
                    EC2Ins.setName(instance.PrivateDnsName);
                    EC2Ins.setPrivateDNSName(instance.PrivateDnsName);
                    EC2Ins.setPrivateIP(instance.PrivateIpAddress);
                    EC2Ins.setPublicIP(instance.PublicIpAddress);
                    EC2Ins.setType(instance.InstanceType);
                    EC2Ins.setPublicDNSName(instance.PublicDnsName);
                    EC2Ins.setTokenName(instance.ClientToken);
                    EC2Ins.setPlatform(instance.Platform);
                    EC2Ins.setState(instance.State.Name.Value);
                    EC2Ins.setPlacment(instance.Placement.AvailabilityZone);
                   // EC2Ins.setTagName(instance.Tags[0].Value);
                                    
                    EC2Ins.setKeyName(instance.KeyName);
                    EC2Ins.setVpcId(instance.VpcId);
                    EC2Ins.setSubnetId(instance.SubnetId);
                    EC2Ins.setAmiId(instance.ImageId);

                    foreach (Amazon.EC2.Model.Tag EC2tag in instance.Tags)
                    {
                        if (EC2tag.Key == "Name")
                        {
                            EC2Ins.setTagName(EC2tag.Value);
                        }
                    }

                    foreach (GroupIdentifier sgi in instance.SecurityGroups)
                    {

                        sgstrlist.Add(sgi.GroupId);
                       // sgi.GroupId


                    }
                    EC2Ins.setSG(sgstrlist);

                    Monitoring m;
                    List<InstanceNetworkInterface> ln;
                    ln = new List<InstanceNetworkInterface>();
                    m = instance.Monitoring;
                    ln = instance.NetworkInterfaces;

                    //instance.NetworkInterfaces
                    //instance.

                    ec2list.Add(EC2Ins);

                    //  ec2list.Add(instance.InstanceId);
                    /*   instance.ImageId;
                       instance.KeyName;
                       instance.LaunchTime;
                       instance.Placement;
                       instance.Platform;
                       instance.RootDeviceType;
                       instance.SecurityGroups;
                       instance.SriovNetSupport; //enhance network is supported
                       instance.State;
                       instance.StateReason;
                       instance.SubnetId;
                       instance.Tags;
                       instance.VirtualizationType;
                       instance.VpcId 
                    instance.KeyName;
                    instance.VpcId; */
                   
                


                }
            }
            return ec2list;
        }

        public string StartInstance(IAmazonEC2 ec2, string instidstr )
            //start ec2 instance
        {

            // ec2.StartInstances.StartInstance.
            StartInstancesRequest startreq;
            StartInstancesResponse startInstancesResponse = null;
            try {

                startreq = new StartInstancesRequest {

                    InstanceIds = new List<string>() { instidstr }
                };

                startInstancesResponse = ec2.StartInstances(startreq);
                return "Done";

            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }

           
        }

        public string StopInstance(IAmazonEC2 ec2, string instidstr)
        //stop ec2 instance
        {

            StopInstancesRequest stopreq;
            StopInstancesResponse stopInstancesResponse = null;
            


            try
            {

                stopreq = new StopInstancesRequest
                {

                    InstanceIds = new List<string>() { instidstr }
                };

                stopInstancesResponse= ec2.StopInstances(stopreq);

               
                return "Done";

            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }


        }


        public string RebbotInstance(IAmazonEC2 ec2, string instidstr)
        //stop ec2 instance
        {

            RebootInstancesRequest rebootreq;
            RebootInstancesResponse rebootInstancesResponse = null;

            try
            {
                rebootreq = new RebootInstancesRequest
                {

                     
                    InstanceIds = new List<string>() { instidstr }
                    
                };

                rebootInstancesResponse = ec2.RebootInstances(rebootreq);
                return "Done";

            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }

          

        }

        public string TerminateInstance(IAmazonEC2 ec2, string instidstr)
        //terminate ec2 instance
        {

            TerminateInstancesRequest Terminatereq;
            TerminateInstancesResponse TerminateInstancesResponse = null;
            try
            {
                Terminatereq = new TerminateInstancesRequest
                {
                    InstanceIds = new List<string>() { instidstr }
                };

                TerminateInstancesResponse = ec2.TerminateInstances(Terminatereq);
                return "Done";
            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }
        }

        public string ModifyInstanceType(IAmazonEC2 ec2, string instidstr)
        //stop ec2 instance
        {

            ModifyInstanceAttributeRequest modifyreq; 
            ModifyInstanceAttributeResponse modifyresponse = null;

            string insttype;

            insttype = InstanceType.C1Medium.ToString();

           // InstanceType.
            //modifyreq.Attribute = 
            try   
            {

                modifyreq = new ModifyInstanceAttributeRequest

                 //modifyreq.tar             //ModifyInstanceAttributeRequest.
                //modifyreq.InstanceType = InstanceType.C1Medium;
                {
                  
                
               
                    //Ramdisk = "10000".ToString()
                   // InstanceType.C1Medium
                    InstanceId = instidstr 
                   
                    
                    
                    
                };

                modifyresponse = ec2.ModifyInstanceAttribute(modifyreq);
                return "Done";

            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }

           

        }




        public string CreateImage(IAmazonEC2 ec2, string instidstr)
        //stop ec2 instance
        {

            CreateImageRequest ImgReq;
            CreateImageResponse ImageResponse = null;

            string DT;

            DT = DateTime.Now.ToString("yyyy-MM-dd_hh.mm.ss");

            
            //ec2.DescribeImages
            

           // RebootInstancesRequest rebootreq;
           // RebootInstancesResponse rebootInstancesResponse = null;

            try
            {
                ImgReq = new CreateImageRequest();

                ImgReq.InstanceId = instidstr;
                ImgReq.Name = instidstr + "_" + DT;
                ImgReq.NoReboot = true;
                ImgReq.Description = "Created By AWSPowerManager";

                

                ImageResponse = ec2.CreateImage(ImgReq); 
                return "Done";
                 
            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }


        }

        //############################################################################################

        public string lunchInstance (IAmazonEC2 ec2, string ami,string subnetid,string Key,string insttype,string secgroupid)
             //create new instance          
        {
            RunInstancesResponse launchResponse;
            string subnetID = subnetid; // "subnet-2e107b76";
            string amiID = ami; // "ami-c51e3eb6";
            string keyPairName = Key; // "sirin-staging";
            string itype = insttype; // "t2.small";



           // List<string> groups = new List<string>() { "sg-9f90e2f9" };
            List<string> groups = new List<string>() { secgroupid };

            try
            {
                var eni = new InstanceNetworkInterfaceSpecification()
                {
                    DeviceIndex = 0,
                    SubnetId = subnetID,
                    Groups = groups,
                    AssociatePublicIpAddress = true
                };
                              
                List<InstanceNetworkInterfaceSpecification> enis = new List<InstanceNetworkInterfaceSpecification>() { eni };

                var launchRequest = new RunInstancesRequest()
                {
                    ImageId = amiID,
                    InstanceType = itype,
                    MinCount = 1,
                    MaxCount = 1,
                    KeyName = keyPairName,
                    NetworkInterfaces = enis
                };
               
                //ec2.RunInstances(launchRequest);
                launchResponse = ec2.RunInstances(launchRequest);
                return "Done";
            }
            catch (Exception ex)
            {
                return (ex.Message + "\n" + ex.StackTrace);
            }
                                  
        }



        


        public List<string> GetListOfEC2Types ()
       {
            List<string> ec2types = new List<string> { };
          //  List<string> ec2types = new List<string> { };
          // List <InstanceType> itypes  ;
          // InstanceType ity;
          // itypes = new List<InstanceType> { };

            List<string> itypes = typeof(InstanceType).GetProperties().Select(f => f.Name).ToList();

           //var fields = InstanceType.GetType().GetFields().Select(f => f.Name).ToList();


            //InstanceType.G28xlarge.
                



            // foreach (InstanceType itype in Enum.GetValues(typeof(InstanceType)))
            // {
            //    // itype.ToString();
            //     ec2types.Add(itype.ToString());

            // }

            return ec2types;

        }


        




        public class EC2Instance
        // instance class
        {
            private string id;   
            private string name;  
            private string type;
            private string privateIPAddress;
            private string publicIPAddress;
            private string privateDNSName;
            private string publicDNSName;
            private string TokenName;
            private string platform;
            private string state;
            private string placement;
            private string TagName;
            private string keyname;
            private string vpcid;
            private string subnetId;
            private string amiId;
            private List<string> securitygroups;
           
                       
            public void setid(string instanceID)
            {
                id = instanceID;
            }

           
            public string getid()
            {
                return id;
            }

                        
            public void setName(string instanceName)
            {
                name = instanceName;
            }

            public string getName()
            {
                return name;
            }


            public void setTokenName(string instanceTokenName)
            {
                TokenName = instanceTokenName;
            }

            public string getTokenName()
            {
                return TokenName;
            }



            public void setType(string InstanceType)
            {
                type = InstanceType;
            }

            public string getType()
            {
                return type;
            }

            //------------------------------------------

            public void setPrivateIP(string instancePrivateIP)
            {
                privateIPAddress = instancePrivateIP;
            }

            public string getPrivateIP()
            {
                return privateIPAddress;
            }




            public void setPublicIP(string instancePublicIP)
            {
                publicIPAddress = instancePublicIP;
            }

            public string getPublicIP()
            {
                return publicIPAddress;
            }


            public void setPrivateDNSName(string instancePrivateDNSName)
            {
                privateDNSName = instancePrivateDNSName;
            }

            public string getPrivateDNSName()
            {
                return privateDNSName;
            }

            public void setPublicDNSName(string instancePublicDNSName)
            {
                publicDNSName= instancePublicDNSName;
            }

            public string getPublicDNSName()
            {
                return publicDNSName;
            }

            public void setSG(List<string> sglist )
            {
                securitygroups = sglist;
            }

            public List<string> getSG()
            {
                return securitygroups;
            }



            //---------------------------------------------

            public void setPlatform(string platformVals)
            {
                platform = platformVals;
            }

            public string getPlatforms()
            {
                return platform;
            }


            public void setState(string inststate)
            {
                state = inststate;
            }

            public string getState()
            {
                return state;
            }

            public void setPlacment(string insplacment)
            {
                placement = insplacment;
            }

            public string getPlacment()
            {
                return placement;
            }

            public void setTagName(string Name)
            {
                    TagName = Name;
            }

            public string getTagName()
            {
                return TagName;
            }

            public void setKeyName(string KName)
            {
                keyname = KName;
            }

            public string getKeyName()
            {
                return keyname;
            }


            public void setVpcId(string vid)
            {
                vpcid = vid;
            }

            public string getVpcId()
            {
                return vpcid;
            }

            public void setSubnetId(string snid)
            {
                subnetId = snid;
            }

            public string getSubnetId()
            {
                return subnetId;
            }

            public void setAmiId(string amid)
            {
                amiId = amid;
            }

            public string getAmiId()
            {
                return amiId;
            }


        }


    }
}
