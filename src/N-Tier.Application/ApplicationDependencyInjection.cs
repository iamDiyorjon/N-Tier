using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using N_Tier.Application.Common.Email;
using N_Tier.Application.MappingProfiles;
using N_Tier.Application.Services;
using N_Tier.Application.Services.DevImpl;
using N_Tier.Application.Services.Impl;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;
using N_Tier.Shared.Services.Impl;
using System.Reflection;

namespace N_Tier.Application;

public static class ApplicationDependencyInjection
{
    
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddServices(env, assembly);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env, Assembly assembly)
    {
        var repositoryTypes = assembly.GetTypes()
           .Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Any(i => i.Name.EndsWith("Service")))
           .ToList();

        foreach (var repositoryType in repositoryTypes)
        {
            // Find the specific interface implemented by this repository
            var specificInterface = repositoryType.GetInterfaces()
                .FirstOrDefault(i => i.Name.EndsWith("Service") && i != typeof(IBaseRepository<>));

            if (specificInterface != null)
            {
                // Register the specific interface with the repository type
                Console.WriteLine($"Registering {repositoryType.Name} as {specificInterface.Name}");
                services.AddScoped(specificInterface, repositoryType);
            }
        }
        //services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        //services.AddScoped<ITodoListService, TodoListService>();
        //services.AddScoped<ITodoItemService, TodoItemService>();
        //services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClaimService, ClaimService>();
        //services.AddScoped<ITemplateService, TemplateService>();
        //services.AddScoped<ICategoryService, CategoryService>();
        //services.AddScoped<IProductService, ProductService>();

        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}
