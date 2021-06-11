using Core.Intefaces.Repositories;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ProjectDbContext _projectDbContext { get => _context as ProjectDbContext; }
        public UserRepository(ProjectDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Claim> GetClaims(int userId)
        {
            return (from claim in _projectDbContext.Claims join
                          userClaim in _projectDbContext.UserClaims on
                          claim.Id equals userClaim.ClaimId select new Claim
                          {
                              Id = claim.Id,
                              Name = claim.Name
                          }).ToList();
        }
    }
}
