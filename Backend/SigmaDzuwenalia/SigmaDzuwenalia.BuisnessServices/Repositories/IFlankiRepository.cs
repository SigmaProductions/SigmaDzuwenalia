using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigmaDzuwenalia.BuisnessServices.Flanki;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Repositories
{
    public interface IFlankiRepository
    {
        Task Add(Flanki.Flanki flanki);
    }
}
