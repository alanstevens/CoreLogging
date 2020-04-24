namespace CoreLoggingTests
{
    using System;
    using CoreLogging;
    using Microsoft.Extensions.Logging;
    using Shouldly;
    using NSubstitute;
    using Xunit;

    public class CoreLoggerFactoryTests
    {
        private ILoggerFactory _factory;
        private CoreLoggerFactory _factoryCore;

        public CoreLoggerFactoryTests()
        {
            _factory = Substitute.For<ILoggerFactory>();
            _factoryCore = new CoreLoggerFactory(_factory);
        }

        [Fact]
        public void Should_create_corelogger()
        {
            var loggingCategory = new Guid();

            var loggingCategoryName = TypeNameHelper.GetTypeDisplayName(loggingCategory);

            var logger = _factoryCore.CreateLogger(loggingCategory);

            logger.GetType().ShouldBe(typeof(CoreLogger));

            _factory.Received().CreateLogger(loggingCategoryName);
        }

        [Fact]
        public void Should_create_coreloggerT()
        {
            var loggerT = _factoryCore.CreateLogger<Guid>();

            loggerT.GetType().ShouldBe(typeof(CoreLogger<Guid>));

            var loggingCategoryName = TypeNameHelper.GetTypeDisplayName(typeof(Guid));

            _factory.Received().CreateLogger(loggingCategoryName);
        }
    }
}