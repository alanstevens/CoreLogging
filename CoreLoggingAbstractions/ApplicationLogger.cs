using System;
using Microsoft.Extensions.Logging;

namespace CoreLoggingAbstractions
{
    public static class ApplicationLogger
    {
        static Action<object, Exception, string, object[]> Debug = (loggingContext, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Trace = (loggingContext, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Information = (loggingContext, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Warning = (loggingContext, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Error = (loggingContext, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Critical = (loggingContext, exception, message, args) => { };

        static ICoreLoggerFactory _factory;

        public static void Initialize(ILoggerFactory factory)
        {
            Initialize(new CoreLoggerFactory(factory));
        }

        public static void Initialize(ICoreLoggerFactory factory)
        {
            _factory = factory;

            Debug = LogDebugInternal;
            Trace = LogTraceInternal;
            Information = LogInformationInternal;
            Warning = LogWarningInternal;
            Error = LogErrorInternal;
            Critical = LogCriticalInternal;
        }

        static ICoreLogger CreateLogger(object loggingContext)
        {
            var contextType = GetContextType(loggingContext);
            return _factory.CreateLogger(contextType);
        }

        static Type GetContextType(object source)
        {
            var sourceType = source.GetType();
            if (sourceType == typeof(Type)) return source as Type;
            return sourceType;
        }

        static void LogDebugInternal(object loggingContext, Exception exception, string message, params object[] args)
        {
            var logger = CreateLogger(loggingContext);
            logger.LogDebug(exception, message, args);
        }

        static void LogTraceInternal(object loggingContext, Exception exception, string message, params object[] args)
        {
            var logger = CreateLogger(loggingContext);
            logger.LogTrace(exception, message, args);
        }

        static void LogInformationInternal(object loggingContext, Exception exception, string message, params object[] args)
        {
            var logger = CreateLogger(loggingContext);
            logger.LogInformation(exception, message, args);
        }

        static void LogWarningInternal(object loggingContext, Exception exception, string message, params object[] args)
        {
            var logger = CreateLogger(loggingContext);
            logger.LogWarning(exception, message, args);
        }

        static void LogErrorInternal(object loggingContext, Exception exception, string message, params object[] args)
        {
            var logger = CreateLogger(loggingContext);
            logger.LogError(exception, message, args);
        }

        static void LogCriticalInternal(object loggingContext, Exception exception, string message, params object[] args)
        {
            var logger = CreateLogger(loggingContext);
            logger.LogCritical(exception, message, args);
        }

        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(object loggingContext, Exception exception, string message, params object[] args)
        {
            Debug(loggingContext, exception, message, args);
        }

        public static void LogDebug(object loggingContext, string message, params object[] args)
        {
            Debug(loggingContext, null, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(object loggingContext, Exception exception, string message, params object[] args)
        {
            Trace(loggingContext, exception, message, args);
        }

        public static void LogTrace(object loggingContext, string message, params object[] args)
        {
            Trace(loggingContext, null, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(object loggingContext, Exception exception, string message, params object[] args)
        {
            Information(loggingContext, exception, message, args);
        }

        public static void LogInformation(object loggingContext, string message, params object[] args)
        {
            Information(loggingContext, null, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(object loggingContext, Exception exception, string message, params object[] args)
        {
            Warning(loggingContext, exception, message, args);
        }

        public static void LogWarning(object loggingContext, string message, params object[] args)
        {
            Warning(loggingContext, null, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(object loggingContext, Exception exception, string message, params object[] args)
        {
            Error(loggingContext, exception, message, args);
        }

        public static void LogError(object loggingContext, string message, params object[] args)
        {
            Error(loggingContext, null, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(object loggingContext, Exception exception, string message, params object[] args)
        {
            Critical(loggingContext, exception, message, args);
        }

        public static void LogCritical(object loggingContext, string message, params object[] args)
        {
            Critical(loggingContext, null, message, args);
        }
    }
}