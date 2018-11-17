using SigmaDzuwenalia.BuisnessServices.Police;
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
    public class PoliceRepository : IPoliceRepository
    {
        private readonly IDzuwenaliaDBContextFactory _dzuwenaliaDBContextFactory;
        public PoliceRepository(IDzuwenaliaDBContextFactory dzuwenaliaDBContextFactory)
        {
            _dzuwenaliaDBContextFactory = dzuwenaliaDBContextFactory;
        }
        public async Task Add(Police police)
        {
            var mappedPolice = AutoMapper.Mapper.Map<PoliceEntity>(police);
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            dbContext.Police.Add(mappedPolice);
            await dbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var policeToDelete = dbContext.Police.FirstOrDefault(x => x.Id == id);
            dbContext.Police.Remove(policeToDelete);
            await dbContext.SaveChanges();
        }

        public async Task Edit(Police police)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var policeToEdit = await dbContext.Police.FirstAsync(x => x.Id == police.Id);
            policeToEdit.XCoordinate = police.XCoordinate;
            policeToEdit.YCoordinate = police.YCoordinate;
            policeToEdit.PatrolSize = police.PatrolSize;
            policeToEdit.PatrolDate = police.PatrolDate;
            await dbContext.SaveChanges();
        }

        public async Task<List<Police>> GetAll()
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var policeList = await dbContext.Police.ToListAsync();
            var mappedPoliceList = AutoMapper.Mapper.Map<List<Police>>(policeList);

            return mappedPoliceList;
        }

        public async Task<Police> GetById(int id)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var policeToGet = await dbContext.Police.FirstAsync(x => x.Id == id);
            var mappedPoliceToGet = AutoMapper.Mapper.Map<Police>(policeToGet);

            return mappedPoliceToGet;
        }
    }
}
