using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Tracks what subnet needs to be built
            int SubnetNumber;

            // Get the data to build the subnet mask  
            int NumberOfHostsNeeded = Info.NumberOfHosts;
            int RequiredSubnets = Info.RequiredSubnets;
            string AddressClass = DetermineNessecaryAddressClass(NumberOfHostsNeeded);
            int BitsToBorrow = DetermineBitsToBorrow(NumberOfHostsNeeded);

            SubnetMask NetMask = GetSubnetAddress(AddressClass ,BitsToBorrow);

            // Parse Sample Address
            IpAddress SampleAddress = new IpAddress(Info.SampleAddress);
            IpAddress BaseAddress;
            BaseAddress = ParseSampleAddress(SampleAddress, AddressClass);

            // Begin the subnet building process
            SubnetBuilder SubnetBuilder = new SubnetBuilder(NetMask, BaseAddress);
         }

        /// <summary>
        /// Parses the sample input address
        /// </summary>
        /// <param name="sampleAddress"></param>
        /// <returns>IpAddress BaseAddress</returns>
        private IpAddress ParseSampleAddress(IpAddress sampleAddress, string AddressClass)
        {
            
            int NumberOfOctets = 0;

            switch (AddressClass)
            {
                case "A":
                    NumberOfOctets = 1;
                    break;
                case "B":
                    NumberOfOctets = 2;
                    break;
                case "C":
                    NumberOfOctets = 3;
                    break;
                default:
                    NumberOfOctets = 3;
                    break;
            }

            
            byte[] addressArray = new byte[3];

            for (int i = 0; i < NumberOfOctets; i++)
            {
                addressArray[i] = sampleAddress.AddressArray[i]; 
            }

            return new IpAddress(addressArray);
        }

        /// <summary>
        /// Determines the address class that will be needed
        /// </summary>
        /// <param name="numberOfHostsNeeded"></param>
        /// <param name="requiredSubnets"></param>
        /// <returns></returns>
        private string DetermineNessecaryAddressClass(int numberOfHostsNeeded)
        {
            string AddressClass = "";
            // Class A, rounded down for scalability purposes 
            if (numberOfHostsNeeded > 65500)
            {
                AddressClass = "A";
            }
            else if (numberOfHostsNeeded > 254)
            {
                AddressClass = "B";
            }
            else
            {
                AddressClass = "C";
            }
            return AddressClass;
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
        private SubnetMask GetSubnetAddress(string AddressClass, int BitsBorrowed)
        {
            // Use the address class to determine what the defaul subnet mask is 
            byte[] BaseAddress;

            switch (AddressClass)
            {
                case "A":
                    BaseAddress = new byte[] { 255, 0, 0, 0 };
                    break;
                case "B":
                    BaseAddress = new byte[] { 255, 255, 0, 0 };
                    break;
                case "C":
                    BaseAddress = new byte[] { 255, 255, 255, 0 };
                    break;
                default:
                    BaseAddress = new byte[] { 255, 255, 255, 0 };
                    break;                   
            }

            int FirstIndexOfZero = Array.IndexOf(BaseAddress, 0);
            int NumberOfSubnettedOctets = 0;

            if (BitsBorrowed > 16)
            {
                NumberOfSubnettedOctets = 3;
            }
            else if (BitsBorrowed > 8)
            {
                NumberOfSubnettedOctets = 2;
            }
            else
            {
                NumberOfSubnettedOctets = 1;
            }


            // Use json to get the subnet.
            StreamReader FileReader = new StreamReader("SubnetData\\" + AddressClass + ".json");
            dynamic JsonData = JsonConvert.DeserializeObject(FileReader.ReadToEnd());

            byte[] AddressArray = new byte[3];
            AddressArray = JsonData[BitsBorrowed.ToString()];
            SubnetMask ReturnSubnet = new SubnetMask(AddressArray);     

            // Build the subnet mask object that will contain the nessecary information to build the addressing scheme
            SubnetMask ReturnAddress = new SubnetMask(BaseAddress);
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
