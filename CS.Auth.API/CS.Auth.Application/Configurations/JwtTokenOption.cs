namespace CS.Auth.Application.Configurations;

public record JwtTokenOption
{
    public required string Issuer { get; init; }
    public required string ExpireAfterHrs { get; set; }
    public required string Audience { get; set; }
    public required string Key { get; set; }
}
