using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreLogging
{
    public static class CoreLoggerRegistration
    {
        public static IServiceCollection AddCoreLogging(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICoreLogger<>), typeof(CoreLogger<>));
            services.AddSingleton<ICoreLoggerFactory, CoreLoggerFactory>();
            var provider = services.BuildServiceProvider();
            var factory = provider.GetService<ILoggerFactory>();
            ApplicationLogger.Initialize(factory);
            return services;
        }
    }
}