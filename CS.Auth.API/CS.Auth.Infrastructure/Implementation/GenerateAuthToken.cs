using CS.Auth.Application.Classes;
using CS.Auth.Application.Configurations;
using CS.Auth.Application.Contracts;
using Microsoft.Extensions.Options;

namespace CS.Auth.Infrastructure.Implementation;

public class GenerateAuthToken : IGenerateAuthToken
{
    private readonly TokenOptionConfiguration _tokenOptionConfiguration;

    public GenerateAuthToken(IOptions<TokenOptionConfiguration> tokenOptionConfiguration)
    {
        _tokenOptionConfiguration = tokenOptionConfiguration.Value;
    }

    public Task<string> GenerateTokenAsync(TokenGenerationSettings settings)
    {
        throw new NotImplementedException();
    }
}