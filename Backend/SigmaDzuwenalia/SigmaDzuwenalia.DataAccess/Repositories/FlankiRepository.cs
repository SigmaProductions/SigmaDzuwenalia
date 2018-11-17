using SigmaDzuwenalia.BuisnessServices.Flanki;
using SigmaDzuwenalia.BuisnessServices.Repositories;
using SigmaDzuwenalia.DataAccess.Entities;
using SigmaDzuwenalia.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Repositories
{
    public class FlankiRepository : IFlankiRepository
    {
        private readonly IDzuwenaliaDBContextFactory _dzuwenaliaDBContextFactory;

        public FlankiRepository(IDzuwenaliaDBContextFactory dzuwenaliaDBContextFactory)
        {
            _dzuwenaliaDBContextFactory = dzuwenaliaDBContextFactory;
        }
        public async Task Add(Flanki flanki)
        {
            var mappedFlanki = AutoMapper.Mapper.Map<FlankiEntity>(flanki);
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            dbContext.Flanki.Add(mappedFlanki);
            await dbContext.SaveChanges();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Flanki flanki)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flanki>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Flanki> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
