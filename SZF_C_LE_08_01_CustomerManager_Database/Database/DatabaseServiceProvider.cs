using SZF_C_LE_08_01_CustomerManager_Database.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace SZF_C_LE_08_01_CustomerManager_Database.Database
{

    /// <summary>
    /// class for making services, which responsible for all action with database
    /// </summary>
    public class CustomerManagerServiceProvider
    {
        private readonly ServiceProvider _customerManagerServices;


        /// <summary>
        /// creating _databaseServices: siquence of objects which making action with database in result
        /// </summary>
        public CustomerManagerServiceProvider()
        {
            
            /// createing new object with set up information for database
            var configurator = new DatabaseConfigurator();

            /// createing services: siquence of objects
            /// Singelton means that every time when we will create and use services, services will be use only one object of this class
            _customerManagerServices = new ServiceCollection()
                /// add configuration  
                .AddSingleton(configurator.Configuration)
                ///add object for connection with database
                .AddDbContext<CustomerManagerDatabaseContext>(ServiceLifetime.Transient)
                ///add object for user's authorisation and ragistration in database 
                .AddScoped<DatabaseAuthenticationService>()
                ///add object for intaractions with Customer table in database
                .AddScoped<DatabaseExecutorService>()
                .AddScoped<AuthorizationWindowViewModel>()
                .AddScoped<RegistrationWindowViewModel>()
                .AddScoped<MainWindowViewModel>()
                .AddScoped<NewCustomerWindowViewModel>()
                .AddScoped<EditCustomerWindowViewModel>()
                .BuildServiceProvider();
        }

        
        ///getter for services
        public ServiceProvider GetServiceProvider()
        {
            return _customerManagerServices; ;
        }
        
    }
}
