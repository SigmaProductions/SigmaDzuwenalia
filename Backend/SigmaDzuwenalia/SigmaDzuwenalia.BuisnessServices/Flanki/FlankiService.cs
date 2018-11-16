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
    }
}
