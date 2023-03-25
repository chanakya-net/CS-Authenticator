using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using CS.Auth.API.Exceptions;
using CS.Auth.API.Middleware;
using CS.Auth.API.Swagger;
using CS.Auth.Application;
using CS.Auth.Application.Configurations;
using CS.Auth.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddOptions<JwtTokenOption>().BindConfiguration("Auth:TokenOptionConfiguration");
    builder.Services.TryAddSingleton<ProblemDetailsFactory,AuthProblemDetailsFactory>();
    builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
    builder.Services.AddApiVersioning(apiVersionOptions =>
        {
            apiVersionOptions.DefaultApiVersion = new ApiVersion(1.0);
            apiVersionOptions.AssumeDefaultVersionWhenUnspecified = true;
            apiVersionOptions.ReportApiVersions = true;
            apiVersionOptions.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
        }
        ).AddMvc().AddApiExplorer();
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
}



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();
{

    if(builder.Configuration.GetValue<bool>("AllowSwagger"))
    {
        app.UseExceptionHandler("/exception");
        app.UseSwagger();
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
    }
    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}



