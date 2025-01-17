using System.Net;
using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using SZF_C_LE_08_01_CustomerManager_Database.Model;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace;
using Microsoft.Extensions.DependencyInjection;



namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel
{
    /// <summary>
    /// class for logic for AuthorizationWindow 
    /// </summary>
    class AuthorizationWindowViewModel : ViewModelBase
    {


        /// assignment to empty delegate to avoid being null for event AuthorizationCompleted
        public event Action AuthorizationCompleted = delegate { };
        
        DatabaseAuthenticationService _databaseAuthenticationService;

        private string _loginInput = null!;
        public string LoginInput
        {
            get => _loginInput;
            set
            {
                if (_loginInput != value)
                {
                    _loginInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _passwordInput = null!;
        public string PasswordInput
        {
            get => _passwordInput;
            set => _passwordInput = value;
        }

        
        public AuthorizationWindowViewModel(DatabaseAuthenticationService databaseAuthenticationService) 
        {
            _databaseAuthenticationService = databaseAuthenticationService;
        }
        /// <summary>
        /// command connected with Authorization button in AuthorizationWindow
        /// </summary>
        public RelayCommand CheckAuthorizationCommand => new RelayCommand(execute => CheckAuthorization());

        /// <summary>
        /// if login and password from user is validate it saved in database
        /// afterwords call RunMainWindow() in Authorithation window
        /// </summary>
        private void CheckAuthorization() 
        {

            /// checking that input login and password exists in database
            var isAuthorizationAvailable = _databaseAuthenticationService.isAuthorizationAvailable(LoginInput, PasswordInput);

            if (isAuthorizationAvailable)
                AuthorizationCompleted?.Invoke();
          
            else
                MessageBox.Show("Ungültiger Benutzername oder Passwort", "Warnung",
                                MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}
