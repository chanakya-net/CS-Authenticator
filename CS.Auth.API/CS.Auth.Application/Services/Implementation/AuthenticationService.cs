using CS.Auth.Application.DTO.Response;
using CS.Auth.Application.Services.Interface;

namespace CS.Auth.Application.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    public Task<LoginResponse> ValidateLoginAsync(string userName, string password, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}