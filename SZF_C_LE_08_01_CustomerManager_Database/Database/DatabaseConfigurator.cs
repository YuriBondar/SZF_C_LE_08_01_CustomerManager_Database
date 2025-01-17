using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace SZF_C_LE_08_01_CustomerManager_Database.Database
{
    /// <summary>
    /// class for loading configuration for connection with database
    /// </summary>
    internal class DatabaseConfigurator
    {
        /// <value>
        /// contains configuration info from appsettings.json
        /// </value>
        public IConfiguration Configuration { get; private set; }

        public DatabaseConfigurator()
        {
            /// <param optional: false> throw exception if file "appsettings.json" does not exist </param>
            /// <param reloadOnChange: true> automatic update configuration if "appsettings.json" is updated </param>
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            try
            {
                Configuration = builder.Build();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Konfigurationsdatei. \nFehler: {ex.Message}",
                                "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
