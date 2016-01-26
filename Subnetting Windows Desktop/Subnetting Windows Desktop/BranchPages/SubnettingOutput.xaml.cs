using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Network;

namespace Subnetting_Windows_Desktop.BranchPages
{
    /// <summary>
    /// Interaction logic for SubnettingOutput.xaml
    /// </summary>
    public partial class SubnettingOutput 
    {

        public SubnettingOutput(FullNetwork Network)
        {
            InitializeComponent();
            AddressClassTextBox.Text = Network.Class.ToString();
            SubnetMaskTextBox.Text = Network.NetMask.ToString();
            AddressSpaceTextBox.Text = Network.AddressSpace.ToString();
            BitsBorrowedTextBox.Text = Network.BitsBorrowed.ToString();
            NumberOfSubnetsTextBox.Text = Network.NumberOfSubnets.ToString();
            UsableHostsPerSubnetTextBox.Text = Network.UsableHosts.ToString();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
