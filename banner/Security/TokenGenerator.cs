using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security
{
    public class TokenGenerator : ITokenGenerator
    {
        public string Generate(string secretKey, string issuer, string audience, double expires, IEnumerable<Claim> claims = null) =>
            new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken 
                (issuer, audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(expires),
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256)));
    }

}
