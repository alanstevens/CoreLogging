using Microsoft.Extensions.DependencyInjection;

namespace CoreLoggingAbstractions
{
    public static class CoreLoggerRegistration
    {
        public static void AddCoreLogging(this IServiceCollection services)
        {

            services.AddSingleton<ICoreLoggerFactory, CoreLoggerFactory>();
        }
    }
}