namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class ApplicationLogger
    {
        static Action<object, LogLevel, EventId, Exception, string, object[]> Log = (loggingCategory, logLevel, eventId, exception, message, args) => { };

        static ICoreLoggerFactory _factory;

        public static void Initialize(ILoggerFactory factory)
        {
            Initialize(new CoreLoggerFactory(factory));
        }

        public static void Initialize(ICoreLoggerFactory factory)
        {
            if (factory is null) throw new ArgumentNullException(nameof(factory));
            _factory = factory;

            Log = LogInternal;
        }

        static ICoreLogger CreateLogger(object loggingCategory)
        {
            if (_factory is null) throw new ArgumentNullException(nameof(_factory));

            return _factory.CreateLogger(loggingCategory);
        }

        static void LogInternal(object loggingCategory, LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).Log(logLevel, eventId, exception, message, args);
        }

        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(object loggingCategory, string message, Exception exception = null, EventId eventId = default, params object[] args)
        {
            Log(loggingCategory, LogLevel.Debug, eventId, exception, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(object loggingCategory, string message, Exception exception = null, EventId eventId = default, params object[] args)
        {
            Log(loggingCategory, LogLevel.Trace, eventId, exception, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(object loggingCategory, string message, Exception exception = null, EventId eventId = default, params object[] args)
        {
            Log(loggingCategory, LogLevel.Information, eventId, exception, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(object loggingCategory, string message, Exception exception = null, EventId eventId = default, params object[] args)
        {
            Log(loggingCategory, LogLevel.Warning, eventId, exception, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(object loggingCategory, string message, Exception exception = null, EventId eventId = default, params object[] args)
        {
            Log(loggingCategory, LogLevel.Error, eventId, exception, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(object loggingCategory, string message, Exception exception = null, EventId eventId = default, params object[] args)
        {
            Log(loggingCategory, LogLevel.Critical, eventId, exception, message, args);
        }
    }
}