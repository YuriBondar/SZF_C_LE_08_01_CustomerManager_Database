using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using SZF_C_LE_08_01_CustomerManager_Database.Model;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace;

namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel
{
    class EditCustomerWindowViewModel : ViewModelBase
    {

        DatabaseExecutorService _databaseExecutorService;
        public Action? CloseEditWindowAction { get; set; }

        
        private string _customerIDOutput = null!;
        public string CustomerIDOutput
        {
            get => _customerIDOutput;
            set
            {
                if (_customerIDOutput != value)
                {
                    _customerIDOutput = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _customerFirstNameInput = null!;
        public string CustomerFirstNameInput
        {
            get => _customerFirstNameInput;
            set
            {
                if (_customerFirstNameInput != value)
                {
                    _customerFirstNameInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _customerLastNameInput = null!;
        public string CustomerLastNameInput
        {
            get => _customerLastNameInput;
            set
            {
                if (_customerLastNameInput != value)
                {
                    _customerLastNameInput = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _customerStreetInput = null!;
        public string CustomerStreetInput
        {
            get => _customerStreetInput;
            set
            {
                if (_customerStreetInput != value)
                {
                    _customerStreetInput = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _customerHausNumberInput = null!;
        public string CustomerHausNumberInput
        {
            get => _customerHausNumberInput;
            set
            {
                if (_customerHausNumberInput != value)
                {
                    _customerHausNumberInput = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _customerPostIndexInput = null!;
        public string CustomerPostIndexInput
        {
            get => _customerPostIndexInput;
            set
            {
                if (_customerPostIndexInput != value)
                {
                    _customerPostIndexInput = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _customerCityInput = null!;
        public string CustomerCityInput
        {
            get => _customerCityInput;
            set
            {
                if (_customerCityInput != value)
                {
                    _customerCityInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _customerEmailInput = null!;
        public string CustomerEmailInput
        {
            get => _customerEmailInput;
            set
            {
                if (_customerEmailInput != value)
                {
                    _customerEmailInput = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// getting chosen customer from main window and displaying it through Textboxes
        /// </summary>
        public EditCustomerWindowViewModel(DatabaseExecutorService databaseExecutorService, 
                                           MainWindowViewModel mainWindowViewModel)
        {
            CustomerIDOutput = mainWindowViewModel.SelectedCustomer.CustomerID.ToString();
            CustomerFirstNameInput = mainWindowViewModel.SelectedCustomer.CustomerFirstName;
            CustomerLastNameInput = mainWindowViewModel.SelectedCustomer.CustomerLastName;
            CustomerStreetInput = mainWindowViewModel.SelectedCustomer.CustomerStreet;
            CustomerHausNumberInput = mainWindowViewModel.SelectedCustomer.CustomerHausNumber;
            CustomerPostIndexInput = mainWindowViewModel.SelectedCustomer.CustomerPostIndex;
            CustomerCityInput = mainWindowViewModel.SelectedCustomer.CustomerCity;
            CustomerEmailInput = mainWindowViewModel.SelectedCustomer.CustomerEmail;


            _databaseExecutorService = databaseExecutorService;

        }

        /// <summary>
        /// command connected with "Speichern" button
        /// </summary>
        public RelayCommand UpdateCustomerCommand =>
            new RelayCommand(execute => UpdateCustomer(), canExecute => AreAllFieldsFilled());

        private void UpdateCustomer()
        {
            /// validation input
            if (ValidatorUserInput.ValidateCustomerFirstName(CustomerFirstNameInput) &&
               ValidatorUserInput.ValidateCustomerLastName(CustomerLastNameInput) &&
               ValidatorUserInput.ValidateStreetName(CustomerStreetInput) &&
               ValidatorUserInput.ValidateHausNumber(CustomerHausNumberInput) &&
               ValidatorUserInput.ValidatePostIndex(CustomerPostIndexInput) &&
               ValidatorUserInput.ValidateCityName(CustomerCityInput) &&
               ValidatorUserInput.ValidateEmail(CustomerEmailInput))
            {
                /// confirmation updating from user
                MessageBoxResult result = MessageBox.Show("Daten aktualisieren?", "Bestätigung",         
                                                            MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    /// updating user in database
                    _databaseExecutorService.UpdateCustomer(
                        new Customer
                        {
                            CustomerID = int.Parse(CustomerIDOutput),
                            CustomerFirstName = CustomerFirstNameInput,
                            CustomerLastName = CustomerLastNameInput,
                            CustomerStreet = CustomerStreetInput,
                            CustomerHausNumber = CustomerHausNumberInput,
                            CustomerPostIndex = CustomerPostIndexInput,
                            CustomerCity = CustomerCityInput,
                            CustomerEmail = CustomerEmailInput
                        });

                    CloseEditWindowAction?.Invoke();
                }
            }
        }

        private bool AreAllFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(CustomerFirstNameInput) ||
                string.IsNullOrWhiteSpace(CustomerLastNameInput) ||
                string.IsNullOrWhiteSpace(CustomerStreetInput) ||
                string.IsNullOrWhiteSpace(CustomerHausNumberInput) ||
                string.IsNullOrWhiteSpace(CustomerPostIndexInput) ||
                string.IsNullOrWhiteSpace(CustomerCityInput) ||
                string.IsNullOrWhiteSpace(CustomerEmailInput))
                return false;

            return true;
        }



    }
}
