using SigmaDzuwenalia.BuisnessServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.BuisnessServices.Flanki
{
    public class FlankiService : IFlankiService
    {
        private readonly IFlankiRepository _flankiRepository;
        public FlankiService(IFlankiRepository flankiRepository)
        {
            _flankiRepository = flankiRepository;
        }
        public async Task Add(Flanki flanki)
        {
            await _flankiRepository.Add(flanki);
        }

        public async Task Edit(Flanki flanki)
        {
            await _flankiRepository.Edit(flanki);
        }

        public async Task<Flanki> GetById(int id)
        {
            var flanki = await _flankiRepository.GetById(id);
            return flanki;
        }

        public async Task<List<Flanki>> GetAll()
        {
            var flanki = await _flankiRepository.GetAll();
            return flanki;
        }
        public async Task Delete(Flanki flanki)
        {
            await _flankiRepository.Delete(flanki);
        }

    }
}
