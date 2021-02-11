using System.ComponentModel.DataAnnotations;

namespace MultiTierProject.API.AutoMapper.DTOs
{
    public class RegionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
    }
}
