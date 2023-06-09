using Asp.Versioning.ApiExplorer;
using CS.Auth.API.Base;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CS.Auth.API.Swagger;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }
    public void Configure(SwaggerGenOptions options)
    {
        // add swagger document for every API version discovered
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }
    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    private OpenApiInfo CreateVersionInfo(
        ApiVersionDescription desc)
    {
        var info = new OpenApiInfo()
        {
            Title = "Decisions (MeetingCulture.AI) API",
            Version = desc.ApiVersion.ToString()
        };

        if (desc.IsDeprecated)
        {
            info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        }

        return info;
    }
}

public class ExcludeControllersDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var excludedControllers = new[] { typeof(BaseApiController) };

        foreach (var apiDescription in context.ApiDescriptions)
        {
            var controllerActionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor == null) continue;

            var controllerType = controllerActionDescriptor.ControllerTypeInfo.AsType();
            if (excludedControllers.Contains(controllerType))
            {
                swaggerDoc.Paths.Remove("/" + apiDescription.RelativePath);
            }
        }
    }
}