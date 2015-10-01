using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class SubnetBuilder
    {
        private string _Class;
        private int _SubnetNumber;
        private int _HostsPerSubnet;
        private int _SampleAddress;

        /// <summary>
        /// Initialization of the Class variable nessecary for building the subnet
        /// </summary>
        /// <param name="AddressClass"></param>
        /// <param name="SubnetNumber"></param>
        public SubnetBuilder(SubnetMask NetMask)
        {
            _SubnetNumber = 1;
            _HostsPerSubnet = NetMask.UsableHostsPerSubnet;
        }

        /// <summary>
        /// Returns the next subnet in the sequence
        /// </summary>
        /// <returns></returns>
        public Subnetwork NextSubnet()
        { 
            Subnetwork SN = new Subnetwork();
            Ander BinaryAnder = new Ander();
            
            IpAddress FirstUsable;
            IpAddress LastUsable;
            IpAddress BroadCast;
            IpAddress NetworkId;

            // Get the network ID
            NetworkId = BinaryAnder.AndAddress() 
        }
    }
}
