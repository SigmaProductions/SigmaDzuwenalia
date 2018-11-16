using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.DropPlace
{
    public interface IDropPlaceService
    {
        Task Add(DropPlace dropPlace);
        Task Delete(int id);
        Task Edit(DropPlace dropPlace);
        Task<DropPlace> GetById(int id);
        Task<List<DropPlace>> GetAll();
    }
}
