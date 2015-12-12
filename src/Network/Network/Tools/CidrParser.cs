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
            int CidrValue = 0;
            // Trim and parse input 
            bool isValidNumber = int.TryParse(CidrString.Trim('/'), out CidrValue);

            int BitCount;
            int FullOctetCount = 0;


            if (isValidNumber)
            {
                // if it is >/7 then we only need the bit count
                if (CidrValue < 8)
                {
                    BitCount = CidrValue;
                }
                else
                {
                    // Gets the ammount of populated octets and the ammount of bits in the next octet 
                    FullOctetCount = CidrValue / 8;
                    BitCount = CidrValue % 8;
                }

                byte [] AddressArray = new byte[4];

                int ZeroCount = 8 - BitCount;

                // Declared on the outside because I need to know what octet it ended on
                int OctetIterator = 0;
                for (OctetIterator = 0; OctetIterator < FullOctetCount; OctetIterator++)
                {
                    AddressArray[OctetIterator] = 255;
                }

                // Build the binary for the last octet if the bit count is > 0
                // There has got to be a better way to build a binary string
                if (BitCount > 0)
                {
                    string BinaryString = "";
                    for (int i = 0; i < BitCount; i++)
                    {
                        BinaryString += "1";
                    }

                    for (int i = 0; i < ZeroCount; i++)
                    {
                        BinaryString += "0";

                    }

                    AddressArray[OctetIterator] = (byte)Convert.ToInt32(BinaryString, 2);
                }

                IpAddress ReturnAddress = new IpAddress(AddressArray);
                return ReturnAddress.ToString();

            }
            else
            {
                return "Invalid CIDR notation";
            }
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
