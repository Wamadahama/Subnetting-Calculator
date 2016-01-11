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

        }
        /// <summary>
        /// If the address array is changed then the string needs to be changed and vice versa 
        /// </summary>
        public void UpdateAddress()
        {

        }
    }
}
