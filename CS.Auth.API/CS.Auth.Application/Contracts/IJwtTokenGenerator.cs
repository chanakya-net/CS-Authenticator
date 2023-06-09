namespace CS.Auth.Application.Contracts;

public interface IJwtTokenGenerator
{
    string GenerateTokenAsync(string userId, string[] roles);
}