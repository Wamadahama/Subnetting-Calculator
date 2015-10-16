﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Network.Builders;

namespace Network
{
    public class NetworkBuilder
    {
        
          
        /// <summary>
        /// Built upon construction of the class this will contain subnet objects which will then in turn contain ip addresses
        /// </summary>
        public FullNetwork BuiltNetwork { get; set; }

        public NetworkBuilder(NetworkInfo Info)
        {
           
            // Get the nessecary data to build the subnetting information 

            int NumberOfHostsNeeded = Info.NumberOfHosts;
            int RequiredSubnets = Info.RequiredSubnets;
            
            // The nessecary address class for the number of subnets and the required hosts per subnet 
            AddressClass InetClass = DetermineNessecaryAddressClass(NumberOfHostsNeeded);

            // Uses 2^x to determine how many bits need to be bowwrows
            int BitsToBorrow = DetermineBitsToBorrow(NumberOfHostsNeeded);

            // Gets the subnet mask using data resources basedo n the required bits to borrow 
            SubnetMask NetMask = GetSubnetAddress(InetClass, BitsToBorrow);
            IpAddress SampleAddress = new IpAddress(Info.SampleAddress);

            // The program has different functionallity based on different address class
            // For Class C it will be able to build the entire subnet out
            // For the other classes it will display generic subnetting information but not build a subnet 
            switch (InetClass)
            {
                case AddressClass.A:
                    // Gather network informatio for Class A 
                    ClassAandBBuilder ClassABuilder = new ClassAandBBuilder();
                    break;
                case AddressClass.B:
                    ClassAandBBuilder ClassBBuilder = new ClassAandBBuilder();
                    // Gather network information for Class B
                    break;
                case AddressClass.C:
                    // Gather network information for Class C
                    int SubnetCount = 0; 
                    // Begin the subnet building process
                    ClassCSubnetBuilder SubnetBuilder = new ClassCSubnetBuilder(NetMask, SampleAddress);
                    
                    while (SubnetCount < RequiredSubnets)
                    {
                        BuiltNetwork.Subnets.Add(SubnetBuilder.NextSubnet());
                    }
                    break;
                default:
                    break;
            }

            
         }


        /* Private members */

        /// <summary>
        /// Determines the address class that will be needed
        /// </summary>
        /// <param name="numberOfHostsNeeded"></param>
        /// <param name="requiredSubnets"></param>
        /// <returns></returns>
        private AddressClass DetermineNessecaryAddressClass(int numberOfHostsNeeded)
        {
            AddressClass Class; 
            // Class A, rounded down for scalability purposes 
            if (numberOfHostsNeeded > 65500)
            {
                Class = AddressClass.A;
            }
            else if (numberOfHostsNeeded > 254)
            {
                Class = AddressClass.B;
            }
            else
            {
                Class = AddressClass.C;
            }
            return Class;
        }

        /// <summary>
        /// Determines the number of bits needed to borrow for based on the host counts
        /// </summary>
        /// <param name="numberOfHostsNeeded"></param>
        /// <returns></returns>
        private int DetermineBitsToBorrow(int numberOfHostsNeeded)
        {
            // This method will use the base of two and compare it to the number of hosts needed
            const int Base = 2;
            int Power = 2;
            int UsableHosts;
            // Walks up the power to two and compares it to the hosts that are needed
            while (true)
            {
                UsableHosts = IntPow(Base, Power);

                if ((UsableHosts - 2) >= numberOfHostsNeeded)
                {
                    return Power;
                }

                Power++;
            }
        }

        private int HostsPerSubnet(int BitsBorrowed)
        {
            return (IntPow(2, BitsBorrowed) - 2);
        }

        /// <summary>
        /// Uses the ammount of bits bowrowed to determine the subnetmask
        /// </summary>
        /// <returns></returns>
        private SubnetMask GetSubnetAddress(AddressClass AddrClass, int BitsBorrowed)
        {
            // Use the address class to determine what the defaul subnet mask is 
            byte[] BaseAddress;

            // Builts a base subnet with the address class
            switch (AddrClass)
            {
                case AddressClass.A:
                    BaseAddress = new byte[] { 255, 0, 0, 0 };
                    break;
                case AddressClass.B:
                    BaseAddress = new byte[] { 255, 255, 0, 0 };
                    break;
                case AddressClass.C:
                    BaseAddress = new byte[] { 255, 255, 255, 0 };
                    break;
                default:
                    BaseAddress = new byte[] { 255, 255, 255, 0 };
                    break;
            }

            int FirstIndexOfZero = Array.IndexOf(BaseAddress, 0);
            //int NumberOfSubnettedOctets;
            //if (BitsBorrowed > 16)
            //{
            //    NumberOfSubnettedOctets = 3;
            //}
            //else if (BitsBorrowed > 8)
            //{
            //    NumberOfSubnettedOctets = 2;
            //}
            //else
            //{
            //    NumberOfSubnettedOctets = 1;
            //}


            // Use json to get the subnet
            // Absolutely astonished that I cant use system.io.file
            var assembly = typeof(IpAddress).GetTypeInfo().Assembly;
            string[] Resources = assembly.GetManifestResourceNames();
            Stream fileStream = assembly.GetManifestResourceStream("Network.SubnetData." + AddrClass.ToString() + ".json");
            StreamReader Reader = new StreamReader(fileStream);
            string contents = Reader.ReadToEnd();
            dynamic JsonData = JsonConvert.DeserializeObject(contents);

            string AddressString = "";
            AddressString = JsonData[BitsBorrowed.ToString()];

            // Build the subnet mask object that will contain the nessecary information to build the addressing scheme
            SubnetMask ReturnAddress = new SubnetMask(AddressString);
            ReturnAddress.BitsBorrowed = BitsBorrowed;
            ReturnAddress.UsableHostsPerSubnet = HostsPerSubnet(BitsBorrowed);
            ReturnAddress.AddressesPerSubnet = IntPow(2, BitsBorrowed);

            return ReturnAddress;

        }

        [DebuggerStepThrough]
        int IntPow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }
}