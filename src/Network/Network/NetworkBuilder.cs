using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            int NumberOfHostsNeeded = Info.NumberOfHosts;
            int RequiredSubnets = Info.RequiredSubnets;
            string AddressClass = DetermineNessecaryAddressClass(NumberOfHostsNeeded);
            int BitsToBorrow = DetermineBitsToBorrow(NumberOfHostsNeeded);
          
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

        private int DetermineBitsToBorrow(int numberOfHostsNeeded)
        {
            // This method will use the base of two and compare it to the number of hosts needed
            const int Base = 2;
            int Power = 2;
            int UsableHosts; 
            while (true)
            {

                UsableHosts = IntPow(Base, Power);
                Power++;

                if ((UsableHosts-2) >= numberOfHostsNeeded)
                {
                    return UsableHosts;
                }
            }
        }

        private enum AddressClass
        {
            A,
            B,
            C
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
