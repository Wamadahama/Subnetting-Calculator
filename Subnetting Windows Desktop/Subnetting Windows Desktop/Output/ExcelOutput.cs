using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Network;
using System.Data;

namespace Subnetting_Windows_Desktop.Output
{
    class ExcelSubnetWriter
    {
        /// Unpacks and writes out the FullNetwork file, returns the filepath 
        /// </summary>
        /// <param name="Network"></param>
        /// <param name="Path"></param>
        public string WriteOutExcelDocument(FullNetwork Network, string FileName)
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

            string FilePath = FileName + ".xlsx";

            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(Table, "Subnet Data");
            wb.SaveAs(FilePath);

            return FilePath;
        }
    }
}
