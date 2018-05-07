using System;
using CoreLogging;
using CoreLogging.Extensions;
using NSubstitute;
using Xunit;

namespace CoreLoggingTests
{
    public class ApplicationLoggerExtensionsTests
    {
        public ApplicationLoggerExtensionsTests()
        {
            var factory = Substitute.For<ICoreLoggerFactory>();
            _logger = Substitute.For<ICoreLogger>();
            factory.CreateLogger(GetType()).Returns(_logger);

            ApplicationLogger.Initialize(factory);
        }

        readonly ICoreLogger _logger;
        readonly string _message = "message";
        readonly Exception _exception = new Exception();

        [Fact]
        public void should_call_logcritical()
        {
            this.LogCritical(_message);
            _logger.Received().LogCritical(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logcritical_with_exception()
        {
            this.LogCritical(_exception, _message);
            _logger.Received().LogCritical(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug()
        {
            this.LogDebug(_message);
            _logger.Received().LogDebug(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug_with_exception()
        {
            this.LogDebug(_exception, _message);
            _logger.Received().LogDebug(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror()
        {
            this.LogError(_message);
            _logger.Received().LogError(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror_with_exception()
        {
            this.LogError(_exception, _message);
            _logger.Received().LogError(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation()
        {
            this.LogInformation(_message);
            _logger.Received().LogInformation(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation_with_exception()
        {
            this.LogInformation(_exception, _message);
            _logger.Received().LogInformation(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace()
        {
            this.LogTrace(_message);
            _logger.Received().LogTrace(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace_with_exception()
        {
            this.LogTrace(_exception, _message);
            _logger.Received().LogTrace(_exception, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning()
        {
            this.LogWarning(_message);
            _logger.Received().LogWarning(null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning_with_exception()
        {
            this.LogWarning(_exception, _message);
            _logger.Received().LogWarning(_exception, _message, Arg.Any<object[]>());
        }
    }
}