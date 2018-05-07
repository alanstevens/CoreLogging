using System;
using CoreLoggingAbstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using NSubstitute;
using Xunit;

namespace CoreLoggingAbstractionsTests
{
    public class CoreLoggerTests
    {
        public CoreLoggerTests()
        {
            _logger = Substitute.For<ILogger>();

            _coreLogger = new CoreLogger(_logger);
        }

        readonly CoreLogger _coreLogger;
        readonly ILogger _logger;
        readonly string _message = "message";
        readonly Exception _exception = new Exception();

        void Validate(LogLevel logLevel, Exception exception = null)
        {
            // NOTE: I can't find a way to validate message or args.
            _logger.Received().Log(logLevel, 0, Arg.Any<FormattedLogValues>(), exception, Arg.Any<Func<FormattedLogValues, Exception, string>>());
        }

        [Fact]
        public void should_call_logdebug()
        {
            _coreLogger.LogDebug(_message);
            Validate(LogLevel.Debug);
        }

        [Fact]
        public void should_call_logdebug_with_exception()
        {
            _coreLogger.LogDebug(_exception, _message);
            Validate(LogLevel.Debug, _exception);
        }

        [Fact]
        public void should_call_Trace()
        {
            _coreLogger.LogTrace(_message);
            Validate(LogLevel.Trace);
        }

        [Fact]
        public void should_call_logtrace_with_exception()
        {
            _coreLogger.LogTrace(_exception, _message);
            Validate(LogLevel.Trace, _exception);
        }

        [Fact]
        public void should_call_logInformation()
        {
            _coreLogger.LogInformation(_message);
            Validate(LogLevel.Information);
        }

        [Fact]
        public void should_call_logInformation_with_exception()
        {
            _coreLogger.LogInformation(_exception, _message);
            Validate(LogLevel.Information, _exception);
        }

        [Fact]
        public void should_call_logwarning()
        {
            _coreLogger.LogWarning(_message);
            Validate(LogLevel.Warning);
        }

        [Fact]
        public void should_call_logwarning_with_exception()
        {
            _coreLogger.LogWarning(_exception, _message);
            Validate(LogLevel.Warning, _exception);
        }

        [Fact]
        public void should_call_logerror()
        {
            _coreLogger.LogError(_message);
            Validate(LogLevel.Error);
        }

        [Fact]
        public void should_call_logerror_with_exception()
        {
            _coreLogger.LogError(_exception, _message);
            Validate(LogLevel.Error, _exception);
        }

        [Fact]
        public void should_call_logcritical()
        {
            _coreLogger.LogCritical(_message);
            Validate(LogLevel.Critical);
        }

        [Fact]
        public void should_call_logcritical_with_exception()
        {
            _coreLogger.LogCritical(_exception, _message);
            Validate(LogLevel.Critical, _exception);
        }
    }
}