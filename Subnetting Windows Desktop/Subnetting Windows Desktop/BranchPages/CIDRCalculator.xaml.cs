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
using Network.Tools;
using System.Text.RegularExpressions;

namespace Subnetting_Windows_Desktop.BranchPages
{
    /// <summary>
    /// Interaction logic for CIDRCalculator.xaml
    /// </summary>
    public partial class CIDRCalculator 
    {
        public CIDRCalculator()
        {
            InitializeComponent();
            CidrInputBox.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CidrInputBox_KeyUp(object sender, KeyEventArgs e)
        {
            string RawInput;
            RawInput = CidrInputBox.Text.Trim();

            // CIDR regex 
            string pattern = @"\/[0-9]{1,2}";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            if (rgx.IsMatch(RawInput) == true)
            {
                // Call the Network.CidrParser() to parse the CIDR
                CidrParser Parser = new CidrParser();
                string OutputString = Parser.ParseCidr(RawInput);
                CidrOutputBox.Text = OutputString;
            }
            else
            {
                CidrOutputBox.Text = "";
            }
        }
    }
}
