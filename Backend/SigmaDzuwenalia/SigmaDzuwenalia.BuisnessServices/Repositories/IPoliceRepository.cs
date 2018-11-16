using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigmaDzuwenalia.BuisnessServices.Flanki;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Repositories
{
    public interface IPoliceRepository
    {
        Task Add(Police.Police police);
        Task Delete(int id);
        Task Edit(Police.Police police);
        Task GetById(int id);
    }
}
