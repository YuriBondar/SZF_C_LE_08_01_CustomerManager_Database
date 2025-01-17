using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace SZF_C_LE_08_01_CustomerManager_Database.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceProvider _customerManagerServices;
        MainWindowViewModel _mainWindowViewModel;
        public MainWindow(ServiceProvider customerManagerServices)
        {
            InitializeComponent();
            _customerManagerServices = customerManagerServices;
            _mainWindowViewModel = _customerManagerServices.GetRequiredService<MainWindowViewModel>();

            this.DataContext = _mainWindowViewModel;
        }

        private void RunNewCustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            var _newCustomerWindow = new NewCustomerWindow(_customerManagerServices);
            _newCustomerWindow.ShowDialog();
            
        }

        private void RunEditorCustomerWindow_Click(object sender, RoutedEventArgs e)
        {

            {
                if (_mainWindowViewModel.SelectedCustomer != null)
                {
                    var _editCustomerWindow = new EditCustomerWindow(_customerManagerServices);
                    _editCustomerWindow.ShowDialog();
                }
                else
                    MessageBox.Show("Wählen einen Kunden aus.", "Warnung", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}