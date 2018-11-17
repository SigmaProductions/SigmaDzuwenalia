using AutoMapper;
using SigmaDzuwenalia.DataAccess.Entities;
using SigmaDzuwenalia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigmaDzuwenalia
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<FlankiResource, BuisnessServices.Flanki.Flanki>().ReverseMap();
                config.CreateMap<BuisnessServices.Flanki.Flanki, FlankiEntity>().ReverseMap();
				config.CreateMap<PoliceResource, BuisnessServices.Police.Police>().ReverseMap();
                config.CreateMap<DropPlaceResource, BuisnessServices.DropPlace.DropPlace>().ReverseMap();
            });
        }
    }
}