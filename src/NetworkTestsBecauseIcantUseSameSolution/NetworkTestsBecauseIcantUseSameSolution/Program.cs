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
            TestEnum test = new TestEnum();
        }

<<<<<<< HEAD
            NetworkInfo Info = new NetworkInfo();
            Info.NumberOfHosts = 29;
            Info.RequiredSubnets = 8;
            NetworkBuilder Builder = new NetworkBuilder(Info);
=======
        enum TestEnum
        {
            A = 32,
            B = 64,
            C = 128
>>>>>>> 663bab0b7add804824dd4d18c4f5426306ce4b92
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
