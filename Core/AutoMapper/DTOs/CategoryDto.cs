using System.ComponentModel.DataAnnotations;

namespace Core.AutoMapper.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
    }
}
