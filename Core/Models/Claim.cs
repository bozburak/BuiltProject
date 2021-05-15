using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Claim
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
