namespace Network
{
    /// <summary>
    /// Inherited by the IpAddress class, will be used to contain data like addresses per subnet and bits borrowed
    /// </summary>
    public class SubnetMask : IpAddress
    {
        /// <summary>
        /// Address per subnet 
        /// </summary>
        public int AddressesPerSubnet { get; set; }
        /// <summary>
        /// Used to determine the number of usable hosts per subnet
        /// </summary>
        public int UsableHostsPerSubnet { get; set; }

        public int BitsBorrowed { get; set; }

        public IpAddress SampleAddress { get;  set}
        /// <summary>
        /// Builds the class with an array of bytes
        /// </summary>
        /// <param name="IpArray"></param>
        public SubnetMask(byte[] IpArray) : base(IpArray)
        {

        }

        /// <summary>
        /// Builds the object with a string 
        /// <code>ie : "255.255.255.0"</code>
        /// </summary>
        /// <param name="IpString"></param>
        public SubnetMask(string IpString) : base(IpString)
        {

        }
    }
}