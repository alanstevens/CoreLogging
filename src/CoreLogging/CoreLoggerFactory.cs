using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace CoreLogging
{
    public class CoreLoggerFactory : ICoreLoggerFactory
    {
        public CoreLoggerFactory(ILoggerFactory factory) => _factory = factory;

        readonly ILoggerFactory _factory;

        public ICoreLogger<T> CreateLogger<T>()
        {
            return new CoreLogger<T>(_factory);
        }

        public ICoreLogger CreateLogger(Type loggingCategory)
        {
            var CategoryName = TypeNameHelper.GetTypeDisplayName(loggingCategory);
            var logger = _factory.CreateLogger(CategoryName);
            return new CoreLogger(logger);
        }
    }
}