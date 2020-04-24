namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Logging;

    public class CoreLogger<T> : CoreLogger, ICoreLogger<T>
    {
        public CoreLogger(ILoggerFactory factory)
            : base(factory.CreateLogger(typeof(T))) { }
    }

    public class CoreLogger : ICoreLogger
    {
        private readonly ILogger _logger;

        public CoreLogger(ILogger logger) => _logger = logger;

        //------------------------------------------DEBUG------------------------------------------//

        public void LogDebug(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Debug, eventId, exception, message, args);
        }

        public void LogDebug(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Debug, eventId, null, message, args);
        }

        public void LogDebug(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Debug, default, exception, message, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            Log(LogLevel.Debug, default,  null, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public void LogTrace(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Trace, eventId, exception, message, args);
        }

        public void LogTrace(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Trace, eventId, null, message, args);
        }

        public void LogTrace(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Trace, default, exception, message, args);
        }

        public void LogTrace(string message, params object[] args)
        {
            Log(LogLevel.Trace, default, null, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public void LogInformation(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Information, eventId, exception, message, args);
        }

        public void LogInformation(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Information, eventId, null, message, args);
        }

        public void LogInformation(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Information, default, exception, message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            Log(LogLevel.Information, default, null, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public void LogWarning(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Warning, eventId, exception, message, args);
        }

        public void LogWarning(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Warning, eventId, null, message, args);
        }

        public void LogWarning(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Warning, default, exception, message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            Log(LogLevel.Warning, default, null, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public void LogError(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Error, eventId, exception, message, args);
        }

        public void LogError(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Error, eventId, null, message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Error, default, exception, message, args);
        }

        public void LogError(string message, params object[] args)
        {
            Log(LogLevel.Error, default, null, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public void LogCritical(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Critical, eventId, exception, message, args);
        }

        public void LogCritical(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Critical, eventId, null, message, args);
        }

        public void LogCritical(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Critical, default, exception, message, args);
        }

        public void LogCritical(string message, params object[] args)
        {
            Log(LogLevel.Critical, default, null, message, args);
        }

        //------------------------------------------LOG------------------------------------------//

        public void Log(LogLevel logLevel, EventId eventId, Exception exception, string message, object[] args)
        {
            LoggerExtensions.Log(_logger, logLevel, eventId, exception, message, args);
        }

        //------------------------------------------ILogger------------------------------------------//

        void ILogger.Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        }

        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }
    }
}