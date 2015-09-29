using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class NetworkBuilder
    {
        /// <summary>
        /// Built upon construction of the class this will contain subnet objects which will then in turn contain ip addresses
        /// </summary>
        public FullNetwork BuiltNetwork { get; set; }
        public NetworkBuilder(NetworkInfo Info)
        {
            // Tracks what subnet needs to be built
            int SubnetNumber;

            int NumberOfHostsNeeded = Info.NumberOfHosts;
            int RequiredSubnets = Info.RequiredSubnets;
            string AddressClass = DetermineNessecaryAddressClass(NumberOfHostsNeeded);
          
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

        private List<Subnetwork> DetermineSubnets(string Class)
        {
            List<Subnetwork> Subnets;
            
        }

        private enum AddressClass
        {
            A,
            B,
            C
        }
    }
}
