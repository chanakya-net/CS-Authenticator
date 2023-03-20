using System.Net;

namespace CS.Auth.API.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _request;

    public ExceptionHandlerMiddleware(RequestDelegate request)
    {
        _request = request;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (Exception e)
        {
            // TODO: need to handle exception and log it
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            Console.WriteLine(e.Message);
            await context.Response.WriteAsync("Internal Server Error");
        }
    }
    
}