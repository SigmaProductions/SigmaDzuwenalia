﻿using SigmaDzuwenalia.BuisnessServices.Flanki;
using SigmaDzuwenalia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using System.Web.Http;

namespace SigmaDzuwenalia.Controllers
{
    [RoutePrefix("api/v1/flanki")]

    public class FlankiController : ApiController
    {
        private readonly IFlankiService _flankiService;
        public FlankiController(IFlankiService flankiService)
        {
            _flankiService = flankiService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(FlankiResource flankiResource)
        {
            var flanki = Mapper.Map<Flanki>(flankiResource);
            await _flankiService.Add(flanki);

            return Ok();
        }

    }
}
