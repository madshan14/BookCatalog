using System.Reflection;

namespace BookCatalog.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClassesWithAttributes<TAttribute>(
            this IServiceCollection services, Assembly assembly) where TAttribute : Attribute
        {
            var typesWithAttribute = assembly.GetTypes()
            .Where(type => type.IsClass && type.GetCustomAttributes(typeof(TAttribute), true).Any());

            foreach (var type in typesWithAttribute)
            {
                var interfaceType = GetServiceInterface(type);
                if (interfaceType != null)
                {
                    services.AddScoped(typeof(Type), type);
                }
                else
                {
                    services.AddScoped(typeof(Type),type);
                }
            }

            return services;
        }
        private static Type GetServiceInterface(Type implementationType)
        {
            return implementationType.GetInterfaces().FirstOrDefault(i => i.IsAssignableFrom(implementationType));
        }
    }
}
