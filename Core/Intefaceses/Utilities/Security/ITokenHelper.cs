using Core.Models;
using System.Collections.Generic;

namespace Core.Intefaceses.Utilities.Security
{
    public interface ITokenHelper
    {
        public AccessToken CreateToken(User user, IEnumerable<Claim> claims);
    }
}
