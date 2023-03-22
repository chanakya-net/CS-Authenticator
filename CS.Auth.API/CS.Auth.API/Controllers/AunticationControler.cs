using CS.Auth.Application.DTO.Request;
using CS.Auth.Application.Services.Interface;

namespace CS.Auth.API.Controllers;

[Route("api/Auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var res = await _authenticationService.ValidateLoginAsync("111","222",default);
        return Ok(res);
    }
}