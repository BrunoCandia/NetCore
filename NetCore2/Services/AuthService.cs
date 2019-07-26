using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using NetCore2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2.Services
{
    public class AuthService : IAuthService
    {
        public bool ValidateLogin(string user, string pass)
        {
            //Validamos sobre un base de datos o sobre Active directory

            return true;
        }

        public string GenerateToken(DateTime date, string user, TimeSpan validDate)
        {
            try
            {
                var expire = date.Add(validDate);

                var claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                          new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                          ClaimValueTypes.Integer64),
                new Claim("roles", "Cliente"),
                new Claim("roles", "Administrador")
                };

                var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("aaaAAA123XaaaAAA123XaaaAAA123XaaaAAA123X")),
                                                               SecurityAlgorithms.HmacSha256Signature);

                var jwt = new JwtSecurityToken
                (
                    issuer: "Ejemplo",
                    audience: "Public",
                    claims: claims,
                    notBefore: date,
                    expires: expire,
                    signingCredentials: signinCredentials
                );

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return encodedJwt;
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
