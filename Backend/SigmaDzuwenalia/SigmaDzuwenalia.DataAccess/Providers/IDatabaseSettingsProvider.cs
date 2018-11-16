using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Providers
{
    
    public class DatabaseConnectionSettings
    {
        public string ConnectionString { get; }
        public DatabaseConnectionSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
    public interface IDatabaseSettingsProvider
    {
        DatabaseConnectionSettings GetSettings();
    }
}
