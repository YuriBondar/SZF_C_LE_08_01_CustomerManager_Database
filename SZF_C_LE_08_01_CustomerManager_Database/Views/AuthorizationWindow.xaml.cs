using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel;

namespace SZF_C_LE_08_01_CustomerManager_Database.Views
{
    /// <summary>
    /// Interaktionslogik für AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        ServiceProvider _customerManagerServices;
        AuthorizationWindowViewModel _authorizationWindowViewModel;
        public AuthorizationWindow(ServiceProvider customerManagerServices)
        {
            InitializeComponent();

            _customerManagerServices = customerManagerServices;

            /// criating AuthorizationWindowViewModel class with dependsy injections for working with database
            _authorizationWindowViewModel = _customerManagerServices.GetRequiredService<AuthorizationWindowViewModel>();

            /// subscribing on event AuthorizationCompleted 
            _authorizationWindowViewModel.AuthorizationCompleted += RunMainWindow;

            this.DataContext = _authorizationWindowViewModel;
        }

        public void RunMainWindow()
        {
            MainWindow mainWindow = new MainWindow(_customerManagerServices);
            mainWindow.Show();
            this.Close();
        }

        private void RunRegistrationWindow_Click(object sender, RoutedEventArgs e)
        {

            
            _authorizationWindowViewModel.LoginInput = "";
            var _registrationWindow = new RegistrationWindow(_customerManagerServices);
            _authorizationWindowViewModel.AuthorizationCompleted -= RunMainWindow;
            this.Close();
            _registrationWindow.ShowDialog();
            
           
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthorizationWindowViewModel authorizationWindowViewModel)
            {
                authorizationWindowViewModel.PasswordInput = (sender as PasswordBox)?.Password ?? string.Empty;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
