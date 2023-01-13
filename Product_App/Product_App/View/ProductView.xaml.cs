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
using Product_App.ViewModels;

namespace Product_App.View
{
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
            vm = new ProductViewModel();
            vm.OnCallBack += ResetComponent;
            DataContext= vm;
            ResetComponent();
        }
        private ProductViewModel vm;

        private void ResetComponent()
        {
            
        }

        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void MnuRelogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TblData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            TxtUid.IsEnabled = true;
            TxtName.IsEnabled = true;
            IsChecked.IsEnabled = true;

            TxtName.Focus();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            TxtUid.IsEnabled = true;
            TxtName.IsEnabled = true;

            vm.Model = new Models.Product();
            vm.IsChecked = true;
            TxtName.Focus();

        }
    }
}
