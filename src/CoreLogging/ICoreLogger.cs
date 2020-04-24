namespace CoreLogging
{
    using System;
    using Microsoft.Extensions.Logging;

    public interface ICoreLogger<T> : ICoreLogger, ILogger<T>
    {
    }

    public interface ICoreLogger : ILogger
    {
        //------------------------------------------DEBUG------------------------------------------//

        void LogDebug(EventId eventId, Exception exception, string message, params object[] args);

        void LogDebug(EventId eventId, string message, params object[] args);

        void LogDebug(Exception exception, string message, params object[] args);

        void LogDebug(string message, params object[] args);

        //------------------------------------------TRACE------------------------------------------//

        void LogTrace(EventId eventId, Exception exception, string message, params object[] args);

        void LogTrace(EventId eventId, string message, params object[] args);

        void LogTrace(Exception exception, string message, params object[] args);

        void LogTrace(string message, params object[] args);

        //------------------------------------------INFORMATION------------------------------------------//

        void LogInformation(EventId eventId, Exception exception, string message, params object[] args);

        void LogInformation(EventId eventId, string message, params object[] args);

        void LogInformation(Exception exception, string message, params object[] args);

        void LogInformation(string message, params object[] args);

        //------------------------------------------WARNING------------------------------------------//

        void LogWarning(EventId eventId, Exception exception, string message, params object[] args);

        void LogWarning(EventId eventId, string message, params object[] args);

        void LogWarning(Exception exception, string message, params object[] args);

        void LogWarning(string message, params object[] args);

        //------------------------------------------ERROR------------------------------------------//

        void LogError(EventId eventId, Exception exception, string message, params object[] args);

        void LogError(EventId eventId, string message, params object[] args);

        void LogError(Exception exception, string message, params object[] args);

        void LogError(string message, params object[] args);

        //------------------------------------------CRITICAL------------------------------------------//

        void LogCritical(EventId eventId, Exception exception, string message, params object[] args);

        void LogCritical(EventId eventId, string message, params object[] args);

        void LogCritical(Exception exception, string message, params object[] args);

        void LogCritical(string message, params object[] args);

        //---------------------------------------------LOG--------------------------------------------//

        void Log(LogLevel logLevel, EventId eventId, Exception exception, string message, object[] args);
    }
}