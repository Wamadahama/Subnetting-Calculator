using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class ClassCSubnetBuilder
    {
        private string _Class;
        private int _SubnetNumber;
        private int _HostsPerSubnet;
        private IpAddress _SampleAddress;
        private IpAddress _Netmask;

        /// <summary>
        /// Initialization of the Class variable nessecary for building the subnet
        /// </summary>
        /// <param name="AddressClass"></param>
        /// <param name="SubnetNumber"></param>
        public ClassCSubnetBuilder(SubnetMask NetMask, IpAddress BaseAddress)
        {
            _SubnetNumber = 1;
            // We are casting to a byte here because for class A and class B the count will be greater than 255, but in every other case it will be <255
            _HostsPerSubnet = NetMask.UsableHostsPerSubnet;
            _SampleAddress = BaseAddress;
        }


        /// <summary>
        /// Returns the next subnet in the sequence 
        /// </summary>
        /// <returns></returns>
        public Subnetwork NextSubnet()
        {
            // Will be returned to the network buidler class
            Subnetwork ReturnNetwork = new Subnetwork();
            byte[] BaseAddress = _SampleAddress.AddressArray;

            // Calculate the nessecary information to build the IPs on the subnet
            byte lastUsable = Convert.ToByte(_HostsPerSubnet * _SubnetNumber - 2);
            byte broadCastAddress = Convert.ToByte(lastUsable + 1);

            // HORRID HACK
            // I am Elijah Ellis Please remember my name as I may not 
            // The subnet ID here is a special case because it requires math using subtraction 
            byte subnetId;

            if (_SubnetNumber == 1)
            {
                // I am sorry mom 

                subnetId = 0;
            }
            else
            {
                subnetId = Convert.ToByte(Math.Abs(_HostsPerSubnet - broadCastAddress - 1));
            }

            byte firstUsable = Convert.ToByte(subnetId + 1);

            // TODO: Possibly refactor this section by using the BaseAddress away, but I am scared that it might mutate the contents of the array inproperly 
            // Build Subnet ID and attach it to the return network
            byte[] NetworkIdArray = BaseAddress;
            NetworkIdArray[3] = subnetId;
            IpAddress NetworkID = new IpAddress(NetworkIdArray);
            ReturnNetwork.NetworkId = NetworkID;

            // Build Broadcast address object
            byte[] BroadCastAddressArray = BaseAddress;
            BroadCastAddressArray[3] = broadCastAddress;
            IpAddress BroadcastAddress = new IpAddress(BroadCastAddressArray);
            ReturnNetwork.BroadcastAddress = BroadcastAddress;

            // Build the first usuable
            byte[] FirstUsuableArray = BaseAddress;
            FirstUsuableArray[3] = firstUsable;
            IpAddress FirstUsable = new IpAddress(FirstUsuableArray);
            ReturnNetwork.FirstUsable = FirstUsable;

            // Built the last usable address object
            byte[] LastUsuableArray = BaseAddress;
            LastUsuableArray[3] = lastUsable;
            IpAddress LastUsable = new IpAddress(LastUsuableArray);
            ReturnNetwork.LastUsable = LastUsable;

            // Increment the subnet number for the next calculation
            _SubnetNumber += 1;
            return ReturnNetwork;
        }


        /* Private members */ 

        /// <summary>
        /// Initializes the base address
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <returns></returns>
        private IpAddress ParseBaseAddress(IpAddress baseAddress)
        {
            throw new NotImplementedException();
        }



    }
}
