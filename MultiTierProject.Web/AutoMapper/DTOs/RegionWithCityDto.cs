using System.Collections.Generic;

namespace MultiTierProject.Web.AutoMapper.DTOs
{
    public class RegionWithCityDto : RegionDto
    {
        public ICollection<CityDto> Cities { get; set; }
    }
}
