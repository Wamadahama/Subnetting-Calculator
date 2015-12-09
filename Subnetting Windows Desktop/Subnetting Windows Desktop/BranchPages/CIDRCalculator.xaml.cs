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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
