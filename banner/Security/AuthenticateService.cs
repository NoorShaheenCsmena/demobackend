using banner.Models;

namespace Security
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService){_accessTokenService = accessTokenService;_refreshTokenService = refreshTokenService;}
        public AuthenticateResponse Authenticate(User user)=> new() { AccessToken = _accessTokenService.Generate(user),RefreshToken = _refreshTokenService.Generate(user)};
    }

}
