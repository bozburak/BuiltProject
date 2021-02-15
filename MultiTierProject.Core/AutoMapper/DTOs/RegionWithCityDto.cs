using System.Collections.Generic;

namespace MultiTierProject.Core.AutoMapper.DTOs
{
    public class RegionWithCityDto : RegionDto
    {
        public ICollection<CityDto> Cities { get; set; }
    }
}
