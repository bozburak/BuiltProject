using MultiTierProject.Core.AutoMapper.DTOs;

namespace MultiTierProject.Core.AutoMapper.DTOs
{
    public class CityWithRegionDto : CityDto
    {
        public RegionDto Region { get; set; }
    }
}
