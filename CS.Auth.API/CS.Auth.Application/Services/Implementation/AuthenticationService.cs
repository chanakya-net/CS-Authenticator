using CS.Auth.Application.Contracts;
using CS.Auth.Application.DTO.Response;
using CS.Auth.Application.Services.Interface;

namespace CS.Auth.Application.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

#pragma warning disable CS1998 This would added once Domain and database is added
    public async Task<LoginResponse> ValidateLoginAsync(string userName, string password, CancellationToken cancellationToken = default)
#pragma warning restore CS1998
    {
        
        
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