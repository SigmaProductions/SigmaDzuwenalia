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
            Police police = new Police();
            await _policeService.Add(police);

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

            return Ok();
        }
    }
}
