using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore2.Services.Interfaces;

namespace NetCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("token")]
        public ActionResult Token([FromBody]UserData userData)
        {
            if (this.authService.ValidateLogin(userData.UserName, userData.Password))
            {
                var date = DateTime.UtcNow;
                var expireDate = TimeSpan.FromHours(5);

                var expireDateTime = date.Add(expireDate);

                var token = this.authService.GenerateToken(date, userData.UserName, expireDate);

                return Ok(new { Token = token, ExpiredAt = expireDateTime });
            }
            else
            {
                return StatusCode(401);
            }
        }
    }

    public class UserData
    {
        public string UserName { get; set; }
        public string Password { get; set; }        
    }
}