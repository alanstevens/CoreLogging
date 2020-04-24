namespace CoreLoggingTests
{
    using System;
    using CoreLogging;
    using CoreLogging.Extensions;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using Xunit;

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

        //------------------------------------ApplicationLogger------------------------------------//

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void should_call_logdebug()
        {
            ApplicationLogger.LogDebug(this, _message);
            _logger.Received().Log(LogLevel.Debug, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug_with_exception()
        {
            ApplicationLogger.LogDebug(this, _message, _exception);
            _logger.Received().Log(LogLevel.Debug, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void should_call_logtrace()
        {
            ApplicationLogger.LogTrace(this, _message);
            _logger.Received().Log(LogLevel.Trace, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace_with_exception()
        {
            ApplicationLogger.LogTrace(this, _message, _exception);
            _logger.Received().Log(LogLevel.Trace, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void should_call_loginformation()
        {
            ApplicationLogger.LogInformation(this, _message);
            _logger.Received().Log(LogLevel.Information, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation_with_exception()
        {
            ApplicationLogger.LogInformation(this, _message, _exception);
            _logger.Received().Log(LogLevel.Information, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void should_call_logwarning()
        {
            ApplicationLogger.LogWarning(this, _message);
            _logger.Received().Log(LogLevel.Warning, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning_with_exception()
        {
            ApplicationLogger.LogWarning(this, _message, _exception);
            _logger.Received().Log(LogLevel.Warning, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void should_call_logerror()
        {
            ApplicationLogger.LogError(this, _message);
            _logger.Received().Log(LogLevel.Error, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror_with_exception()
        {
            ApplicationLogger.LogError(this, _message, _exception);
            _logger.Received().Log(LogLevel.Error, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void should_call_logcritical()
        {
            ApplicationLogger.LogCritical(this, _message);
            _logger.Received().Log(LogLevel.Critical, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logcritical_with_exception()
        {
            ApplicationLogger.LogCritical(this, _message, _exception);
            _logger.Received().Log(LogLevel.Critical, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //----------------------------------CoreLoggerExtensions-----------------------------------//

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void should_call_logdebug_extension()
        {
            this.LogDebug(_message);
            _logger.Received().Log(LogLevel.Debug, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logdebug_with_exception_extension()
        {
            this.LogDebug(_message, _exception);
            _logger.Received().Log(LogLevel.Debug, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void should_call_logtrace_extension()
        {
            this.LogTrace(_message);
            _logger.Received().Log(LogLevel.Trace, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logtrace_with_exception_extension()
        {
            this.LogTrace(_message, _exception);
            _logger.Received().Log(LogLevel.Trace, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void should_call_loginformation_extension()
        {
            this.LogInformation(_message);
            _logger.Received().Log(LogLevel.Information, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_loginformation_with_exception_extension()
        {
            this.LogInformation(_message, _exception);
            _logger.Received().Log(LogLevel.Information, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void should_call_logwarning_extension()
        {
            this.LogWarning(_message);
            _logger.Received().Log(LogLevel.Warning, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logwarning_with_exception_extension()
        {
            this.LogWarning(_message, _exception);
            _logger.Received().Log(LogLevel.Warning, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void should_call_logerror_extension()
        {
            this.LogError(_message);
            _logger.Received().Log(LogLevel.Error, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logerror_with_exception_extension()
        {
            this.LogError(_message, _exception);
            _logger.Received().Log(LogLevel.Error, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void should_call_logcritical_extension()
        {
            this.LogCritical(_message);
            _logger.Received().Log(LogLevel.Critical, Arg.Any<EventId>(), null, _message, Arg.Any<object[]>());
        }

        [Fact]
        public void should_call_logcritical_with_exception_extension()
        {
            this.LogCritical(_message, _exception);
            _logger.Received().Log(LogLevel.Critical, Arg.Any<EventId>(), _exception, _message, Arg.Any<object[]>());
        }

    }
}