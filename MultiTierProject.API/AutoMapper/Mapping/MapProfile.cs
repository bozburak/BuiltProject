using AutoMapper;
using MultiTierProject.API.AutoMapper.DTOs;
using MultiTierProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTierProject.API.AutoMapper.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<RegionDto, Region>();
        }
    }
}
