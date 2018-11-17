using SigmaDzuwenalia.BuisnessServices.DropPlace;
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
    [RoutePrefix("api/v1/dropPlace")]

    public class DropPlaceController : ApiController
    {
        private readonly IDropPlaceService _dropPlaceService;
        public DropPlaceController(IDropPlaceService dropPlaceService)
        {
            _dropPlaceService = dropPlaceService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(DropPlaceResource dropPlaceResource)
        {
            var mappedDropPlace = AutoMapper.Mapper.Map<DropPlace>(dropPlaceResource);
            await _dropPlaceService.Add(mappedDropPlace);

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _dropPlaceService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Edit(DropPlaceResource dropPlaceResource)
        {
            var dropPlace = AutoMapper.Mapper.Map<DropPlace>(dropPlaceResource);
            await _dropPlaceService.Edit(dropPlace);

            return Ok();
        }

        [HttpGet]
        public async Task<DropPlaceResource> GetById(int id)
        {
            var dropPlace = await _dropPlaceService.GetById(id);
            var dropPlaceReturn = AutoMapper.Mapper.Map<DropPlaceResource>(dropPlace);

            return dropPlaceReturn;
        }

        [HttpGet]
        public async Task<List<DropPlaceResource>> GetAll()
        {
            var dropPlaceList = await _dropPlaceService.GetAll();
            var dropPlaceListReturn = AutoMapper.Mapper.Map<List<DropPlaceResource>>(dropPlaceList);

            return dropPlaceListReturn;
        }
    }
}
