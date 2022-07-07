using banner.Models;
using System.Threading.Tasks;

namespace Security
{
    //public class RefreshCommandHandler
    //{
    //    private readonly IAuthenticateService _authenticateService;
    //    private readonly IRefreshTokenValidator _refreshTokenValidator;

    //    public RefreshCommandHandler(IRefreshTokenValidator refreshTokenValidator, IAuthenticateService authenticateService)
    //    {
    //        _refreshTokenValidator = refreshTokenValidator;
    //        _authenticateService = authenticateService;
    //        ;

    //    }

        //public async Task<AuthenticateResponse> Handle(string refreshRequest)
        //{
        //    var isValidRefreshToken = _refreshTokenValidator.Validate(refreshRequest);
        //    if (!isValidRefreshToken) return new AuthenticateResponse { AccessToken = "INVALID REFRESH TOKEN", RefreshToken = refreshRequest };
        //    refreshRequest.Equals(refreshRequest);
        //    return await _authenticateService.Authenticate(user);
        //}

    }

