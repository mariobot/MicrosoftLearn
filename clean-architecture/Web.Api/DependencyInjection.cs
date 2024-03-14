using Web.Api.Middleware;

namespace Web.Api;

public static class DependencyInjection
{   
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return services;
    }
}