namespace CoreLogging.Extensions
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class CoreLoggerExtensions
    {
        //------------------------------------------DEBUG------------------------------------------//

        public static void LogDebug(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.Log(loggingCategory, LogLevel.Debug, default, exception, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        public static void LogTrace(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.Log(loggingCategory, LogLevel.Trace, default, exception, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        public static void LogInformation(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.Log(loggingCategory, LogLevel.Information, default, exception, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        public static void LogWarning(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.Log(loggingCategory, LogLevel.Warning, default, exception, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void LogError(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.Log(loggingCategory, LogLevel.Error, default, exception, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        public static void LogCritical(this object loggingCategory, string message, Exception exception = null, params object[] args)
        {
            ApplicationLogger.Log(loggingCategory, LogLevel.Critical, default, exception, message, args);
        }
    }
}