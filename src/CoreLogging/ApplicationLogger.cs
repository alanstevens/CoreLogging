namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class ApplicationLogger
    {
        static Action<object, Exception, string, object[]> Debug = (loggingCategory, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Trace = (loggingCategory, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Information = (loggingCategory, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Warning = (loggingCategory, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Error = (loggingCategory, exception, message, args) => { };
        static Action<object, Exception, string, object[]> Critical = (loggingCategory, exception, message, args) => { };

        static ICoreLoggerFactory _factory;

        public static void Initialize(ILoggerFactory factory)
        {
            Initialize(new CoreLoggerFactory(factory));
        }

        public static void Initialize(ICoreLoggerFactory factory)
        {
            if (factory is null) throw new ArgumentNullException(nameof(factory));
            _factory = factory;

            Debug = LogDebugInternal;
            Trace = LogTraceInternal;
            Information = LogInformationInternal;
            Warning = LogWarningInternal;
            Error = LogErrorInternal;
            Critical = LogCriticalInternal;
        }

        static ICoreLogger CreateLogger(object loggingCategory)
        {
            if (_factory is null) throw new ArgumentNullException(nameof(_factory));
            var categoryType = GetCategoryType(loggingCategory);
            return _factory.CreateLogger(categoryType);
        }

        static Type GetCategoryType(object source)
        {
            var sourceType = source.GetType();
            if (sourceType == typeof(Type)) return source as Type;
            return sourceType;
        }

        static void LogDebugInternal(object loggingCategory, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).LogDebug(exception, message, args);
        }

        static void LogTraceInternal(object loggingCategory, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).LogTrace(exception, message, args);
        }

        static void LogInformationInternal(object loggingCategory, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).LogInformation(exception, message, args);
        }

        static void LogWarningInternal(object loggingCategory, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).LogWarning(exception, message, args);
        }

        static void LogErrorInternal(object loggingCategory, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).LogError(exception, message, args);
        }

        static void LogCriticalInternal(object loggingCategory, Exception exception, string message, params object[] args)
        {
            CreateLogger(loggingCategory).LogCritical(exception, message, args);
        }

        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(object loggingCategory, Exception exception, string message, params object[] args)
        {
            Debug(loggingCategory, exception, message, args);
        }

        public static void LogDebug(object loggingCategory, string message, params object[] args)
        {
            Debug(loggingCategory, null, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(object loggingCategory, Exception exception, string message, params object[] args)
        {
            Trace(loggingCategory, exception, message, args);
        }

        public static void LogTrace(object loggingCategory, string message, params object[] args)
        {
            Trace(loggingCategory, null, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(object loggingCategory, Exception exception, string message, params object[] args)
        {
            Information(loggingCategory, exception, message, args);
        }

        public static void LogInformation(object loggingCategory, string message, params object[] args)
        {
            Information(loggingCategory, null, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(object loggingCategory, Exception exception, string message, params object[] args)
        {
            Warning(loggingCategory, exception, message, args);
        }

        public static void LogWarning(object loggingCategory, string message, params object[] args)
        {
            Warning(loggingCategory, null, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(object loggingCategory, Exception exception, string message, params object[] args)
        {
            Error(loggingCategory, exception, message, args);
        }

        public static void LogError(object loggingCategory, string message, params object[] args)
        {
            Error(loggingCategory, null, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(object loggingCategory, Exception exception, string message, params object[] args)
        {
            Critical(loggingCategory, exception, message, args);
        }

        public static void LogCritical(object loggingCategory, string message, params object[] args)
        {
            Critical(loggingCategory, null, message, args);
        }
    }
}