using Xunit;
using System;
using Microsoft.Extensions.Logging;
using ClientBuilder.KucoinBotClient.Extensions;

namespace ClientBuilder.Tests.KucoinBotClient.Extensions
{
    public class IntExtensionsTests
    {
        [Fact]
        public void GetSecondsInterval_InsertValidIntValue_GetTimeSpanFromSeconds()
        {
            //Arrange
            var value = 10;
            var controlValue = TimeSpan.FromSeconds(value);

            //Act
            var actual = value.GetSecondsInterval();

            //Assert
            Assert.Equal(controlValue, actual);
        }

        [Fact]
        public void GetEnum_InsertValidIntValue_GetValidLogLevel()
        {
            //Arrange
            var intValue = 1;
            var controlValue = LogLevel.Debug;

            //Act
            var actual = intValue.GetEnum<LogLevel>();

            //Assert
            Assert.Equal(controlValue, actual);
        }

        [Fact]
        public void GetEnum_InsertOutOfRangeValue_GetDefaultLogLevelValue()
        {
            //Arrange
            var intValue = 10;
            var controlValue = LogLevel.Trace;

            //Act
            var actual = intValue.GetEnum<LogLevel>();

            //Assert
            Assert.Equal(controlValue, actual);
        }
    }
}
