using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaDzuwenalia.DataAccess.Entities;

namespace SigmaDzuwenalia.DataAccess.Context
{
    public class DzuwenaliaDBContext : IDzuwenaliaDBContext
    {
        public IDbSet<FlankiEntity> Flanki { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
