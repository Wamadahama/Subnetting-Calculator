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
            _HostsPerSubnet = NetMask.UsableHostsPerSubnet;
            _SampleAddress = ParseBaseAddress(BaseAddress);

        }


        /// <summary>
        /// Returns the next subnet in the sequence 
        /// </summary>
        /// <returns></returns>
        public Subnetwork NextSubnet()
        {
            // Will be returned to the network buidler class
            Subnetwork ReturnNetwork = new Subnetwork();

            int lastUsable = _HostsPerSubnet * _SubnetNumber;
            int broadCastAddress = lastUsable + 1;
            int subnetId = broadCastAddress - lastUsable;
            int firstUsable = subnetId + 1;

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
