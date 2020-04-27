namespace CoreLogging
{
    using Microsoft.Extensions.DependencyInjection;

    public static class CoreLoggerRegistration
    {
        public static IServiceCollection AddCoreLogging(this IServiceCollection services)
        {
            services.AddSingleton<ICoreLoggerFactory, CoreLoggerFactory>();
            services.AddSingleton(typeof(ICoreLogger<>), typeof(CoreLogger<>));
            var provider = services.BuildServiceProvider();
            var factory = provider.GetService<ICoreLoggerFactory>();
            ApplicationLogger.Initialize(factory);
            return services;
        }
    }
}