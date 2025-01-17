using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using SZF_C_LE_08_01_CustomerManager_Database.Model;
using SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace;
using Microsoft.Extensions.DependencyInjection;

namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        DatabaseExecutorService _databaseExecutorService;

       
        /// collection for displaying customers in DataGrid
        public ObservableCollection<Customer> CustomersListUserInterface { get; set; }

        private Customer _selectedCustomer = null!;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// constructor:
        /// <param databaseExecutorService> service for working with table Customers in Database </>
        /// - sunscribing class for adding new customer and updating a new customer in databese service
        /// - getting all customers from the database
        /// </summary>

        public MainWindowViewModel(DatabaseExecutorService databaseExecutorService) 
        {
            _databaseExecutorService = databaseExecutorService;
            _databaseExecutorService.CustomerAdded += OnCustomerAdded;
            _databaseExecutorService.CustomerUpdated += OnCustomerUpdated;

            var customersList = _databaseExecutorService.LoadAllClientsFromDatabase();

            CustomersListUserInterface = new ObservableCollection<Customer>(customersList);
        }


        /// <summary>
        /// after updating new customer in database
        /// change this customer in collection for displaying
        /// </summary>
        /// <param name="updatedCustomer"></param>
        private void OnCustomerUpdated(Customer updatedCustomer)
        {

            var index = CustomersListUserInterface.IndexOf(CustomersListUserInterface
                                                  .First(customer => customer.CustomerID == updatedCustomer.CustomerID));
            CustomersListUserInterface[index] = updatedCustomer;
        }

        /// <summary>
        /// after adding new customer in database
        /// change this customer in collection for displaying
        /// </summary>
        /// <param name="newCustomer"></param>
        private void OnCustomerAdded(Customer newCustomer)
        {

            CustomersListUserInterface.Add(newCustomer);
        }

        public RelayCommand DeleteCustomerCommand =>
            new RelayCommand(execute => DeleteCustomer());

        /// <summary>
        /// command connected with "Entfernen" button
        /// </summary>
        private void DeleteCustomer() 
        {
            /// checking if some customer is chosen
            if (SelectedCustomer != null)
            {
                MessageBoxResult result = MessageBox.Show("Kunden entfernen?", "Bestätigung",
                                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                /// confirmation deleteng from user
                if (result == MessageBoxResult.Yes)
                {
                    /// deleting customer from database and collection for displaying
                    _databaseExecutorService.DeleteCustomer(SelectedCustomer.CustomerID);
                    CustomersListUserInterface.Remove(CustomersListUserInterface
                                              .First(customer => 
                                              customer.CustomerID == SelectedCustomer.CustomerID));
                }
            }
            else
                MessageBox.Show("Wählen einen Kunden aus.", "Warnung", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
