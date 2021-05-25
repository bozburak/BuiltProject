using Core.Models;
using System.Collections.Generic;

namespace Core.Intefaceses.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public IEnumerable<Claim> GetClaims(int userId);
    }
}
