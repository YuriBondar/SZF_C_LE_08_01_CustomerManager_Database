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
    /// Interaktionslogik für EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        ServiceProvider _customerManagerServices;
        public EditCustomerWindow(ServiceProvider customerManagerServices)
        {
            InitializeComponent();
            _customerManagerServices = customerManagerServices;

            var editCustomerWindowViewModel = _customerManagerServices.GetRequiredService<EditCustomerWindowViewModel>();

            
            editCustomerWindowViewModel.CloseEditWindowAction = () => this.Close();
            this.DataContext = editCustomerWindowViewModel;
        }
    }
}
