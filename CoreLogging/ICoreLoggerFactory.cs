using System;

namespace CoreLogging
{
    public interface ICoreLoggerFactory
    {
        ICoreLogger<T> CreateLogger<T>();
        ICoreLogger CreateLogger(Type loggingContext);
    }
}