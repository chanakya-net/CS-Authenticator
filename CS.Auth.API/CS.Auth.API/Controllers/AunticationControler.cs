using Asp.Versioning;
using CS.Auth.API.Base;
using CS.Auth.Application.DTO.Request;
using CS.Auth.Application.DTO.Response;
using CS.Auth.Application.Services.Interface;

namespace CS.Auth.API.Controllers;


[ApiController]
[Route("api/Auth")]
[ApiVersion(1.0)]
[ApiVersion(2.0)]
public class AuthenticationController : BaseApiController
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
    [MapToApiVersion(1.0)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var res = 
            await _authenticationService.ValidateLoginAsync(request.UserName,request.Password,default);
        return res.Match(
        
            Ok,
            errors => base.Problem(errors)
        );
        
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