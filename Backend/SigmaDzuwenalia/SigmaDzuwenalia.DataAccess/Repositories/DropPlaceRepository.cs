using SigmaDzuwenalia.BuisnessServices.DropPlace;
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
    public class DropPlaceRepository : IDropPlaceRepository
    {
        private readonly IDzuwenaliaDBContextFactory _dzuwenaliaDBContextFactory;
        public DropPlaceRepository(IDzuwenaliaDBContextFactory dzuwenaliaDBContextFactory)
        {
            _dzuwenaliaDBContextFactory = dzuwenaliaDBContextFactory;
        }
        public async Task Add(DropPlace dropPlace)
        {
            var mappedDropPlace = AutoMapper.Mapper.Map<DropPlaceEntity>(dropPlace);
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            dbContext.DropPlace.Add(mappedDropPlace);
            await dbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var dropPlaceToDelete = dbContext.DropPlace.FirstOrDefault(x => x.Id == id);
            dbContext.DropPlace.Remove(dropPlaceToDelete);
            await dbContext.SaveChanges();
        }

        public async Task Edit(DropPlace dropPlace)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var dropPlaceToEdit = await dbContext.DropPlace.FirstAsync(x => x.Id == dropPlace.Id);
            dropPlaceToEdit.XCoordinate = dropPlace.XCoordinate;
            dropPlaceToEdit.YCoordinate = dropPlace.YCoordinate;
            dropPlaceToEdit.DropType = dropPlace.DropType;
            dropPlaceToEdit.DropDate = dropPlace.DropDate;

            await dbContext.SaveChanges();
        }

        public async Task<List<DropPlace>> GetAll()
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var dropPlaceList = await dbContext.DropPlace.ToListAsync();
            var mappedDropPlaceList = AutoMapper.Mapper.Map<List<DropPlace>>(dropPlaceList);

            return mappedDropPlaceList;
        }

        public async Task<DropPlace> GetById(int id)
        {
            var dbContext = _dzuwenaliaDBContextFactory.Create();
            var dropPlaceToGet = await dbContext.DropPlace.FirstAsync(x => x.Id == id);
            var mappedDropPlaceToGet = AutoMapper.Mapper.Map<DropPlace>(dropPlaceToGet);

            return mappedDropPlaceToGet;
        }
    }
}
