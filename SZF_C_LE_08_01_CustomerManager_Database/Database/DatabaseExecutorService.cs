using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Model;
using Microsoft.EntityFrameworkCore;

namespace SZF_C_LE_08_01_CustomerManager_Database.Database
{
    /// <summary>
    /// class for working with customers entity from CustomerManagerDatabaseContext
    /// </summary>
    public class DatabaseExecutorService
    {
        private readonly CustomerManagerDatabaseContext _context;

        public event Action<Customer> CustomerAdded;
        public event Action<Customer> CustomerUpdated;
        public DatabaseExecutorService(CustomerManagerDatabaseContext context) 
        {
            _context = context;
        }

        // <summary>
        /// getting all customers from the database
        /// </summary
        public List<Customer> LoadAllClientsFromDatabase() 
        {
            return _context.Customers.ToList();
        }

        /// <summary>
        /// inserting new customer in database 
        /// </summary
        public void AddNewCustomer(Customer newCustomer)
        {
            try
            { 
                _context.Customers.Add(newCustomer);

                _context.SaveChanges();

                /// informing MainWindowViewModel that new customer was added
                CustomerAdded?.Invoke(newCustomer);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Fehler beim Hinzufügen eines Kunden:\n{ex.Message}",
                                "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// updating customer in database 
        /// </summary
        public void UpdateCustomer(Customer newCustomer)
        {
            try
            {
                /// searching for existing customer in database with the same id as in updated customer by user in DataGrid
                var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerID == newCustomer.CustomerID);
                /// updating ala values in existing customer in database to values from updated customer by users
                _context.Entry(existingCustomer).CurrentValues.SetValues(newCustomer);

                _context.SaveChanges();
                /// informing MainWindowViewModel that new customer was added
                CustomerUpdated?.Invoke(newCustomer);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Fehler beim Hinzufügen eines Kunden:\n{ex.Message}",
                                "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        /// <summary>
        /// deleting customer by id 
        /// </summary
        public void DeleteCustomer(int customerID)
        {
            try
            {
                /// searching custimer with needed id
                var selectedCustomer = _context.Customers.FirstOrDefault(c => c.CustomerID == customerID);
                ///deleting customer
                _context.Customers.Remove(selectedCustomer);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Fehler beim Hinzufügen eines Kunden:\n{ex.Message}",
                                "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
