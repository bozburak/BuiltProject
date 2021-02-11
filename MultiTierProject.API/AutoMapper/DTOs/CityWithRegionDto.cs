using MultiTierProject.API.AutoMapper.DTOs;

namespace MultiTierProject.API.AutoMapper.DTOs
{
    public class CityWithRegionDto : CityDto
    {
        public RegionDto Region { get; set; }
    }
}
