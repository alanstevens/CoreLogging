namespace CoreLoggingTests
{
    using System;
    using CoreLogging;
    using CoreLogging.Extensions;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class CoreLoggerExtensionsTests
    {
        public CoreLoggerExtensionsTests()
        {
            var factory = new TestLoggerFactory(_testLogger);

            ApplicationLogger.Initialize(factory);
        }

        readonly string _message = "message";
        readonly Exception _exception = new Exception();
        readonly TestLogger _testLogger = new TestLogger();

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void should_call_logdebug_extension()
        {
            this.LogDebug(_message);
            _testLogger.Validate(LogLevel.Debug, _message);
        }

        [Fact]
        public void should_call_logdebug_with_exception_extension()
        {
            this.LogDebug(_message, _exception);
            _testLogger.Validate(LogLevel.Debug, _message, _exception);
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void should_call_logtrace_extension()
        {
            this.LogTrace(_message);
            _testLogger.Validate(LogLevel.Trace, _message);
        }

        [Fact]
        public void should_call_logtrace_with_exception_extension()
        {
            this.LogTrace(_message, _exception);
            _testLogger.Validate(LogLevel.Trace, _message, _exception);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void should_call_loginformation_extension()
        {
            this.LogInformation(_message);
            _testLogger.Validate(LogLevel.Information, _message);
        }

        [Fact]
        public void should_call_loginformation_with_exception_extension()
        {
            this.LogInformation(_message, _exception);
            _testLogger.Validate(LogLevel.Information, _message, _exception);
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void should_call_logwarning_extension()
        {
            this.LogWarning(_message);
            _testLogger.Validate(LogLevel.Warning, _message);
        }

        [Fact]
        public void should_call_logwarning_with_exception_extension()
        {
            this.LogWarning(_message, _exception);
            _testLogger.Validate(LogLevel.Warning, _message, _exception);
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void should_call_logerror_extension()
        {
            this.LogError(_message);
            _testLogger.Validate(LogLevel.Error, _message);
        }

        [Fact]
        public void should_call_logerror_with_exception_extension()
        {
            this.LogError(_message, _exception);
            _testLogger.Validate(LogLevel.Error, _message, _exception);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void should_call_logcritical_extension()
        {
            this.LogCritical(_message);
            _testLogger.Validate(LogLevel.Critical, _message);
        }

        [Fact]
        public void should_call_logcritical_with_exception_extension()
        {
            this.LogCritical(_message, _exception);
            _testLogger.Validate(LogLevel.Critical, _message, _exception);
        }
    }
}