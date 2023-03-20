using CS.Auth.Application.DTO.Response;

namespace CS.Auth.Application.Services.Interface;

public interface IAuthenticationService
{
    Task<LoginResponse>
        ValidateLoginAsync(string userName, string password, CancellationToken cancellationToken);
}