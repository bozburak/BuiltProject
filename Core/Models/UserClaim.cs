using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class UserClaim
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ClaimId { get; set; }
    }
}
