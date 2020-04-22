namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Internal;
    using Microsoft.Extensions.Logging;

    public class CoreLogger<T> : CoreLogger, ICoreLogger<T>
    {
        public CoreLogger(ILoggerFactory factory)
            : base(factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)))) { }
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
            Log(LogLevel.Debug, eventId, message, args);
        }

        public void LogDebug(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Debug, exception, message, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            Log(LogLevel.Debug, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public void LogTrace(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Trace, eventId, exception, message, args);
        }

        public void LogTrace(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Trace, eventId, message, args);
        }

        public void LogTrace(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Trace, exception, message, args);
        }

        public void LogTrace(string message, params object[] args)
        {
            Log(LogLevel.Trace, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public void LogInformation(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Information, eventId, exception, message, args);
        }

        public void LogInformation(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Information, eventId, message, args);
        }

        public void LogInformation(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Information, exception, message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            Log(LogLevel.Information, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public void LogWarning(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Warning, eventId, exception, message, args);
        }

        public void LogWarning(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Warning, eventId, message, args);
        }

        public void LogWarning(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Warning, exception, message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            Log(LogLevel.Warning, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public void LogError(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Error, eventId, exception, message, args);
        }

        public void LogError(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Error, eventId, message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Error, exception, message, args);
        }

        public void LogError(string message, params object[] args)
        {
            Log(LogLevel.Error, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public void LogCritical(EventId eventId, Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Critical, eventId, exception, message, args);
        }

        public void LogCritical(EventId eventId, string message, params object[] args)
        {
            Log(LogLevel.Critical, eventId, message, args);
        }

        public void LogCritical(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Critical, exception, message, args);
        }

        public void LogCritical(string message, params object[] args)
        {
            Log(LogLevel.Critical, message, args);
        }
        //------------------------------------------LOG------------------------------------------//

        public void Log(LogLevel logLevel, string message, object[] args)
        {
            Log(logLevel, null, message, args);
        }

        public void Log(LogLevel logLevel, EventId eventId, string message,object[] args)
        {
            Log(logLevel, eventId, null, message, args);
        }

        public void Log(LogLevel logLevel, Exception exception, string message, object[] args)
        {
            Log(logLevel, 0, exception, message, args);
        }

        public void Log(LogLevel logLevel, EventId eventId, Exception exception, string message, object[] args)
        {
            string Formatter(FormattedLogValues state, Exception error) => state.ToString();

            var state = new FormattedLogValues(message, args);

            _logger.Log(logLevel, eventId, state, exception, Formatter);
        }

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