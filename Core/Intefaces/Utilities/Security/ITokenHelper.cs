using Core.Models;
using System.Collections.Generic;

namespace Core.Intefaces.Utilities.Security
{
    public interface ITokenHelper
    {
        public Token CreateToken(User user, IEnumerable<Claim> claims);
    }
}
