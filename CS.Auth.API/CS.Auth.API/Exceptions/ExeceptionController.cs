namespace CS.Auth.API.Exceptions;
[ApiExplorerSettings(IgnoreApi=true)]
public class ExceptionController : ControllerBase
{
    [Route("/exception")]
    public IActionResult ExceptionHandler()
    {
        return Problem();
    }
}