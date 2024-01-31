using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookCatalog.Entities.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAttributedServices(this IServiceCollection services, params Type[] attributeTypes)
        {
            var assemblies = attributeTypes.Select(type => type.Assembly).Distinct().ToArray();


            foreach (Type attributeType in attributeTypes)
            {
                var serviceTypes = assemblies.SelectMany(assembly => assembly.GetTypes()
                                        .Where(type => type.GetCustomAttributes(attributeType, false).Any()));

                foreach (var serviceType in serviceTypes)
                {
                    var interfaceType = serviceType.GetInterfaces().LastOrDefault();

                    if (interfaceType != null)
                    {
                        services.AddScoped(interfaceType, serviceType);
                        Console.WriteLine($"Registered: {interfaceType.FullName} - {serviceType.FullName}");
                    }
                }
            }

            return services;
        }
    }
}
