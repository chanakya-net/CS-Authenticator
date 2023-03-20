namespace CS.Auth.Application.Classes;

public sealed record TokenGenerationSettings
{
    public required string UserIdentifier { get; set; }
    public required string Audience { get; init; }
    public required IEnumerable<string> Roles { get; init; }
}