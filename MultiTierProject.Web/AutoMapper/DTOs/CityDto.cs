using System.ComponentModel.DataAnnotations;

namespace MultiTierProject.Web.AutoMapper.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
        public int RegionId { get; set; }
    }
}
