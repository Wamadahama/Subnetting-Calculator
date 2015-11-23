using System;
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
        public FullNetwork BuiltNetwork;

        public NetworkBuilder(NetworkInfo Info)
        {
            //// Get the nessecary data to build the subnetting information 

            //int NumberOfHostsNeeded = Info.NumberOfHosts;

            //// The nessecary address class for the number of subnets and the required hosts per subnet 
            //AddressClass InetClass = DetermineNessecaryAddressClass(NumberOfHostsNeeded);

            //// Uses 2^x to determine how many bits need to be borrowed
            //int BitsToBorrow = DetermineBitsToBorrow(NumberOfHostsNeeded, InetClass);

            //int BitsForAddressSpace = DetermineBitsForAddressSpace(BitsToBorrow, InetClass);

            //int RequiredSubnets = DetermineNumberOfSubnets(BitsToBorrow, InetClass);

            int BitsToBorrow = DetermineBitsToBorrow(Info.RequiredSubnets);

            AddressClass InetClass = DetermineNessecaryAddressClass(Info.NumberOfHosts);

            int AddressSpaceBits = DetermineBitsForAddressSpace(BitsToBorrow, InetClass);

            int RequiredSubnets = IntPow(2, BitsToBorrow);


            if (RequiredSubnets == -1) 
            {
                // TO DO error handling
            }

            // Gets the subnet mask using data resources basedo n the required bits to borrow 
            SubnetMask NetMask = GetSubnetAddress(InetClass, BitsToBorrow, AddressSpaceBits);
            IpAddress SampleAddress = new IpAddress(Info.SampleAddress);

            // The program has different functionallity based on different address class
            // For Class C it will be able to build the entire subnet out
            // For the other classes it will display generic subnetting information but not build a subnet 
            switch (InetClass)
            {
                case AddressClass.A:
                    BuiltNetwork = new FullNetwork();
                    // Gather network information for Class A 
                    ClassAandBBuilder ClassABuilder = new ClassAandBBuilder();
                    ClassABuilder.NetMask = NetMask;
                    ClassABuilder.HostsPerSubnet = IntPow(2, (AddressSpaceBits - 2) );
                    ClassABuilder.NumberOfSubents = IntPow(2, BitsToBorrow);
                    BuiltNetwork.ClassAorBBuilder = ClassABuilder;
                    break;
                case AddressClass.B:
                    BuiltNetwork = new FullNetwork();
                    ClassAandBBuilder ClassBBuilder = new ClassAandBBuilder();
                    ClassBBuilder.NetMask = NetMask;
                    ClassBBuilder.HostsPerSubnet = IntPow(2, AddressSpaceBits);
                    ClassBBuilder.NumberOfSubents = IntPow(2, BitsToBorrow);
                    BuiltNetwork.ClassAorBBuilder = ClassBBuilder;
                    break;
                case AddressClass.C:
                    // Gather network information for Class C
                    int SubnetCount = 0;
                    BuiltNetwork = new FullNetwork();
                    // Begin the subnet building process
                    ClassCSubnetBuilder ClassCBuilder = new ClassCSubnetBuilder(NetMask, SampleAddress);
                    // Subtraction by one because it is a based of zero 
                    while (SubnetCount < RequiredSubnets)
                    {
                        SubnetCount += 1;
                        var Subnet = ClassCBuilder.NextSubnet();
                        BuiltNetwork.Subnets.Enqueue(Subnet);
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
        /// Determines the number of bits needed to borrow for based on the required subnets
        /// </summary>
        /// <param name="numberOfHostsNeeded"></param>
        /// <returns></returns>
        private int DetermineBitsToBorrow(int requiredSubnets)
        {
            // This method will use the base of two and compare it to the number of hosts needed
            const int Base = 2;
            int Power = 1;
            int SubnetCount;
            // Walks up the power to two and compares it to the hosts that are needed
            while (true)
            {
                 SubnetCount = IntPow(Base, Power);

                if (SubnetCount >= requiredSubnets)
                {
                    return Power;
                }

                Power++;
            }
        }

        private int DetermineBitsForAddressSpace(int BitsBorrowed, AddressClass Class)
        {
            switch (Class)
            {
                case AddressClass.A:
                    return 24 - BitsBorrowed;
                case AddressClass.B:
                    return 16 - BitsBorrowed;
                case AddressClass.C:
                    return 8 - BitsBorrowed;
                default:
                    return -1;
            }
        }
      
        private int DetermineNumberOfSubnets(int BitsBorrowed, AddressClass Class)
        {
            // For clarity
            const int BITS_PER_SUBNET = 32;


            // Determine the number of subnets that will be needed by taking the ammount of bits in a full mask (32), then
            // subtracting it by the base ammount of bits in that subnet:
            // - Class A = 8
            // - Class B = 16
            // - Class C = 24
            // Then subtracting it by the number of bits borrowed and returning the power of it 
            int bitsLeft = 0;

            switch (Class)
            {
                case AddressClass.A:
                    bitsLeft = (BITS_PER_SUBNET - 8) - BitsBorrowed;
                    return IntPow(2, bitsLeft);
                case AddressClass.B:
                    bitsLeft = (BITS_PER_SUBNET - 16) - BitsBorrowed;
                    return IntPow(2, bitsLeft);
                case AddressClass.C:
                    bitsLeft = (BITS_PER_SUBNET - 24) - BitsBorrowed;
                    return IntPow(2, bitsLeft);
                default:
                    return -1;
            }
        }
        private int AddressesPerSubnet(int BitsBorrowed)
        {
            return (IntPow(2, BitsBorrowed));
        }

        /// <summary>
        /// Uses the ammount of bits bowrowed to determine the subnetmask
        /// </summary>
        /// <returns></returns>
        private SubnetMask GetSubnetAddress(AddressClass AddrClass, int BitsBorrowed, int AddressBits)
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

            // Get local resource dictionary 
            var assembly = typeof(IpAddress).GetTypeInfo().Assembly;
            string[] Resources = assembly.GetManifestResourceNames();

            // Load resources based on address class
            Stream fileStream = assembly.GetManifestResourceStream("Network.SubnetData." + AddrClass.ToString() + ".json");
            StreamReader Reader = new StreamReader(fileStream);

            // Parse json from resources 
            string contents = Reader.ReadToEnd();
            dynamic JsonData = JsonConvert.DeserializeObject(contents);

            // Determine Address class
            string AddressString = "";
            AddressString = JsonData[BitsBorrowed.ToString()];

            // Build the subnet mask object that will contain the nessecary information to build the addressing scheme
            SubnetMask ReturnAddress = new SubnetMask(AddressString);
            ReturnAddress.BitsBorrowed = BitsBorrowed;
            ReturnAddress.UsableHostsPerSubnet = AddressesPerSubnet(AddressBits);
            ReturnAddress.AddressesPerSubnet = IntPow(2, BitsBorrowed);

            return ReturnAddress;

        }

        [DebuggerStepThrough]
        private int IntPow(int x, int pow)
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
