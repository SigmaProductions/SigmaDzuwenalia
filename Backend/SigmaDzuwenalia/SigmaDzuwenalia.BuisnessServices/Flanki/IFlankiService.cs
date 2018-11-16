using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Flanki
{
    public interface IFlankiService
    {
        Task Add(Flanki flanki);
        Task Edit(Flanki flanki);
        Task<Flanki> GetById(int id);
        Task<List<Flanki>> GetAll();
        Task Delete(Flanki flanki);
    }
}
