namespace CS.Auth.Application.DTO.Request;

public sealed record LoginRequest
{
    public required string UserName { get;init; }
    public required string Password { get;init; }
}