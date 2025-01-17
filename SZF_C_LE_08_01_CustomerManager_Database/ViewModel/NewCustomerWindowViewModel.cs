using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Model;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace;
using Microsoft.Extensions.DependencyInjection;

namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel
{
    class NewCustomerWindowViewModel : ViewModelBase
    {
        DatabaseExecutorService _databaseExecutorService;

        public Action? CloseEditWindowAction;



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

        public NewCustomerWindowViewModel(DatabaseExecutorService databaseExecutorService) 
        {

            _databaseExecutorService = databaseExecutorService;
        }

        /// <summary>
        /// command connected with "Speichern" button
        /// </summary>
        public RelayCommand AddNewCustomerCommand =>
            new RelayCommand(execute => AddNewCustomer(), canExecute => AreAllFieldsFilled());

        private void AddNewCustomer()
        {
            /// validation user's input
            if (ValidatorUserInput.ValidateCustomerFirstName(CustomerFirstNameInput) &&
               ValidatorUserInput.ValidateCustomerLastName(CustomerLastNameInput) &&
               ValidatorUserInput.ValidateStreetName(CustomerStreetInput) &&
               ValidatorUserInput.ValidateHausNumber(CustomerHausNumberInput) &&
               ValidatorUserInput.ValidatePostIndex(CustomerPostIndexInput) &&
               ValidatorUserInput.ValidateCityName(CustomerCityInput) &&
               ValidatorUserInput.ValidateEmail(CustomerEmailInput))
            {
                /// saving a new customer in database
                _databaseExecutorService.AddNewCustomer(new Customer{
                                                                    CustomerFirstName = CustomerFirstNameInput,
                                                                    CustomerLastName = CustomerLastNameInput,
                                                                    CustomerStreet = CustomerStreetInput,
                                                                    CustomerHausNumber = CustomerHausNumberInput,
                                                                    CustomerPostIndex = CustomerPostIndexInput,
                                                                    CustomerCity = CustomerCityInput,
                                                                    CustomerEmail = CustomerEmailInput
                                                                    });

                ClearAll();
                CloseEditWindowAction?.Invoke();
                
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

        public RelayCommand ClearAllCommand => new RelayCommand(execute => ClearAll());

        private void ClearAll()
        {
            CustomerFirstNameInput = string.Empty;
            CustomerLastNameInput = string.Empty;
            CustomerStreetInput = string.Empty;
            CustomerHausNumberInput = string.Empty;
            CustomerPostIndexInput = string.Empty;
            CustomerCityInput = string.Empty;
            CustomerEmailInput = string.Empty;

        }
    }
}
