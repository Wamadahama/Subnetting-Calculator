using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network
{
    /// <summary>
    /// Type of address
    /// </summary>
    public enum AddressTypes
    {
        HostAddress,
        NetworkId,
        Broadcast,
        SubnetMask,
    };
    public class IpAddress
    {    
        ///<summary>
        ///  Address as a string
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///  Array of ints repreesenting the Address
        /// </summary>
        public byte[] AddressArray { get; set; }

        /// <summary>
        /// Type of address (broadcast, host, network id, subnet mask)
        /// </summary>
        public AddressTypes AddressType { get; set; }

        /// <summary>
        /// Converts the ip address to a string in the following format "x.x.x.x"
        /// </summary>
        /// <returns></returns>
        private AddressParser Parser = new AddressParser();
        /// <summary>
        /// Takes a string and builds the object with the string
        /// </summary>
        /// <param name="IpString"></param>
        public IpAddress(string IpString)
        {
            this.Address = IpString;
            this.AddressArray = Parser.TryParse(IpString);
        }

        /// <summary>
        /// Takes an array and builds the object with the array
        /// </summary>
        /// <param name="IpArray"></param>
        public IpAddress(byte[] IpArray)
        {
             this.AddressArray = IpArray; 
             this.Address = Parser.TryParse(IpArray);
        }
       
        /// <summary>
        /// Returns a string represntation of the ip address
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Address;
        }

        /// <summary>
        /// Returns a binary string repesentation of the ip address
        /// </summary>
        /// <returns></returns>
        public string ToBinaryString()
        {
            string ReturnString = "";

            // Convert to binary
            foreach (byte octet in AddressArray)
            {
                string OctetString = Convert.ToString(octet, 2);

                // If the octet isn't 8 characters then prepend the nessecary ammount of zeros to it 
                if (OctetString.Length < 8)
                {
                    int ZeroCount = 8 - OctetString.Length;
                    string PrependString = "";

                    // See Extentions
                    ZeroCount.Times(() => PrependString += "0");

                    // Prepends the string and append a period
                    OctetString = OctetString.Insert(0, PrependString);

                }

                OctetString += ".";
                ReturnString += OctetString;
            }

            return ReturnString.TrimEnd('.');

        }
        /// <summary>
        /// Returns a binary string array representation of the ip address
        /// </summary>
        /// <returns></returns>
        public string[] ToBinaryStringArray()
        {
            string[] ReturnString = new string[3];

            // Convert to binary
            for (int i = 0; i < AddressArray.Length; i++)
            {
                ReturnString[i] += Convert.ToString(AddressArray[i], 2);
            }

            return ReturnString;
        }
        /// <summary>
        /// If the address array is changed then the string needs to be changed and vice versa 
        /// </summary>
        public void UpdateAddress()
        {

        }

    }
}

