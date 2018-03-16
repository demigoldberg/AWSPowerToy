using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

//using Amazon;
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
            List<string> bdevicelist;

            try
            {
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
                        bdevicelist = new List<string>();

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

                        // EC2Ins.setBlockDevice()
                        //  instance.BlockDeviceMappings

                        foreach (InstanceBlockDeviceMapping bdevice in instance.BlockDeviceMappings)
                        {
                            //  string bdstr = bdevice.DeviceName  + ":"  + ":" + bdevice.Ebs; bdevice.
                            bdevicelist.Add(bdevice.DeviceName + ":" + ":" + bdevice.Ebs.Status + ":" + bdevice.Ebs.VolumeId);

                        }

                        EC2Ins.setSG(sgstrlist);

                        foreach (GroupIdentifier sgi in instance.SecurityGroups)
                        {

                            sgstrlist.Add(sgi.GroupId);
                            // sgi.GroupId


                        }

                        EC2Ins.setBlockDevice(bdevicelist);

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
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n"); // + ex.StackTrace);
              
            }

            return ec2list;



        }
//####################################################################################

        public string StartInstance(IAmazonEC2 ec2, string instidstr)
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

                stopInstancesResponse = ec2.StopInstances(stopreq);


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

            //  insttype = InstanceType.C1Medium.ToString();

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

                return "Image ID was created " + ImageResponse.ImageId;

            }
            catch (Exception ex)
            {

                return (ex.Message + "\n" + ex.StackTrace);

            }


        }

        //############################################################################################

        public string lunchInstance(IAmazonEC2 ec2, string ami, string subnetid, string Key, string insttype, List<string> secgroupid, bool publicip,string vpc,string NewSG,string privateIP,string Nametag ,int rootDiskSize)
        //create new instance          
        {
            RunInstancesResponse launchResponse;
            string subnetID = subnetid; // "subnet-2e107b76";
            string amiID = ami; // "ami-c51e3eb6";
            string keyPairName = Key; // "sirin-staging";
            string itype = insttype; // "t2.small";
          
            // List<string> groups = new List<string>() { "sg-9f90e2f9" };
            List<string> groups = secgroupid; // new List<string>() { secgroupid };

            if (NewSG.Length > 0) // create and add a new security group
            {
                try
                {
                    //SG.GroupName = "AccessGP";
                    SecurityGroup SG = new SecurityGroup();
                    SG = CreateSecurityGroup(ec2, NewSG, vpc);

                   

                    groups.Add(SG.GroupId);
                }
                catch (Exception ex)
                {
                    return (ex.Message + "\n" + ex.StackTrace);
                }

            }
            try
            {
                var eni = new InstanceNetworkInterfaceSpecification()
                {
                    DeviceIndex = 0,
                    SubnetId = subnetID,
                    Groups = groups,
                    AssociatePublicIpAddress = publicip
                };
                if (privateIP.Length > 0)
                {
                    eni.PrivateIpAddress = privateIP;
                    // eni.PrivateIpAddress = "10.1.200.200";
                }



                List<InstanceNetworkInterfaceSpecification> enis = new List<InstanceNetworkInterfaceSpecification>() { eni };

                var launchRequest = new RunInstancesRequest()
                {
                    ImageId = amiID,
                    InstanceType = itype,
                    MinCount = 1,
                    MaxCount = 1,
                    KeyName = keyPairName,
                    NetworkInterfaces = enis

                    // TagSpecifications = "protectorx"
                };

                if (rootDiskSize != 0)
                {
                    BlockDeviceMapping mapping = new BlockDeviceMapping
                    {
                        DeviceName = "/dev/sda1",
                        Ebs = new EbsBlockDevice
                        {
                            VolumeType = VolumeType.Gp2,
                            VolumeSize = rootDiskSize
                        }

                    };

                    List<BlockDeviceMapping> mappinglist;
                    mappinglist = new List<BlockDeviceMapping>();
                    mappinglist.Add(mapping);
                    launchRequest.BlockDeviceMappings = mappinglist;

                }
               

          // ------------------------- add tag ----------------------------------------------------     

                List<Amazon.EC2.Model.Tag> TagList;
                TagSpecification Tagspec;

                Amazon.EC2.Model.Tag EC2tag;

                //Amazon.EC2.Model.resorc
                EC2tag = new Amazon.EC2.Model.Tag();
                EC2tag.Key = "Name";
                EC2tag.Value = Nametag;
                //EC2tag.GetType
                 
                TagList = new List<Amazon.EC2.Model.Tag>();
                TagList.Add(EC2tag);

                // EC2tag();



                Tagspec = new Amazon.EC2.Model.TagSpecification();
                Tagspec.ResourceType = ResourceType.Instance ;
                    //TagSpecification(){ResourceType.Instance};
                //Tagspec.Tags.OfType<Instance>;
                Tagspec.Tags = TagList;
                

                launchRequest.TagSpecifications.Add(Tagspec);
                //ec2.RunInstances(launchRequest);
                launchResponse = ec2.RunInstances(launchRequest);
                return "Done";
            }
            catch (Exception ex)
            {
                return (ex.Message + "\n" + ex.StackTrace);
            }

        }


        public List<string> GetListOfEC2Types()
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


   // #############################################################################################

        SecurityGroup CreateSecurityGroup(IAmazonEC2 ec2, string secGroupName,string vpc)
        {
            SecurityGroup MySG;
            Amazon.EC2.Model.Filter nameFilter = new Amazon.EC2.Model.Filter();
            nameFilter.Name = "group-name";
            nameFilter.Values = new List<string>() { secGroupName };

            var describeRequest = new DescribeSecurityGroupsRequest();
            describeRequest.Filters.Add(nameFilter);
            var describeResponse = new DescribeSecurityGroupsResponse();
            describeResponse = ec2.DescribeSecurityGroups(describeRequest);
          
            if (describeResponse.SecurityGroups.Count > 0)
               {

                //return describeResponse.SecurityGroups[0];
                MySG= describeResponse.SecurityGroups[0];
                MySG = AddSGIPrermissions(ec2, MySG);
                return MySG;
            }
           
           
            var createRequest = new CreateSecurityGroupRequest();
            createRequest.GroupName = secGroupName;
            createRequest.VpcId = vpc;
            createRequest.Description = "My sample security group for EC2-Classic";

            var createResponse = new CreateSecurityGroupResponse();
            //createResponse = CreateSecurityGroupResponse(createRequest);
            var Groups = new List<string>() { createResponse.GroupId };

         
            createResponse = ec2.CreateSecurityGroup(createRequest);

            MySG = new SecurityGroup();

            MySG.GroupId = createResponse.GroupId;
            MySG.VpcId = vpc;

            MySG = AddSGIPrermissions(ec2, MySG);
            

            return MySG;

           // ec2.des
        }


        SecurityGroup AddSGIPrermissions (IAmazonEC2 ec2,  SecurityGroup SG)
        {

            string ipRange = "0.0.0.0/0";
            List<string> ranges = new List<string>() { ipRange };
            var ipPermission1 = new IpPermission();
            ipPermission1.IpProtocol = "tcp";
            ipPermission1.FromPort = 22;
            ipPermission1.ToPort = 22;
            ipPermission1.IpRanges = ranges;

            var ipPermission2 = new IpPermission();
            ipPermission2.IpProtocol = "tcp";
            ipPermission2.FromPort = 3389;
            ipPermission2.ToPort = 3389;
            ipPermission2.IpRanges = ranges;

            // MessageBox.Show(SG.GroupId);
            //  foreach ( IpPermission ipper in SG.IpPermissions)
            //     {
            //       ipper.FromPort
            //
            //     }

            try
            {

                SG.IpPermissions.Add(ipPermission1);
                SG.IpPermissions.Add(ipPermission2);
                AuthorizeSecurityGroupIngressRequest authorizeSecurityGroupIngressRequest = new AuthorizeSecurityGroupIngressRequest();
                authorizeSecurityGroupIngressRequest.GroupId = SG.GroupId;
                //authorizeSecurityGroupIngressRequest.GroupName = MySG.GroupName;
                authorizeSecurityGroupIngressRequest.IpPermissions.Add(ipPermission1);
                authorizeSecurityGroupIngressRequest.IpPermissions.Add(ipPermission2);
                ec2.AuthorizeSecurityGroupIngress(authorizeSecurityGroupIngressRequest);
                
              
            }

            catch (Exception ex)
            {

            }

            return SG;
        }


        //###############################################################

        public string AddVolume(IAmazonEC2 ec2,string instidstr, string name , int size)
        {

            https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/EC2/TCreateVolumeRequest.html


            try
            {
                ModifyInstanceAttributeRequest ModifyRequest = new ModifyInstanceAttributeRequest();
                ModifyInstanceAttributeResponse ModifyResponse = new ModifyInstanceAttributeResponse();
                
               
                ModifyRequest.InstanceId = instidstr;


                BlockDeviceMapping mapping = new BlockDeviceMapping
                {
                    DeviceName = name,
                    
                    Ebs = new EbsBlockDevice
                    {
                        VolumeType = VolumeType.Gp2,
                        VolumeSize = size

                    }

                };
                
                List<BlockDeviceMapping> mappinglist;
                mappinglist = new List<BlockDeviceMapping>();
                mappinglist.Add(mapping);

                
               List <InstanceBlockDeviceMappingSpecification> BDMSpecList;
               BDMSpecList = new List <InstanceBlockDeviceMappingSpecification>();

                InstanceBlockDeviceMappingSpecification BDMSpec = new InstanceBlockDeviceMappingSpecification
                {
                    DeviceName = name,
                    
                                     
                    Ebs = new EbsInstanceBlockDeviceSpecification
                    {

                       VolumeId = "sdsd"
                       
                     //VolumeType = VolumeType.Gp2,
                    // VolumeSize = size
                      }
                    };



                    //= mapping;
                    BDMSpecList.Add(BDMSpec);
                //ModifyRequest.Attribute.Value.
               //--- ModifyRequest.BlockDeviceMappings.Add(BDMSpecList);

                return "Done";
              

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }

          
            //launchRequest.BlockDeviceMappings = mappinglist;

        }


   


        //###################################################################


         void GetAWSImages(IAmazonEC2 ec2)
        {

          //  var images = ec2.DescribeImages(new DescribeImagesRequest() { Filters = new List() { new Amazon.EC2.Model.Filter("name", new List() { amiName }) } })


           // var images = client.DescribeImages(new DescribeImagesRequest() { Filters = new List() { new Filter("name", new List() { amiName }) } });
           // return images.Images.Single().ImageId;

        }

//###############



        //###################################################################


       

//###############


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
            private List<string> blockdevices;


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

            public void setBlockDevice(List<string> bdlist)
            {
                blockdevices = bdlist;
            }

            public List<string> getBlockDevice()
            {
                return blockdevices;
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
