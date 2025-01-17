using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace;

namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel
{
    class RegistrationWindowViewModel : ViewModelBase
    {
        DatabaseAuthenticationService _databaseAuthenticationService = null!;
        public event Action RegistrationCompleted;


        private string _loginRegistrationInput = null!;
        public string LoginRegistrationInput
        {
            get => _loginRegistrationInput;
            set
            {
                if (_loginRegistrationInput != value)
                {
                    _loginRegistrationInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _passwordRegistrationInput = null!;
        public string PasswordRegistrationInput
        {
            get => _passwordRegistrationInput;
            set
            {
                if (_passwordRegistrationInput != value)
                {
                    _passwordRegistrationInput = value;
                    OnPropertyChanged();
                }
            }
        }


        public RegistrationWindowViewModel(DatabaseAuthenticationService databaseAuthenticationService)
        {
            _databaseAuthenticationService = databaseAuthenticationService;
            
        }

        /// <summary>
        /// command connected with Authorisation buton in LoginWindow
        /// </summary>
        public RelayCommand RegistrationUserCommand => new RelayCommand(execute => RegistrationUser());

        /// <summary>
        /// if login and password from user is correct show Main Window and close LoginWindow
        /// </summary>
        private void RegistrationUser()
        {
           
            bool IsLoginAvailable = _databaseAuthenticationService.IsLoginAvailable(LoginRegistrationInput);

            if (!IsLoginAvailable)
            {
                MessageBox.Show("Ein Benutzer mit diesem Login existiert bereits in der Datenbank.", 
                                "Warnung", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_databaseAuthenticationService.RegisterUser(LoginRegistrationInput, PasswordRegistrationInput))
            {
                MessageBox.Show($"Neuer Benutzer wurde erfolgreich im Archiv gespeichert.", "Erfolg");

                RegistrationCompleted.Invoke();

                
            }
        }

    }
}
