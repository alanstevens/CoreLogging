namespace CoreLogging
{
    using Microsoft.Extensions.Logging;

    public interface ICoreLoggerFactory : ILoggerFactory
    {
        ICoreLogger<T> CreateLogger<T>();
        ICoreLogger CreateLogger(object loggingCategory);
    }
}