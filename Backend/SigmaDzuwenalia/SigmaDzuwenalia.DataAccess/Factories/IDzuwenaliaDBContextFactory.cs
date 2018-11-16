using SigmaDzuwenalia.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Factories
{
    public interface IDzuwenaliaDBContextFactory
    {
        IDzuwenaliaDBContext Create();
    }
}
