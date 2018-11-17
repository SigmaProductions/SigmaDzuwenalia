using SigmaDzuwenalia.BuisnessServices.Police;
using SigmaDzuwenalia.BuisnessServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Repositories
{
    public class PoliceRepository : IPoliceRepository
    {
        public Task Add(Police police)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Police police)
        {
            throw new NotImplementedException();
        }

        public Task<List<Police>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Police> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
