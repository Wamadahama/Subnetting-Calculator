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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Subnetting_Windows_Desktop.BranchPages;
using System.IO;

namespace Subnetting_Windows_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CleanExcelDocuments();
        }

        private void CleanExcelDocuments()
        {
            string[] ExcelFiles = Directory.GetFiles(".", "*.xlsx");
            foreach (string ExcelFile in ExcelFiles)
            {
                try
                {
                    File.Delete(ExcelFile);
                }
                catch (Exception)
                {
                }
                
            }
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            // Tile Click Logic Here 
        }

        private void SubnettingCalculatorTile_Click(object sender, RoutedEventArgs e)
        {
            Subnetting Window = new Subnetting();
            Window.Show();
        }

        private void BinaryAndingTile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CidrPrefixCalculatorTile_Click(object sender, RoutedEventArgs e)
        {
            CIDRCalculator Window = new CIDRCalculator();
            Window.Show();   
        }

        private void AddressConverterTile_Click(object sender, RoutedEventArgs e)
        {
            AddressConverter Window = new AddressConverter();
            Window.Show();
        }
    }
}
