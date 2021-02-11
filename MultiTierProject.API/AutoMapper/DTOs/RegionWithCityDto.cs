using System.Collections.Generic;

namespace MultiTierProject.API.AutoMapper.DTOs
{
    public class RegionWithCityDto : RegionDto
    {
        public ICollection<CityDto> Cities { get; set; }
    }
}
