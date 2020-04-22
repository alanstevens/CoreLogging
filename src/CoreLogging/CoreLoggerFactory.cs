namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Internal;
    using Microsoft.Extensions.Logging;

    public class CoreLoggerFactory : ICoreLoggerFactory
    {
        private readonly ILoggerFactory _factory;

        public CoreLoggerFactory(ILoggerFactory factory)
        {
            _factory = factory;
        }

        public ICoreLogger<T> CreateLogger<T>()
        {
            return new CoreLogger<T>(_factory);
        }

        public ICoreLogger CreateLogger(Type loggingCategory)
        {
            var categoryName = TypeNameHelper.GetTypeDisplayName(loggingCategory);
            return CreateLogger(categoryName) as ICoreLogger;
        }

        public ILogger CreateLogger(string categoryName)
        {
            var logger = _factory.CreateLogger(categoryName);
            return new CoreLogger(logger);
        }

        public void Dispose()
        {
            _factory.Dispose();
        }

        public void AddProvider(ILoggerProvider provider)
        {
            _factory.AddProvider(provider);
        }
    }
}