namespace CoreLoggingTests
{
    using System;
    using Microsoft.Extensions.Logging;
    using Shouldly;

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
            LogLevel.ShouldBe(logLevel);
            Message.ShouldBe(message);
            Exception.ShouldBe(exception);
            EventId.ShouldBe(eventId);
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