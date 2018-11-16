using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigmaDzuwenalia.BuisnessServices.Police;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Repositories
{
    public interface IPoliceRepository
    {
        Task Add(Police.Police police);
        Task Delete(int id);
        Task Edit(Police.Police police);
        Task<Police.Police> GetById(int id);
        Task<List<Police.Police>> GetAll();
    }
}
