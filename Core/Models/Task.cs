using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
