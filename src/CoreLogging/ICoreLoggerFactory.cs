namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Logging;

    public interface ICoreLoggerFactory : ILoggerFactory
    {
        ICoreLogger<T> CreateLogger<T>();
        ICoreLogger CreateLogger(Type loggingCategory);
    }
}