using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Providers
{
    public class DatabaseSettingsProvider : IDatabaseSettingsProvider
    {
        public DatabaseConnectionSettings GetSettings()
        {
            
            var connection = @"Server=JAPKO\SQLEXPRESS;Database=DzuwenaliaDB;Trusted_Connection=True;";
            return new DatabaseConnectionSettings(connection);
        }
    }
}
