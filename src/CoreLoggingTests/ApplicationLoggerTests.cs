using System;
using CoreLogging;
using CoreLogging.Extensions;
using NSubstitute;
using Xunit;

namespace CoreLoggingTests
{
    public class ApplicationLoggerTests
    {
        public ApplicationLoggerTests()
        {
            var factory = Substitute.For<ICoreLoggerFactory>();
            _logger = Substitute.For<ICoreLogger>();
            factory.CreateLogger(GetType()).Returns(_logger);

            ApplicationLogger.Initialize(factory);
        }

        readonly ICoreLogger _logger;
        readonly string _message = "message";
        readonly Exception _exception = new Exception();

        //------------------------------------------ApplicationLogger------------------------------------------//

        [Fact]
        public void should_call_logdebug()
        {
            ApplicationLogger.LogDebug(this, _message);
            _logger.Received().LogDebug(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug_with_exception()
        {
            ApplicationLogger.LogDebug(this, _exception, _message);
            _logger.Received().LogDebug(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace()
        {
            ApplicationLogger.LogTrace(this, _message);
            _logger.Received().LogTrace(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace_with_exception()
        {
            ApplicationLogger.LogTrace(this, _exception, _message);
            _logger.Received().LogTrace(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation()
        {
            ApplicationLogger.LogInformation(this, _message);
            _logger.Received().LogInformation(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation_with_exception()
        {
            ApplicationLogger.LogInformation(this, _exception, _message);
            _logger.Received().LogInformation(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning()
        {
            ApplicationLogger.LogWarning(this, _message);
            _logger.Received().LogWarning(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning_with_exception()
        {
            ApplicationLogger.LogWarning(this, _exception, _message);
            _logger.Received().LogWarning(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror()
        {
            ApplicationLogger.LogError(this, _message);
            _logger.Received().LogError(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror_with_exception()
        {
            ApplicationLogger.LogError(this, _exception, _message);
            _logger.Received().LogError(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logcritical()
        {
            ApplicationLogger.LogCritical(this, _message);
            _logger.Received().LogCritical(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logcritical_with_exception()
        {
            ApplicationLogger.LogCritical(this, _exception, _message);
            _logger.Received().LogCritical(_exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------ApplicationLogger Extensions------------------------------------------//

        [Fact]
        public void should_call_logcritical_extension()
        {
            this.LogCritical(_message);
            _logger.Received().LogCritical(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logcritical_with_exception_extension()
        {
            this.LogCritical(_exception, _message);
            _logger.Received().LogCritical(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug_extension()
        {
            this.LogDebug(_message);
            _logger.Received().LogDebug(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug_with_exception_extension()
        {
            this.LogDebug(_exception, _message);
            _logger.Received().LogDebug(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror_extension()
        {
            this.LogError(_message);
            _logger.Received().LogError(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror_with_exception_extension()
        {
            this.LogError(_exception, _message);
            _logger.Received().LogError(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation_extension()
        {
            this.LogInformation(_message);
            _logger.Received().LogInformation(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation_with_exception_extension()
        {
            this.LogInformation(_exception, _message);
            _logger.Received().LogInformation(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace_extension()
        {
            this.LogTrace(_message);
            _logger.Received().LogTrace(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace_with_exception_extension()
        {
            this.LogTrace(_exception, _message);
            _logger.Received().LogTrace(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning_extension()
        {
            this.LogWarning(_message);
            _logger.Received().LogWarning(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning_with_exception_extension()
        {
            this.LogWarning(_exception, _message);
            _logger.Received().LogWarning(_exception, _message, Arg.Any<object[]>());
        }
    }
}