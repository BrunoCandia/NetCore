using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NetCore2.Helpers.Interfaces;

namespace NetCore2.Helpers
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetCurrentUser()
        {
            return httpContextAccessor.HttpContext.User;
        }
    }
}
