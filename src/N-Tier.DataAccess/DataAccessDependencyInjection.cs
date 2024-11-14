using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N_Tier.DataAccess.Identity;
using N_Tier.DataAccess.Persistence;
using N_Tier.DataAccess.Repositories;
using N_Tier.DataAccess.Repositories.Impl;
using System.Reflection;
using System.Threading.RateLimiting;

namespace N_Tier.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddIdentity();
        services.AddRepositories(Assembly.GetExecutingAssembly());
        //Rate Limiting
        services .AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddFixedWindowLimiter("fixed", options =>
            {
                options.PermitLimit = 3;
                options.Window = TimeSpan.FromSeconds(10);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 5;
            });
        });

        return services;
    }

    private static void AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        
        var repositoryTypes = assembly.GetTypes()
           .Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Any(i => i.Name.EndsWith("Repository")))
           .ToList();

        foreach (var repositoryType in repositoryTypes)
        {
            // Find the specific interface implemented by this repository
            var specificInterface = repositoryType.GetInterfaces()
                .FirstOrDefault(i => i.Name.EndsWith("Repository") && i != typeof(IBaseRepository<>));

            if (specificInterface != null)
            {
                // Register the specific interface with the repository type
                Console.WriteLine($"Registering {repositoryType.Name} as {specificInterface.Name}");
                services.AddScoped(specificInterface, repositoryType);
            }
        }
        //services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        //services.AddScoped<ITodoListRepository, TodoListRepository>();
        //services.AddScoped<ICategoryRepository, CategoryRepository>();
        //services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

        if (databaseConfig.UseInMemoryDatabase)
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("NTierDatabase");
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
        else
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(databaseConfig.ConnectionString,
                    opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
    }

    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }
}

// TODO move outside?
public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public string ConnectionString { get; set; }
}
