using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network;

namespace NetworkTestsBecauseIcantUseSameSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] addrArr = { 10 , 25, 5, 167 };
            byte[] netMask = { 255, 128, 0, 0 };
            IpAddress Ip = new IpAddress(addrArr);
            IpAddress Sn = new IpAddress(netMask);

            Ander binaryAnding = new Ander();

            var Nid = binaryAnding.AndAddress(Ip, Sn);

            PrintAddressInformation(Nid);
            Console.ReadLine();
        }

        static void PrintAddressInformation(IpAddress ip)
        {
            Console.WriteLine(ip.Address);
            foreach (byte oct in ip.AddressArray)
            {
                Console.WriteLine(oct.ToString());
            }
        }
    }
}
