using System;
using Microsoft.Extensions.Logging;

namespace CoreLoggingAbstractions
{
    public class CoreLoggerFactory : ICoreLoggerFactory
    {
        public CoreLoggerFactory(ILoggerFactory factory) => _factory = factory;

        readonly ILoggerFactory _factory;

        public ICoreLogger CreateLogger(Type loggingContext)
        {
            var logger = _factory.CreateLogger(loggingContext);
            return new CoreLogger(logger);
        }
    }
}