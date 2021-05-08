using System.ComponentModel.DataAnnotations;

namespace Core.AutoMapper.DTOs
{
    public class TaskDto
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
