using System;
using Microsoft.Extensions.Logging;

namespace CoreLoggingAbstractions
{
    public class CoreLoggerFactory : ICoreLoggerFactory
    {
        public CoreLoggerFactory(ILoggerFactory factory) => _factory = factory;

        readonly ILoggerFactory _factory;

        public ICoreLogger<T> CreateLogger<T>()
        {
            var logger = _factory.CreateLogger<T>();
            return new CoreLogger<T>(logger);
        }

        public ICoreLogger CreateLogger(Type loggingContext)
        {
            var logger = _factory.CreateLogger(loggingContext);
            return new CoreLogger(logger);
        }
    }
}