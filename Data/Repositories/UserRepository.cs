using Core.Intefaceses.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ProjectDbContext _projectDbContext { get => _context as ProjectDbContext; }
        public UserRepository(ProjectDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Claim> GetClaims(int userId)
        {
            var result = _projectDbContext.UserClaims.Join(_projectDbContext.Claims, userClaims => userClaims.Id, claims => claims.Id,
                (userClaims, claims) => new Claim
                {
                    Id = claims.Id,
                    Name = claims.Name
                }).ToList();
            return result;
        }
    }
}
