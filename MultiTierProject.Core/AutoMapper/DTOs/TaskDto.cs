using System.ComponentModel.DataAnnotations;

namespace MultiTierProject.Core.AutoMapper.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
    }
}
