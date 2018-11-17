using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Providers
{
    public class DatabaseSettingsProvider : IDatabaseSettingsProvider
    {
        public DatabaseConnectionSettings GetSettings()
        {

            var connection = @"Server=ASPIRE\SQLEXPRESS;Database=DzuwenaliaDB;Trusted_Connection=True;";
            return new DatabaseConnectionSettings(connection);
        }
    }
}
