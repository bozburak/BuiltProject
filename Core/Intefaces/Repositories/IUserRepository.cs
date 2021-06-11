using Core.Models;
using System.Collections.Generic;

namespace Core.Intefaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public IEnumerable<Claim> GetClaims(int userId);
    }
}
