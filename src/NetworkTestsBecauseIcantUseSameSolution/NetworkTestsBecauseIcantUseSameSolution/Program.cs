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
        
        enum TestEnum
        {
            A = 32,
            B = 64,
            C = 128
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
