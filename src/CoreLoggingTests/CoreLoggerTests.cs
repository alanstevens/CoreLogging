namespace CoreLoggingTests
{
    using System;
    using CoreLogging;
    using Microsoft.Extensions.Logging;
    using Shouldly;
    using Xunit;

    public class CoreLoggerTests
    {
        internal class TestLogger : ILogger
        {
            public LogLevel LogLevel { get; private set; }
            public EventId EventId { get; private set; }
            public Exception Exception { get; private set; }
            public string Message { get; private set; }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                LogLevel = logLevel;
                EventId = eventId;
                Exception = exception;
                Message = formatter(state, exception);
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                throw new NotImplementedException();
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                throw new NotImplementedException();
            }

            public void Validate(LogLevel logLevel, string message, Exception exception = null, EventId eventId = default)
            {
                this.LogLevel.ShouldBe(logLevel);
                this.Message.ShouldBe(message);
                this.Exception.ShouldBe(exception);
                this.EventId.ShouldBe(eventId);
            }
        }

        public CoreLoggerTests()
        {
            _logger = new TestLogger();
            _coreLogger = new CoreLogger(_logger);
        }

        private readonly CoreLogger _coreLogger;
        private readonly TestLogger _logger;
        private readonly string _message = "message";
        private readonly Exception _exception = new Exception();
        private readonly EventId _eventId = new EventId(5,"my event");

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void should_call_logdebug()
        {
            _coreLogger.LogDebug(_message);
            _logger.Validate(LogLevel.Debug, _message);
        }

        [Fact]
        public void should_call_logdebug_with_exception()
        {
            _coreLogger.LogDebug(_exception, _message);
            _logger.Validate(LogLevel.Debug, _message, _exception);
        }

        [Fact]
        public void should_call_logdebug_with_eventid()
        {
            _coreLogger.LogDebug(_eventId, _message);
            _logger.Validate(LogLevel.Debug, _message, null, _eventId);
        }

        [Fact]
        public void should_call_logdebug_with_exception_and_eventid()
        {
            _coreLogger.LogDebug(_eventId, _exception, _message);
            _logger.Validate(LogLevel.Debug, _message, _exception, _eventId);
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void should_call_Trace()
        {
            _coreLogger.LogTrace(_message);
            _logger.Validate(LogLevel.Trace, _message);
        }

        [Fact]
        public void should_call_logtrace_with_exception()
        {
            _coreLogger.LogTrace(_exception, _message);
            _logger.Validate(LogLevel.Trace, _message, _exception);
        }

        [Fact]
        public void should_call_logtrace_with_eventid()
        {
            _coreLogger.LogTrace(_eventId, _message);
            _logger.Validate(LogLevel.Trace, _message, null, _eventId);
        }

        [Fact]
        public void should_call_logtrace_with_exception_and_eventid()
        {
            _coreLogger.LogTrace(_eventId, _exception, _message);
            _logger.Validate(LogLevel.Trace, _message, _exception, _eventId);
        }

        //-----------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void should_call_logInformation()
        {
            _coreLogger.LogInformation(_message);
            _logger.Validate(LogLevel.Information, _message);
        }

        [Fact]
        public void should_call_logInformation_with_exception()
        {
            _coreLogger.LogInformation(_exception, _message);
            _logger.Validate(LogLevel.Information, _message, _exception);
        }

        [Fact]
        public void should_call_logInformation_with_eventid()
        {
            _coreLogger.LogInformation(_eventId, _message);
            _logger.Validate(LogLevel.Information, _message, null, _eventId);
        }

        [Fact]
        public void should_call_logInformation_with_exception_and_eventid()
        {
            _coreLogger.LogInformation(_eventId, _exception, _message);
            _logger.Validate(LogLevel.Information, _message, _exception, _eventId);
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void should_call_logwarning()
        {
            _coreLogger.LogWarning(_message);
            _logger.Validate(LogLevel.Warning, _message);
        }

        [Fact]
        public void should_call_logwarning_with_exception()
        {
            _coreLogger.LogWarning(_exception, _message);
            _logger.Validate(LogLevel.Warning, _message, _exception);
        }

        [Fact]
        public void should_call_logWarning_with_eventid()
        {
            _coreLogger.LogWarning(_eventId, _message);
            _logger.Validate(LogLevel.Warning, _message, null, _eventId);
        }

        [Fact]
        public void should_call_logWarning_with_exception_and_eventid()
        {
            _coreLogger.LogWarning(_eventId, _exception, _message);
            _logger.Validate(LogLevel.Warning, _message, _exception, _eventId);
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void should_call_logerror()
        {
            _coreLogger.LogError(_message);
            _logger.Validate(LogLevel.Error, _message);
        }

        [Fact]
        public void should_call_logerror_with_exception()
        {
            _coreLogger.LogError(_exception, _message, _message);
            _logger.Validate(LogLevel.Error, _message, _exception);
        }

        [Fact]
        public void should_call_logError_with_eventid()
        {
            _coreLogger.LogError(_eventId, _message);
            _logger.Validate(LogLevel.Error, _message, null, _eventId);
        }

        [Fact]
        public void should_call_logError_with_exception_and_eventid()
        {
            _coreLogger.LogError(_eventId, _exception, _message);
            _logger.Validate(LogLevel.Error, _message, _exception, _eventId);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void should_call_logcritical()
        {
            _coreLogger.LogCritical(_message);
            _logger.Validate(LogLevel.Critical, _message);
        }

        [Fact]
        public void should_call_logcritical_with_exception()
        {
            _coreLogger.LogCritical(_exception, _message);
            _logger.Validate(LogLevel.Critical, _message, _exception);
        }

        [Fact]
        public void should_call_logCritical_with_eventid()
        {
            _coreLogger.LogCritical(_eventId, _message);
            _logger.Validate(LogLevel.Critical, _message, null, _eventId);
        }

        [Fact]
        public void should_call_logCritical_with_exception_and_eventid()
        {
            _coreLogger.LogCritical(_eventId, _exception, _message);
            _logger.Validate(LogLevel.Critical, _message, _exception, _eventId);
        }
    }
}