using SigmaDzuwenalia.BuisnessServices.Flanki;
using SigmaDzuwenalia.BuisnessServices.Repositories;
using SigmaDzuwenalia.DataAccess.Entities;
using SigmaDzuwenalia.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task Delete(int id)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var flankiToDelete = dbContext.Flanki.FirstOrDefault(x => x.Id == id);
            dbContext.Flanki.Remove(flankiToDelete);
            await dbContext.SaveChanges();
        }

        public async Task Edit(Flanki flanki)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();

            var flankiToEdit = dbContext.Flanki.FirstOrDefault(x => x.Id == flanki.Id);
            flankiToEdit.coordinate_x = flanki.coordinate_x;
            flankiToEdit.coordinate_y = flanki.coordinate_y;
            flankiToEdit.date = flanki.date;
            flankiToEdit.name = flanki.name;
            await dbContext.SaveChanges();

        }

        public async Task<List<Flanki>> GetAll()
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var all = await dbContext.Flanki.ToListAsync();
            var mappedFlanki = AutoMapper.Mapper.Map<List<Flanki>>(all);
            return mappedFlanki;
        }

        public async Task<Flanki> GetById(int id)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var myId = dbContext.Flanki.FirstOrDefault(x => x.Id == id);
            var mappedId = AutoMapper.Mapper.Map<Flanki>(myId);
            return mappedId;


        }
    }
}
