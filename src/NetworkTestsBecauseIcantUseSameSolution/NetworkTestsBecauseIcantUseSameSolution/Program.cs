using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network;
using NetworkTests.Tools;

namespace NetworkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            FullNetwork Network = new FullNetwork();

            NetworkInfo Info = new NetworkInfo();
            // Deprecated
            Info.Class = AddressClass.B; // Deprecated 
            Info.NumberOfHosts = 14;
            Info.RequiredSubnets = 2;
            Info.SampleAddress = "192.168.5.23";
            NetworkBuilder Builder = new NetworkBuilder(Info);

            SubnetDataWriter Datawriter = new SubnetDataWriter();
            Datawriter.WriteSubnetData(Builder.BuiltNetwork);
            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork);
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
