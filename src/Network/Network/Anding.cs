using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class Ander
    {
        public Ander()
        {

        }

        public IpAddress AndAddress(IpAddress Ip, IpAddress Subnetmask)
        {
            AddressParser Parser = new AddressParser();
            byte[] AndedAddress = new byte[3];


            for (int i = 0; i < Ip.AddressArray.Length; i++)
            {
                AndedAddress[i] = (byte)(Ip.AddressArray[i] & Subnetmask.AddressArray[i]);
            }

            IpAddress ReturnAddress = new IpAddress(AndedAddress);
            return ReturnAddress;
        }
    }
}
