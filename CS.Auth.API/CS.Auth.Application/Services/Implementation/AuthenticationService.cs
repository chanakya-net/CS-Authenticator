using CS.Auth.Domain.Errors;

namespace CS.Auth.Application.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public async Task<ErrorOr<LoginResponse>> ValidateLoginAsync(string userName, string password, CancellationToken cancellationToken = default)
    {
        if (userName.Contains("chanakya"))
        {
            return DomainErrors.UserErrors.AccountLocked;
        }

        // var user = await _userRepository.GetUserAsync(userName, cancellationToken);
        // if (user == null)
        // {
        //     throw new Exception("User not found");
        // }
        // var isPasswordValid = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        // if (isPasswordValid == PasswordVerificationResult.Failed)
        // {
        //     throw new Exception("Invalid password");
        // }
        
         var token = _jwtTokenGenerator.GenerateTokenAsync("UserName", new[] {"Admin"});
         return new LoginResponse
         {
             Email = "test@email.com",
             Token = token,
             UserName = "test",
             Id = "null",
             Name = "null",
         };
    }
}