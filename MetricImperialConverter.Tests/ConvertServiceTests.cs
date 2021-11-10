using MetricImperialConverter.Common;
using MetricImperialConverter.Service;
using System;
using Xunit;

namespace MetricImperialConverter.Tests
{
    public class ConvertServiceTests : TestsServiceBase
    {
        public ConvertServiceTests()
        {
            SetUp().Wait();
        }

        [Fact]
        public async void GivenValidInputParameters_WhenConvert_ShouldNotThrowException()
        {
            // Arrange
            var _convertService = new ConvertService(_dbContext);
            var amountToConvert = 50.0;
            var conversionDirection = ConversionDirection.ImperialToMetric;
            var conversionType = ConversionType.Temperature;

            // Act
            var exception = await Record.ExceptionAsync(async () => await _convertService.ConvertAsync(amountToConvert, conversionDirection, conversionType));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(50.00, ConversionDirection.ImperialToMetric, ConversionType.Temperature, 10.000)]
        [InlineData(25.00, ConversionDirection.MetricToImperial, ConversionType.Temperature, 77.000)]
        [InlineData(5.50, ConversionDirection.ImperialToMetric, ConversionType.Mass, 155.922)]
        [InlineData(125.85, ConversionDirection.MetricToImperial, ConversionType.Mass, 4.439)]
        [InlineData(5.00, ConversionDirection.ImperialToMetric, ConversionType.Length, 1.524)]
        [InlineData(125.65, ConversionDirection.MetricToImperial, ConversionType.Length, 412.238)]
        public async void GivenValidInputParameters_WhenConvert_ShouldReturnConvertedAmount(double amountToConvert, ConversionDirection conversionDirection, ConversionType conversionType, double expectedResult)
        {
            // Arrange
            var _convertService = new ConvertService(_dbContext);

            // Act
            var result = await _convertService.ConvertAsync(amountToConvert, conversionDirection, conversionType);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void GivenInvalidConversionDirection_WhenConvert_ShouldThrowAnArgumentException()
        {
            // Arrange
            var _convertService = new ConvertService(_dbContext);
            var amountToConvert = 1.0;
            var conversionDirection = -1;
            var conversionType = ConversionType.Temperature;

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _convertService.ConvertAsync(amountToConvert, (ConversionDirection)conversionDirection, conversionType));
        }

        [Fact]
        public async void GivenInvalidConversionType_WhenConvert_ShouldThrowAnArgumentException()
        {
            // Arrange
            var _convertService = new ConvertService(_dbContext);
            var amountToConvert = 1.0;
            var conversionDirection = ConversionDirection.ImperialToMetric;
            var conversionType = -1;

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _convertService.ConvertAsync(amountToConvert, conversionDirection, (ConversionType)conversionType));
        }
    }
}
