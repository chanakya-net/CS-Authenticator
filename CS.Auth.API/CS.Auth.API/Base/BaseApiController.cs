using ErrorOr;

namespace CS.Auth.API.Base;

public class BaseApiController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Problem(List<Error> errorList)
    {
        var e = errorList.First();
        var problem = new ProblemDetails
        {
            Title = e.Description,
            Status = (int) e.Type,
            Detail = e.Description,
            Instance = HttpContext.Request.Path
        };
        return Problem(problem.Detail, problem.Title, problem.Status, problem.Instance);
    }
}