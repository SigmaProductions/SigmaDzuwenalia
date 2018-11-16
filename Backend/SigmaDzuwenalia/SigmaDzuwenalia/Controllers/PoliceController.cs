using SigmaDzuwenalia.BuisnessServices.Police;
using SigmaDzuwenalia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SigmaDzuwenalia.Controllers
{
    [RoutePrefix("api/v1/police")]

    public class PoliceController : ApiController
    {
        private readonly IPoliceService _policeService;
        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(PoliceResource policeResource)
        {
            var mappedPolice = AutoMapper.Mapper.Map<Police>(policeResource);
            await _policeService.Add(mappedPolice);

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _policeService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Edit(PoliceResource policeResource)
        {
            var police = AutoMapper.Mapper.Map<Police>(policeResource);
            await _policeService.Edit(police);

            return Ok();
        }

        [HttpGet]
        public async Task<PoliceResource> GetById(int id)
        {
            var police = await _policeService.GetById(id);
            var policeReturn = AutoMapper.Mapper.Map<PoliceResource>(police);

            return policeReturn;
        }

        [HttpGet]
        public async Task<List<PoliceResource>> GetAll()
        {
            var policeList = await _policeService.GetAll();
            var policeListReturn = AutoMapper.Mapper.Map<List<PoliceResource>>(policeList);

            return policeListReturn;
        }
    }
}
