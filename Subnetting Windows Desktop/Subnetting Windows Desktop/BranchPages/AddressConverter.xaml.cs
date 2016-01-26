using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddressConverter.xaml
    /// </summary>
    public partial class AddressConverter  
    {
        public AddressConverter()
        {
            InitializeComponent();
            DecimalIpAddressTextBox.Focus();
        }

        private void DecimalIpAddressTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string RawInput;
            RawInput = DecimalIpAddressTextBox.Text.Trim();

            // CIDR regex 
            string pattern = @"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            if (rgx.IsMatch(RawInput) == true)
            {
                try
                {
                    IpAddress Address = new IpAddress(RawInput);
                    BinaryIpAddressTextBox.Text = Address.ToBinaryString();
                }
                catch (Exception)
                {

                    BinaryIpAddressTextBox.Text = "Invalid Address";
                }
            }
            else
            {
                BinaryIpAddressTextBox.Text = "";
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
