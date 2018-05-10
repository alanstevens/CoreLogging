using System;

namespace CoreLogging.Extensions
{
    public static class ApplicationLoggerExtensions
    {
        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(this object loggingCategory, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogDebug(loggingCategory, exception, message, args);
        }

        public static void LogDebug(this object loggingCategory, string message, params object[] args)
        {
            ApplicationLogger.LogDebug(loggingCategory, null, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(this object loggingCategory, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogTrace(loggingCategory, exception, message, args);
        }

        public static void LogTrace(this object loggingCategory, string message, params object[] args)
        {
            ApplicationLogger.LogTrace(loggingCategory, null, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(this object loggingCategory, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogInformation(loggingCategory, exception, message, args);
        }

        public static void LogInformation(this object loggingCategory, string message, params object[] args)
        {
            ApplicationLogger.LogInformation(loggingCategory, null, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(this object loggingCategory, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogWarning(loggingCategory, exception, message, args);
        }

        public static void LogWarning(this object loggingCategory, string message, params object[] args)
        {
            ApplicationLogger.LogWarning(loggingCategory, null, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(this object loggingCategory, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogError(loggingCategory, exception, message, args);
        }

        public static void LogError(this object loggingCategory, string message, params object[] args)
        {
            ApplicationLogger.LogError(loggingCategory, null, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(this object loggingCategory, Exception exception, string message, params object[] args)
        {
            ApplicationLogger.LogCritical(loggingCategory, exception, message, args);
        }

        public static void LogCritical(this object loggingCategory, string message, params object[] args)
        {
            ApplicationLogger.LogCritical(loggingCategory, null, message, args);
        }
    }
}