using CS.Auth.Application.DTO.Enums;

namespace CS.Auth.Application.DTO.Request;

public sealed record RegisterUserRequest
{
    public required string UserName { get;init; }
    public required string Password { get;init; }
    public required string Name { get;init; }
    public required string Email { get;init; }
    public required string MobileNumber { get;init; }
    public required UserRoles Role { get;init; }
}