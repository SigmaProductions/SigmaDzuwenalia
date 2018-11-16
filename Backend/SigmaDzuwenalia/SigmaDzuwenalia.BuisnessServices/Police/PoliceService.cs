using SigmaDzuwenalia.BuisnessServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Police
{
    public class PoliceService : IPoliceService
    {
        private readonly IPoliceRepository _policeRepository;
        public PoliceService(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }
        public async Task Add(Police police)
        {
            await _policeRepository.Add(police);
        }
        public async Task Delete(int id)
        {
            await _policeRepository.Delete(id);
        }
        public async Task Edit(Police police)
        {
            await _policeRepository.Edit(police);
        }
    }
}
