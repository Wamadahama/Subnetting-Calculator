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
    /// Interaction logic for Subnetting.xaml
    /// </summary>
    public partial class Subnetting
    {
        public Subnetting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NetworkInfo Info = new NetworkInfo();
            try
            {
                Info.NumberOfHosts = int.Parse(NumberOfHostsTextBox.Text);
                Info.RequiredSubnets = int.Parse(RequiredSubnetsTextBox.Text);
                Info.SampleAddress = SampleAddressTextBox.Text;
                NetworkBuilder Builder = new NetworkBuilder(Info);
                SubnettingOutput Window = new SubnettingOutput(Builder.BuiltNetwork);
                Window.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error parsing your information");
            }

        }
    }
}
