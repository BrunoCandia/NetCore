using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore2.Helpers.Interfaces
{
    public interface IUserService
    {
        ClaimsPrincipal GetCurrentUser();
    }
}
