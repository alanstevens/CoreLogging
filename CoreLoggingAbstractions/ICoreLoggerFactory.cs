using System;

namespace CoreLoggingAbstractions
{
    public interface ICoreLoggerFactory
    {
        ICoreLogger CreateLogger(Type loggingContext);
    }
}