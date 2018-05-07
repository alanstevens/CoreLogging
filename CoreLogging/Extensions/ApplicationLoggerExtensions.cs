using System;

namespace CoreLogging.Extensions
{
    public static class ApplicationLoggerExtensions
    {
        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(this object loggingContext, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogDebug(loggingContext, exception, message, args);
        }

        public static void LogDebug(this object loggingContext, string message, params object[] args)
        {
            ApplicationLogger.LogDebug(loggingContext, null, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(this object loggingContext, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogTrace(loggingContext, exception, message, args);
        }

        public static void LogTrace(this object loggingContext, string message, params object[] args)
        {
            ApplicationLogger.LogTrace(loggingContext, null, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(this object loggingContext, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogInformation(loggingContext, exception, message, args);
        }

        public static void LogInformation(this object loggingContext, string message, params object[] args)
        {
            ApplicationLogger.LogInformation(loggingContext, null, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(this object loggingContext, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogWarning(loggingContext, exception, message, args);
        }

        public static void LogWarning(this object loggingContext, string message, params object[] args)
        {
            ApplicationLogger.LogWarning(loggingContext, null, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(this object loggingContext, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogError(loggingContext, exception, message, args);
        }

        public static void LogError(this object loggingContext, string message, params object[] args)
        {
            ApplicationLogger.LogError(loggingContext, null, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(this object loggingContext, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogCritical(loggingContext, exception, message, args);
        }

        public static void LogCritical(this object loggingContext, string message, params object[] args)
        {
            ApplicationLogger.LogCritical(loggingContext, null, message, args);
        }
    }
}