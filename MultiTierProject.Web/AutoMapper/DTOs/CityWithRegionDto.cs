using MultiTierProject.Web.AutoMapper.DTOs;

namespace MultiTierProject.Web.AutoMapper.DTOs
{
    public class CityWithRegionDto : CityDto
    {
        public RegionDto Region { get; set; }
    }
}
