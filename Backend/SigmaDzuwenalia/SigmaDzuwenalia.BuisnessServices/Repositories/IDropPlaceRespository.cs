using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigmaDzuwenalia.BuisnessServices.DropPlace;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Repositories
{
    public interface IDropPlaceRepository
    {
        Task Add(DropPlace.DropPlace dropPlace);
        Task Delete(int id);
        Task Edit(DropPlace.DropPlace dropPlace);
        Task<DropPlace.DropPlace> GetById(int id);
        Task<List<DropPlace.DropPlace>> GetAll();
    }
}
