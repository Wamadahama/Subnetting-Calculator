using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Tools
{
    /// <summary>
    /// Parses a Classless Inter Domain Routing Prefix 
    /// </summary>
    public class CidrParser
    {
        public CidrParser(){ }

        /// <summary>
        /// Takes a CIDR notation string and converts it to a subnet mask string 
        /// </summary>
        /// <param name="CidrString"></param>
        /// <returns></returns>
        public string ParseCidr(string CidrString)
        {
            // Get the number of bits borrowed 
            CidrString = CidrString.Trim('/');
            int BitCount = int.Parse(CidrString);

            // Get the number of octets
            int OctetCount = BitCount / 8;
            int RemainingBits;
            if (BitCount < 8)
            {
                RemainingBits = BitCount % 8;
            }
            else
            {
                RemainingBits = BitCount;
            }
            

            byte[] AddressArray = new byte[4];

            // <= because atleast one will always be 255
            int i;
            for (i = 0; i < OctetCount; i++)
            {
                AddressArray[i] = 255;
            }

            if (RemainingBits > 0)
            {
                string OctetString = "";
                int ZerosCount = 8 - RemainingBits;
                for (int x = 0; x < RemainingBits-1; x++)
                {
                    OctetString += "1";
                }

                for (int x = 0; x < ZerosCount-1; x++)
                {
                    OctetString += "0";
                }

                AddressArray[i] = (byte)Convert.ToInt32(OctetString, 2);
            }
            IpAddress NewAddress = new IpAddress(AddressArray);
            return NewAddress.Address;
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
