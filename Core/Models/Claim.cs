using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
