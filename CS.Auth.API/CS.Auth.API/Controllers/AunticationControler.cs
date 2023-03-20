using CS.Auth.Application.DTO.Request;

namespace CS.Auth.API.Controllers;

[Route("api/Auth")]
[ApiController]
public class AunticationControler : ControllerBase
{
    [HttpPost("Register")]
    public Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("Login")]
    public Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        throw new NotImplementedException();
    }
}