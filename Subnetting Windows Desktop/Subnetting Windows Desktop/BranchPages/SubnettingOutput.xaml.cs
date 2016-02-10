using Network;
using Subnetting_Windows_Desktop.Output;
using System.Windows;

namespace Subnetting_Windows_Desktop.BranchPages
{
    /// <summary>
    /// Interaction logic for SubnettingOutput.xaml
    /// </summary>
    public partial class SubnettingOutput 
    {

        private FullNetwork _Network;

        public SubnettingOutput(FullNetwork Network)
        {
            InitializeComponent();
            _Network = Network;
            AddressClassTextBox.Text = Network.Class.ToString();
            SubnetMaskTextBox.Text = Network.NetMask.ToString();
            AddressSpaceTextBox.Text = Network.AddressSpace.ToString();
            BitsBorrowedTextBox.Text = Network.BitsBorrowed.ToString();
            NumberOfSubnetsTextBox.Text = Network.NumberOfSubnets.ToString();
            UsableHostsPerSubnetTextBox.Text = Network.UsableHosts.ToString();

            if (Network.Class.ToString() != "C")
            {
                ExportToExcelButton.Visibility = Visibility.Hidden;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            ExcelSubnetWriter Writer = new ExcelSubnetWriter();
            string Filename = _Network.Class.ToString() + " " + _Network.NetMask.ToString();
            string Path = Writer.WriteOutExcelDocument(_Network, Filename);
            System.Diagnostics.Process.Start(Path);
        }
    }
}
