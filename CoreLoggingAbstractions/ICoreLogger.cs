using System;

namespace CoreLoggingAbstractions
{
    public interface ICoreLogger
    {
        //------------------------------------------DEBUG------------------------------------------//

        void LogDebug(Exception exception, string message, params object[] args);

        void LogDebug(string message, params object[] args);

        //------------------------------------------TRACE------------------------------------------//

        void LogTrace(Exception exception, string message, params object[] args);

        void LogTrace(string message, params object[] args);

        //------------------------------------------INFORMATION------------------------------------------//

        void LogInformation(Exception exception, string message, params object[] args);

        void LogInformation(string message, params object[] args);

        //------------------------------------------WARNING------------------------------------------//

        void LogWarning(Exception exception, string message, params object[] args);

        void LogWarning(string message, params object[] args);

        //------------------------------------------ERROR------------------------------------------//

        void LogError(Exception exception, string message, params object[] args);

        void LogError(string message, params object[] args);

        //------------------------------------------CRITICAL------------------------------------------//

        void LogCritical(Exception exception, string message, params object[] args);

        void LogCritical(string message, params object[] args);
    }
}