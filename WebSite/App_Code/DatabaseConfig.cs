using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
/// 

namespace AddressBook
{
    public class DatabaseConfig
    {
        #region Constuctor
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constuctor

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConectionString"].ConnectionString;
    }

}