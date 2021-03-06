using banner.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Security
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly JwtSettings _jwtSettings;

        public AccessTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings) =>(_tokenGenerator, _jwtSettings) = (tokenGenerator, jwtSettings);

        public string Generate(User user)
        {
            List<Claim> claims = new()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email ?? ""),
                new Claim("Name", user.FirstName + user.LastName),
                new Claim("Username", user.Username),
                new Claim("Phone", user.Phone)
            };
            return _tokenGenerator.Generate(_jwtSettings.AccessTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience,_jwtSettings.AccessTokenExpirationMinutes,claims);
        }
    }

}
