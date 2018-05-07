using Microsoft.Extensions.DependencyInjection;

namespace CoreLogging
{
    public static class CoreLoggerRegistration
    {
        public static void AddCoreLogging(this IServiceCollection services)
        {

            services.AddSingleton<ICoreLoggerFactory, CoreLoggerFactory>();
        }
    }
}