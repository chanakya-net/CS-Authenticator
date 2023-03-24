using Asp.Versioning;
using CS.Auth.Application.DTO.Request;
using CS.Auth.Application.DTO.Response;
using CS.Auth.Application.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CS.Auth.API.Controllers;

[Route("api/Auth")]
[ApiController]
[ApiVersion(1.0)]
[ApiVersion(2.0)]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]
    public Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("Login")]
    [MapToApiVersion(2.0)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var res = await _authenticationService.ValidateLoginAsync("111","222",default);
        return Ok(res);
    }
    
    
    [HttpPost("Login")]
    [MapToApiVersion(2.0)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginV2([FromBody] LoginRequest request)
    {
        var res = await _authenticationService.ValidateLoginAsync("111","222",default);
        return Ok(res);
    }
}