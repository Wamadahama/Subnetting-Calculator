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
        /// <summary>
        /// Initialization of the Class variable nessecary for building the subnet
        /// </summary>
        /// <param name="AddressClass"></param>
        /// <param name="SubnetNumber"></param>
        public SubnetBuilder(string AddressClass, int SubnetNumber, int BitsBorrowed)
        {
            _Class = AddressClass;
            _SubnetNumber = SubnetNumber;
        }

        public Subnetwork BuildSubnet(int SubnetNumber)
        {
            Subnetwork subNetwork = new Subnetwork();
            List<IpAddress> Addresses;
            AddressParser Parser = new AddressParser();
            return subNetwork;

        }
    }
}
