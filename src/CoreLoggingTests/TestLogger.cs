namespace CoreLoggingTests
{
    using System;
    using Microsoft.Extensions.Logging;
    using Shouldly;

    internal class TestLogger : ILogger
    {
        LogLevel _logLevel;
        EventId _eventId;
        Exception _exception;
        string _message;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logLevel = logLevel;
            _eventId = eventId;
            _exception = exception;
            _message = formatter(state, exception);
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
            _logLevel.ShouldBe(logLevel);
            _message.ShouldBe(message);
            _exception.ShouldBe(exception);
            _eventId.ShouldBe(eventId);
        }
    }

    internal class TestLoggerFactory : ILoggerFactory
    {
        readonly ILogger _logger;

        public TestLoggerFactory(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }

        public void Dispose() { }

        public void AddProvider(ILoggerProvider provider) { }
    }
}