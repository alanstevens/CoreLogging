using System;

namespace CoreLoggingAbstractions
{
    public interface ICoreLoggerFactory
    {
        ICoreLogger<T> CreateLogger<T>();
        ICoreLogger CreateLogger(Type loggingContext);
    }
}