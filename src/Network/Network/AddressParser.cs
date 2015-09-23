using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Network
{

    /// <summary>
    /// Parses Ip Address strings or arrays
    /// </summary>
    /// 

    class AddressParser
    {
        public AddressParser() { }

        /// <summary>
        /// Returns an IpAddress object with an input string
        /// </summary>
        /// <param name="AddressString"></param>
        /// <returns></returns>
        public byte[] TryParse(string AddressString)
        {
            // 4 octets of the ip address
            byte[] AddressArray = new byte[3];

            // Cleanup the input address
            AddressString = AddressString.Trim();

            // Count number of periods for a simple way to check if it is a valid ip address
            int OctetCount = AddressString.Count(f => f == '.');

            if (OctetCount == 4)
            {
                // Build array of ints
                string[] OctetArray = AddressString.Split('.');

                for (int i = 0; i < OctetArray.Length; i++)
                    AddressArray[i] = byte.Parse(OctetArray[i]);
                return AddressArray;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns an IpAddress object with an bytw array
        /// </summary>
        /// <param name="AddressArray"></param>
        /// <returns></returns>
        public string TryParse(byte[] AddressArray)
        {
            string AddressString = "";

            bool validAddress = true;
            // Validate address array by checking for nulls 
            for (int i = 0; i < AddressArray.Length; i++)
            {
                if (AddressArray[i] == null || AddressArray[i] > 255)
                {
                    validAddress = false;
                }
            }

            if (validAddress)
            {
                // Build address string 
                for (int i = 0; i < AddressArray.Length; i++)
                {
                    AddressString += AddressArray[i].ToString();
                    // On the last iteration we do not want to add a .
                    if (i == AddressArray.Length)
                    {
                        continue;
                    }
                    else
                    {
                        AddressString += ".";
                    }
                }
                return AddressString;
            }
            else
            {
                return "Unable to parse address";
            }
        }
    }
}
