using _apiTemplate_.Api.Middleware;

namespace _apiTemplate_.Api;
static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen(option =>
        //{
        //    option.SwaggerDoc("v1", new() { Title = "Employee API", Version = "v1" });

        //    //var locationOfExecutable = Assembly.GetExecutingAssembly().Location;
        //    //var execFileNameWithoutExtension = Path.GetFileNameWithoutExtension(locationOfExecutable);
        //    //var execFilePath = Path.GetDirectoryName(locationOfExecutable);
        //    //var xmlFilePath = Path.Combine(execFilePath!, $"{execFileNameWithoutExtension}.xml");

        //    //option.IncludeXmlComments(xmlFilePath);
        //});

        services.AddCors();
        services.AddTransient<ExceptionHandlingMiddleware>();

        return services;
    }
}
