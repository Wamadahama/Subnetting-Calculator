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
using Subnetting_Windows_Desktop.Helpers;
namespace Subnetting_Windows_Desktop.BranchPages
{
    /// <summary>
    /// Interaction logic for BinaryAnding.xaml
    /// </summary>
    public partial class BinaryAnding
    {
        public BinaryAnding()
        {
            InitializeComponent();
        }

        private void AndValues_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string IpAddressInput = IpAddressTextBox.Text;
                string SubnetmaskInput = SubnetMaskTextBox.Text;

                Ander AddressAnder = new Ander();

                IpAddress InputIpAddress = new IpAddress(IpAddressInput);
                SubnetMask InputNetmask = new SubnetMask(SubnetmaskInput);

                IpAddress AndedAddress = AddressAnder.AndAddress(InputIpAddress, InputNetmask);

                OutputTextBox.Text = AndedAddress.ToString();
            }
            catch (Exception)
            {
                Helpers.MessageBox MessageBox = new Helpers.MessageBox("Invalid input");
                MessageBox.Show();
            }

        }
    }
}
