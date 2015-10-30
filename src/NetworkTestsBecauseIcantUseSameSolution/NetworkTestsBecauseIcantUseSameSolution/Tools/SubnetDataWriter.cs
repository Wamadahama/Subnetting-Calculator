using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network;
using System.IO;
using System.Data;
using ClosedXML.Excel;
namespace NetworkTests.Tools
{
    /// <summary>
    /// Contains various methods for unpacking FullNetwork objects and writing them out 
    /// </summary>
    public class SubnetDataWriter
    {
        public SubnetDataWriter() { }
        /// <summary>
        /// Writes out subnet data to the working directory
        /// </summary>
        /// <param name="Network"></param>
        public void WriteSubnetData(FullNetwork Network)
        {

            StreamWriter SubnetFile = new StreamWriter("SubnetData.txt");
            SubnetFile.Write("Network ID  First Usable  Last Usable  Broadcast Address \n");
            foreach (var subnet in Network.Subnets)
            {
                StringBuilder Builder = new StringBuilder();

                Builder.Append(subnet.NetworkId + " ");
                Builder.Append(subnet.FirstUsable + " ");
                Builder.Append(subnet.LastUsable + " ");
                Builder.Append(subnet.BroadcastAddress + " \n");
                string line = Builder.ToString();
                SubnetFile.Write(line);
            }

            SubnetFile.Close();
        }

        /// <summary>
        /// Writes out subnet data to a specified file name 
        /// </summary>
        /// <param name="Network"></param>
        /// <param name="Name"></param>
        public void WriteSubnetData(FullNetwork Network, string Name)
        {

            StreamWriter SubnetFile = new StreamWriter(Name);
            SubnetFile.Write("Network ID  First Usable  Last Usable  Broadcast Address \n");
            foreach (var subnet in Network.Subnets)
            {
                StringBuilder Builder = new StringBuilder();

                Builder.Append(subnet.NetworkId + " ");
                Builder.Append(subnet.FirstUsable + " ");
                Builder.Append(subnet.LastUsable + " ");
                Builder.Append(subnet.BroadcastAddress + " \n");
                string line = Builder.ToString();
                SubnetFile.Write(line);
            }

            SubnetFile.Close();
        }
        /// <summary>
        /// Unpacks and writes out the FullNetwork file
        /// </summary>
        /// <param name="Network"></param>
        /// <param name="Path"></param>
        public void WriteOutExcelDocument(FullNetwork Network, string FileName)
        {
            // Build data table from the Network
            DataTable Table = new DataTable();
            Table.Columns.Add("Network ID");
            Table.Columns.Add("First Usable");
            Table.Columns.Add("Last Usable");
            Table.Columns.Add("Broadcast Address");
            foreach (var subnet in Network.Subnets)
            {
                // Add the data to each collumn 
                DataRow Row = Table.NewRow();

                Row[0] = subnet.NetworkId;
                Row[1] = subnet.FirstUsable;
                Row[2] = subnet.LastUsable;
                Row[3] = subnet.BroadcastAddress;
                Table.Rows.Add(Row);
            }

            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(Table, "Subnet Data");
            wb.SaveAs( FileName + ".xlsx");
        }
    }
}
