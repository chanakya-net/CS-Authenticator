namespace CS.Auth.Application.DTO.Response;

public record RegisterUserResponse
{
    public required string Id { get;init; }
    public required string UserName { get;init; }
    public required string Name { get;init; }
    public required string Email { get;init; }
    public required bool IsActive { get;init; }
}