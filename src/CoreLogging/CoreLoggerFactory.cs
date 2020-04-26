namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Logging;

    public class CoreLoggerFactory : ICoreLoggerFactory
    {
        readonly ILoggerFactory _factory;

        public CoreLoggerFactory(ILoggerFactory factory)
        {
            if(factory is null) throw new ArgumentNullException(nameof(factory));
            _factory = factory;
        }

        public ICoreLogger<T> CreateLogger<T>()
        {
            return new CoreLogger<T>(_factory);
        }

        public ICoreLogger CreateLogger(object loggingCategory)
        {
            var sourceType = GetSourceType(loggingCategory);

            var logger = LoggerFactoryExtensions.CreateLogger(_factory, sourceType);

            return new CoreLogger(logger);
        }

        static Type GetSourceType(object source)
        {
            var sourceType = source.GetType();
            if (sourceType == typeof(Type))
                sourceType = source as Type;
            return sourceType;
        }

        ILogger ILoggerFactory.CreateLogger(string categoryName)
        {
            var logger = _factory.CreateLogger(categoryName);
            return new CoreLogger(logger);
        }

        void IDisposable.Dispose()
        {
            _factory?.Dispose();
        }

        void ILoggerFactory.AddProvider(ILoggerProvider provider)
        {
            _factory.AddProvider(provider);
        }
    }
}