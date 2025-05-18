using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

namespace BookingAPI;

public static class ConfigureServices
{
    public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        object value = services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddCors(p => p.AddPolicy("corspolicy", builder =>
        {
            builder.WithOrigins("http://localhost:5173", "gentle-forest-0a8d7bb03.6.azurestaticapps.net")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()
                   .WithExposedHeaders("Content-Disposition");
        }));

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("api", new OpenApiInfo { Title = "Booking API" });
        });

        return services;
    }
}
