using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{

    // Will contain information that is submitted by the user and used by the a parser to build the classes
    public struct NetworkInfo
    {
        public AddressClass Class;
        public int NumberOfHosts;
        public int RequiredSubnets;
        public string SampleAddress;
    }
    // Used in the network info class for address classification
    public enum AddressClass
    {
       A,
       B,
       C
    }
}
