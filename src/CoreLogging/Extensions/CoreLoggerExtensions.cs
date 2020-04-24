namespace CoreLogging.Extensions
{
    using System;

    public static class CoreLoggerExtensions
    {
        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.LogDebug(loggingCategory, message, exception, default, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.LogTrace(loggingCategory, message, exception, default, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.LogInformation(loggingCategory, message, exception, default, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.LogWarning(loggingCategory, message, exception, default, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.LogError(loggingCategory, message, exception, default, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.LogCritical(loggingCategory, message, exception, default, args);
        }
    }
}