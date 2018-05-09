using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using Microsoft.Extensions.Logging.Internal;

namespace CoreLogging
{
    public class CoreLogger<T> : CoreLogger, ICoreLogger<T>
    {
        public CoreLogger(ILoggerFactory factory) 
            : base(factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)))) { }
    }

    public class CoreLogger : ICoreLogger
    {
        public CoreLogger(ILogger logger)
        {
            _logger = logger;
        }

        readonly ILogger _logger;

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

        void Log(LogLevel logLevel, string message, Exception exception, object[] args)
        {
            string MessageFormatter(object state, Exception error) => state.ToString();

            _logger.Log(logLevel, 0, new FormattedLogValues(message, args), exception, MessageFormatter);
        }
    }
}