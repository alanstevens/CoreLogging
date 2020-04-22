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

        public void LogDebug(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Debug, message, exception, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            Log(LogLevel.Debug, message, null, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public void LogTrace(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Trace, message, exception, args);
        }

        public void LogTrace(string message, params object[] args)
        {
            Log(LogLevel.Trace, message, null, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public void LogInformation(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Information, message, exception, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            Log(LogLevel.Information, message, null, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public void LogWarning(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Warning, message, exception, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            Log(LogLevel.Warning, message, null, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public void LogError(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Error, message, exception, args);
        }

        public void LogError(string message, params object[] args)
        {
            Log(LogLevel.Error, message, null, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public void LogCritical(Exception exception, string message, params object[] args)
        {
            Log(LogLevel.Critical, message, exception, args);
        }

        public void LogCritical(string message, params object[] args)
        {
            Log(LogLevel.Critical, message, null, args);
        }

        //------------------------------------------LOG------------------------------------------//

        private void Log(LogLevel logLevel, string message, Exception exception, object[] args)
        {
            Log(logLevel, 0, message, exception, args);
        }

        private void Log(LogLevel logLevel, EventId eventId, string message, Exception exception, object[] args)
        {
            string Formatter(FormattedLogValues state, Exception error) => state.ToString();

            var state = new FormattedLogValues(message, args);

            //Log(logLevel, eventId, state, exception, Formatter); // Can't detect the right overload.
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