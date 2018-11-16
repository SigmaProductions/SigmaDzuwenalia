using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaDzuwenalia.DataAccess.Entities;


namespace SigmaDzuwenalia.DataAccess.Context
{
    public class DzuwenaliaDBContext : DbContext, IDzuwenaliaDBContext
    {
        public IDbSet<FlankiEntity> Flanki { get; set; }


        public DzuwenaliaDBContext(DbConnection existingConnection, bool contextOwnsConnection)
           :base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FlankiEntity>().ToTable("FlankiData");
        }

        async Task IDzuwenaliaDBContext.SaveChanges()
        {
            await base.SaveChangesAsync() ;
        }
    }
}
