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
            FullNetwork Network = new FullNetwork();

            NetworkInfo Info = new NetworkInfo();
            // Deprecated
            Info.Class = AddressClass.C;
            Info.NumberOfHosts = 28;
            Info.RequiredSubnets = 8;
            NetworkBuilder Builder = new NetworkBuilder(Info);
        }


        // Test
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
