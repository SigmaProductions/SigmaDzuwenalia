using SigmaDzuwenalia.DataAccess.Context;
using SigmaDzuwenalia.DataAccess.Providers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Factories
{
    public class DzuwenaliaDBContextFactory : IDzuwenaliaDBContextFactory
    {
        private readonly IDatabaseSettingsProvider _databaseSettingsProvider;

        public DzuwenaliaDBContextFactory(IDatabaseSettingsProvider databaseSettingsProvider)
        {
            _databaseSettingsProvider = databaseSettingsProvider;
        }
        public IDzuwenaliaDBContext Create()
        {
            var databaseSettings = _databaseSettingsProvider.GetSettings();
            var connection = new SqlConnection(databaseSettings.ConnectionString);
            var dbContext = new DzuwenaliaDBContext(connection, false);
            return dbContext;
        }
    }
}
