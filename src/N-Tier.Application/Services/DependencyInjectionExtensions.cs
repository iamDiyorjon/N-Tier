using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services
{
    public static class DependencyInjectionExtensionsclass
    {
            public static void RegisterServicesFromAssembly(this IServiceCollection services, Assembly assembly, Type serviceType)
            {
                // Find all types in the assembly that implement the specified service type
                var types = assembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && serviceType.IsAssignableFrom(t));

                foreach (var implementationType in types)
                {
                    // Register each found type with its interface
                    services.AddTransient(serviceType, implementationType);
                }
            }
    }
}
