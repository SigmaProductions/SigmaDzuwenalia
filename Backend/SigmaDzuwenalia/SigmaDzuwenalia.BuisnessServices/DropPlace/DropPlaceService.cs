using SigmaDzuwenalia.BuisnessServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.DropPlace
{
    public class DropPlaceService : IDropPlaceService
    {
        private readonly IDropPlaceRepository _dropPlaceRepository;
        public DropPlaceService(IDropPlaceRepository dropPlaceRepository)
        {
            _dropPlaceRepository = dropPlaceRepository;
        }
        public async Task Add(DropPlace dropPlace)
        {
            await _dropPlaceRepository.Add(dropPlace);
        }
        public async Task Delete(int id)
        {
            await _dropPlaceRepository.Delete(id);
        }
        public async Task Edit(DropPlace dropPlace)
        {
            await _dropPlaceRepository.Edit(dropPlace);
        }
        public async Task<DropPlace> GetById(int id)
        {
            var dropPlaceReturn = await _dropPlaceRepository.GetById(id);

            return dropPlaceReturn;
        }
        public async Task<List<DropPlace>> GetAll()
        {
            var dropPlaceList = await _dropPlaceRepository.GetAll();

            return dropPlaceList;
        }
    }
}
