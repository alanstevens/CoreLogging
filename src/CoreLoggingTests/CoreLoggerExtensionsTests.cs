namespace CoreLoggingTests
{
    using System;
    using CoreLogging;
    using CoreLogging.Extensions;
    using Microsoft.Extensions.Logging;
    using Xunit;
    using Pose;

    public class CoreLoggerExtensionsTests
    {
        public CoreLoggerExtensionsTests()
        {
            _logShim = Shim.Replace(() =>
                    ApplicationLogger.Log(
                        Is.A<object>(),
                        Is.A<LogLevel>(),
                        Is.A<EventId>(),
                        Is.A<Exception>(),
                        Is.A<string>(),
                        Is.A<object[]>()))
                .With(delegate
                (
                    object loggingCategory,
                    LogLevel logLevel,
                    EventId eventId,
                    Exception exception,
                    string message,
                    object[] args
                )
                {
                    LoggerExtensions.Log(_testLogger, logLevel, eventId, exception, message, args);
                });
        }

        readonly string _message = "message";
        readonly Exception _exception = new Exception();
        readonly TestLogger _testLogger = new TestLogger();
        readonly Shim _logShim;

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void should_call_logdebug_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogDebug(_message);
            }, _logShim);
            _testLogger.Validate(LogLevel.Debug, _message);
        }

        [Fact]
        public void should_call_logdebug_with_exception_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogDebug(_message, _exception);
            }, _logShim);
           _testLogger.Validate(LogLevel.Debug, _message, _exception);
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void should_call_logtrace_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogTrace(_message);
            }, _logShim);
            _testLogger.Validate(LogLevel.Trace, _message);
        }

        [Fact]
        public void should_call_logtrace_with_exception_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogTrace(_message, _exception);
            }, _logShim);
            _testLogger.Validate(LogLevel.Trace, _message, _exception);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void should_call_loginformation_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogInformation(_message);
            }, _logShim);
            _testLogger.Validate(LogLevel.Information, _message);
        }

        [Fact]
        public void should_call_loginformation_with_exception_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogInformation(_message, _exception);
            }, _logShim);
            _testLogger.Validate(LogLevel.Information, _message, _exception);
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void should_call_logwarning_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogWarning(_message);
            }, _logShim);
            _testLogger.Validate(LogLevel.Warning, _message);
        }

        [Fact]
        public void should_call_logwarning_with_exception_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogWarning(_message, _exception);
            }, _logShim);
            _testLogger.Validate(LogLevel.Warning, _message, _exception);
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void should_call_logerror_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogError(_message);
            }, _logShim);
            _testLogger.Validate(LogLevel.Error, _message);
        }

        [Fact]
        public void should_call_logerror_with_exception_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogError(_message, _exception);
            }, _logShim);
            _testLogger.Validate(LogLevel.Error, _message, _exception);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void should_call_logcritical_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogCritical(_message);
            }, _logShim);
            _testLogger.Validate(LogLevel.Critical, _message);
        }

        [Fact]
        public void should_call_logcritical_with_exception_extension()
        {
            PoseContext.Isolate(() =>
            {
                this.LogCritical(_message, _exception);
            }, _logShim);
            _testLogger.Validate(LogLevel.Critical, _message, _exception);
        }
    }
}