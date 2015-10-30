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


            NetworkInfo Info;
            NetworkBuilder Builder;
            
            Info = new NetworkInfo();
            // Deprecated
            Info.Class = AddressClass.B; // Deprecated 
            Info.NumberOfHosts = 14;
            Info.RequiredSubnets = 2;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            SubnetDataWriter Datawriter = new SubnetDataWriter();
            Datawriter.WriteSubnetData(Builder.BuiltNetwork);
            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "14-2");

            Info = new NetworkInfo();
            // Deprecated
            Info.Class = AddressClass.B; // Deprecated 
            Info.NumberOfHosts = 14;
            Info.RequiredSubnets = 16;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "14-16");

            Info = new NetworkInfo();
            Info.NumberOfHosts = 126;
            Info.RequiredSubnets = 2;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "126-2");

            Info = new NetworkInfo();
            Info.NumberOfHosts = 62;
            Info.RequiredSubnets = 4;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "62-2");


            Info = new NetworkInfo();
            Info.NumberOfHosts = 30;
            Info.RequiredSubnets = 8;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "30-8");

            Info = new NetworkInfo();
            Info.NumberOfHosts = 6;
            Info.RequiredSubnets = 32;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "6-32");

            Info = new NetworkInfo();
            Info.NumberOfHosts = 2;
            Info.RequiredSubnets = 64;
            Info.SampleAddress = "192.168.5.23";
            Builder = new NetworkBuilder(Info);

            Datawriter.WriteOutExcelDocument(Builder.BuiltNetwork, "2-64");
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
