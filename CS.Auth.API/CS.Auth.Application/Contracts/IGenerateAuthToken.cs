using CS.Auth.Application.Classes;

namespace CS.Auth.Application.Contracts;

public interface IGenerateAuthToken
{
    Task<string> GenerateTokenAsync(TokenGenerationSettings settings);
}