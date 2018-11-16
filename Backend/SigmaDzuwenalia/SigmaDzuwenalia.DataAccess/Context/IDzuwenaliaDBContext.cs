using SigmaDzuwenalia.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Context
{
    public interface IDzuwenaliaDBContext: IDisposable
    {
        IDbSet<FlankiEntity> Flanki { get; set; }
        
        Task SaveChanges();
    }
}
