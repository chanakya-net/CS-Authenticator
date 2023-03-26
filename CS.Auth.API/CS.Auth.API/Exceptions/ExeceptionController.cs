namespace CS.Auth.API.Exceptions;
[ApiExplorerSettings(IgnoreApi=true)]
public class ExceptionController : ControllerBase
{
    [Route("/exception")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult ExceptionHandler()
    {
        return Problem();
    }
}