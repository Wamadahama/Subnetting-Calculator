using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class BitCalculator
    {
        private string _Class;
        private int _HostsPerSubnet;

        public BitCalculator(string Class, int HostCount)
        {
            _Class = Class;
            _HostsPerSubnet = HostCount;
        }

        public int DetermineBitsNeededToBorrow()
        {
            int BitCount;

        }

        // The maximum bits that can be borrowed
        private enum MaxBits
        {
            A = 23,
            B = 15,
            C = 7
        }
    }
}
