namespace CS.Auth.Application.Services.Interface;

public interface IAuthenticationService
{
    Task<ErrorOr<LoginResponse>>
        ValidateLoginAsync(string userName, string password, CancellationToken cancellationToken);
}