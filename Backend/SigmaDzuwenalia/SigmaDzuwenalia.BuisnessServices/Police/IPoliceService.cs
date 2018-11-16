using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Police
{
    public interface IPoliceService
    {
        Task Add(Police police);
        Task Delete(int id);
        Task Edit(Police police);
    }
}
