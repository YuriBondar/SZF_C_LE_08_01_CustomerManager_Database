using System.Configuration;
using System.Data;
using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Database;
using SZF_C_LE_08_01_CustomerManager_Database.Views;

namespace SZF_C_LE_08_01_CustomerManager_Database
{
    /// <summary>
    /// Common schema:
    /// <param _customerManagerServices>service with all ViewModel classes 
    /// and dependsy injections for them for working with database
    /// This patameter is passed to each window. 
    /// Then in code-behind window getting passed ViewModel class for this window
    /// </param>>
    /// 
    /// 
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var _customerManagerServices = new CustomerManagerServiceProvider().GetServiceProvider();

            AuthorizationWindow authorizationWindow = new AuthorizationWindow(_customerManagerServices);

            authorizationWindow.Show();
        }
    }

}