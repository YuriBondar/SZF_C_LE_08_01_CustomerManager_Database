using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SZF_C_LE_08_01_CustomerManager_Database.Database
{
    /// <summary>
    /// class for setiing up context foe Entety Framework
    /// </summary>
    public class CustomerManagerDatabaseContext : DbContext
    {
        public DbSet<AuthorizationData> Authorizations { get; set; }

        public DbSet<Customer> Customers { get; set; }


        private readonly IConfiguration _configuration = null!;

        public CustomerManagerDatabaseContext(IConfiguration configuration) 
        {
            _configuration = configuration;
            /// checking if exist database with cinnection string that used in OnConfiguring() method
            /// if database does not exist it is created
            /// if database exists but it does not have tables for entities of this class they are created
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// setting up the context
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("GoldDigger_ClientManagerDB");
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 38)));
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error configuring DbContext:\n {ex.Message}",
                               "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// method for creating database
        /// in our case we take empty existing empty database and create two table 
        /// for classes AuthorizationsData and Customers
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            /// configuration entity for customers
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerID); /// primary key
                entity.Property(e => e.CustomerFirstName)
                      .IsRequired() /// Not null
                      .HasMaxLength(50); 
                entity.Property(e => e.CustomerLastName)
                      .IsRequired() // 
                      .HasMaxLength(50);
                entity.Property(e => e.CustomerStreet)
                      .IsRequired() 
                      .HasMaxLength(50);
                entity.Property(e => e.CustomerHausNumber)
                      .IsRequired() 
                      .HasMaxLength(20);
                entity.Property(e => e.CustomerPostIndex)
                      .IsRequired()
                      .HasMaxLength(4);
                entity.Property(e => e.CustomerCity)
                      .IsRequired() 
                      .HasMaxLength(50);
                entity.Property(e => e.CustomerEmail)
                      .IsRequired() 
                      .HasMaxLength(50);

                /// setting up auto increment for primary key
                entity.Property(e => e.CustomerID)
                      .ValueGeneratedOnAdd();

            });


            /// configuration entity for customers
            modelBuilder.Entity<AuthorizationData>(entity =>
            {
                entity.HasKey(e => e.UserLogin); /// primary key
                entity.Property(e => e.UserPassword)
                      .IsRequired() 
                      .HasMaxLength(50); 
            });
        }
    }
}
