using CS.Auth.API.Middleware;
using CS.Auth.Application;
using CS.Auth.Application.Configurations;
using CS.Auth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddOptions<TokenOptionConfiguration>().BindConfiguration("Auth:TokenOptionConfiguration");
    builder.Services.AddControllers();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
}



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();
{

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseMiddleware<ExceptionHandlerMiddleware>();
    app.MapControllers();
    app.Run();
}



