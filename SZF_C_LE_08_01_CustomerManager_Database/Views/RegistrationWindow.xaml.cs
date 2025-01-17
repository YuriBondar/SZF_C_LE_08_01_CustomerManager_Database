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
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace SZF_C_LE_08_01_CustomerManager_Database.Views
{
    /// <summary>
    /// Interaktionslogik für RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        ServiceProvider _customerManagerServices;
        RegistrationWindowViewModel _registrationWindowViewModel;
        public RegistrationWindow(ServiceProvider customerManagerServices)
        {
            InitializeComponent();
            _customerManagerServices = customerManagerServices;

            _registrationWindowViewModel = _customerManagerServices.GetRequiredService<RegistrationWindowViewModel>();
            this.DataContext = _registrationWindowViewModel;
            _registrationWindowViewModel.RegistrationCompleted += RunAuthorizationWindow;
        }
        public void RunAuthorizationWindow()
        {
            var authorizationWindow = new AuthorizationWindow(_customerManagerServices);
            _registrationWindowViewModel.RegistrationCompleted -= RunAuthorizationWindow;
            this.Close();
            authorizationWindow.Show();
            
        }

        private void RunAuthorizationWindow_Click(object sender, RoutedEventArgs e)
        {
            RunAuthorizationWindow();
        }
    }
}
