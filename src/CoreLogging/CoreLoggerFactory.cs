using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace CoreLogging
{
    public class CoreLoggerFactory : ICoreLoggerFactory
    {
        public CoreLoggerFactory(ILoggerFactory factory) => _factory = factory;

        readonly ILoggerFactory _factory;

        public ICoreLogger<T> CreateLogger<T>() => new CoreLogger<T>(_factory);

        public ICoreLogger CreateLogger(Type loggingCategory)
        {
            var categoryName = TypeNameHelper.GetTypeDisplayName(loggingCategory);
            var logger = _factory.CreateLogger(categoryName);
            return new CoreLogger(logger);
        }
    }
}