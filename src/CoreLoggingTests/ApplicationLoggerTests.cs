namespace CoreLoggingTests
{
    using System;
    using CoreLogging;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class ApplicationLoggerTests
    {
        public ApplicationLoggerTests()
        {
            var factory = new TestLoggerFactory(_testLogger);

            ApplicationLogger.Initialize(factory);
        }

        readonly string _message = "message";
        readonly Exception _exception = new Exception();
        readonly TestLogger _testLogger = new TestLogger();

        //------------------------------------------LOG------------------------------------------//

        [Fact]
        public void should_call_log()
        {
            ApplicationLogger.Log(this, LogLevel.Debug, default, null, _message);
            _testLogger.Validate(LogLevel.Debug, _message);
        }

        [Fact]
        public void should_call_log_with_exception()
        {
            ApplicationLogger.Log(this, LogLevel.Critical, default, _exception, _message);
            _testLogger.Validate(LogLevel.Critical, _message, _exception);
        }

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void should_call_logdebug()
        {
            ApplicationLogger.LogDebug(this, _message);
            _testLogger.Validate(LogLevel.Debug, _message);
        }

        [Fact]
        public void should_call_logdebug_with_exception()
        {
            ApplicationLogger.LogDebug(this, _message, _exception);
            _testLogger.Validate(LogLevel.Debug, _message, _exception);
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void should_call_logtrace()
        {
            ApplicationLogger.LogTrace(this, _message);
            _testLogger.Validate(LogLevel.Trace, _message);
        }

        [Fact]
        public void should_call_logtrace_with_exception()
        {
            ApplicationLogger.LogTrace(this, _message, _exception);
            _testLogger.Validate(LogLevel.Trace, _message, _exception);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void should_call_loginformation()
        {
            ApplicationLogger.LogInformation(this, _message);
            _testLogger.Validate(LogLevel.Information, _message);
        }

        [Fact]
        public void should_call_loginformation_with_exception()
        {
            ApplicationLogger.LogInformation(this, _message, _exception);
            _testLogger.Validate(LogLevel.Information, _message, _exception);
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void should_call_logwarning()
        {
            ApplicationLogger.LogWarning(this, _message);
            _testLogger.Validate(LogLevel.Warning, _message);
        }

        [Fact]
        public void should_call_logwarning_with_exception()
        {
            ApplicationLogger.LogWarning(this, _message, _exception);
            _testLogger.Validate(LogLevel.Warning, _message, _exception);
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void should_call_logerror()
        {
            ApplicationLogger.LogError(this, _message);
            _testLogger.Validate(LogLevel.Error, _message);
        }

        [Fact]
        public void should_call_logerror_with_exception()
        {
            ApplicationLogger.LogError(this, _message, _exception);
            _testLogger.Validate(LogLevel.Error, _message, _exception);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void should_call_logcritical()
        {
            ApplicationLogger.LogCritical(this, _message);
            _testLogger.Validate(LogLevel.Critical, _message);
        }

        [Fact]
        public void should_call_logcritical_with_exception()
        {
            ApplicationLogger.LogCritical(this, _message, _exception);
            _testLogger.Validate(LogLevel.Critical, _message, _exception);
        }
    }
}