using AutoMapper;
using MultiTierProject.Core.AutoMapper.DTOs;
using MultiTierProject.Core.Models;

namespace MultiTierProject.API.AutoMapper.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<RegionDto, Region>();
            CreateMap<CityDto, City>();
            CreateMap<City, CityDto>();
            CreateMap<Region, RegionWithCityDto>();
            CreateMap<RegionWithCityDto, Region>();
            CreateMap<City, CityWithRegionDto>();
            CreateMap<CityWithRegionDto, City>();
        }
    }
}
