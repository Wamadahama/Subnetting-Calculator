﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Ander
    {
        public Ander()
        {

        }

        public IpAddress AndAddress(IpAddress Ip, SubnetMask Subnetmask)
        {
            AddressParser Parser = new AddressParser();
            byte[] AndedAddress = new byte[4];


            for (int i = 0; i < Ip.AddressArray.Length; i++)
            {
                AndedAddress[i] = (byte)(Ip.AddressArray[i] & Subnetmask.AddressArray[i]);
            }

            IpAddress ReturnAddress = new IpAddress(AndedAddress);
            return ReturnAddress;
        }
    }
}
