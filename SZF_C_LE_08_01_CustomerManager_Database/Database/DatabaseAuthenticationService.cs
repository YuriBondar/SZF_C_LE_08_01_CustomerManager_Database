using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SZF_C_LE_08_01_CustomerManager_Database.Model;

namespace SZF_C_LE_08_01_CustomerManager_Database.Database
{
    /// <summary>
    /// class for working with authorithations entity from CustomerManagerDatabaseContext
    /// </summary>
    internal class DatabaseAuthenticationService
    {
        private readonly CustomerManagerDatabaseContext _context;

        public DatabaseAuthenticationService(CustomerManagerDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// checking if is not the same login in database as input login from user
        /// using for registration new user
        /// </summary>
        public bool IsLoginAvailable(string login)
        {
            
            return !_context.Authorizations.Any(authorization =>
                authorization.UserLogin == login);
        }

        /// <summary>
        /// checking if is inputed login and password in database
        /// using for registration new user
        /// </summary>
        public bool isAuthorizationAvailable(string login, string password)
        {
            return _context.Authorizations.Any(authorization => authorization.UserLogin == login &&
                                                                            authorization.UserPassword == password);
        }

        /// <summary>
        /// adding new user's login and password in database
        /// </summary>
        public bool RegisterUser(string login, string password)
        {
            try
            {
                if (!IsLoginAvailable(login))
                    return false;

                _context.Authorizations.Add(new AuthorizationData
                {
                    UserLogin = login,
                    UserPassword = password
                });
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
