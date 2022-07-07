using banner.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Security
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly JwtSettings _jwtSettings;

        public RefreshTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings) => (_tokenGenerator, _jwtSettings) = (tokenGenerator, jwtSettings);

        public string Generate(User user)
        {
            List<Claim> claims = new()
            {
                new Claim("Id", user.Id.ToString()),
            };
            return _tokenGenerator.Generate( _jwtSettings.RefreshTokenSecret,
            _jwtSettings.Issuer, _jwtSettings.Audience,
            _jwtSettings.RefreshTokenExpirationMinutes, claims);
        }

    }

}
