using System;
using Xunit;
using SimpleAPI.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAPI.Test
{
    public class UnitTest1
    {

        [Fact]
        public void Get_ReturnWeatherList_5Item()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert   
            Assert.Equal(5, result.Count());

        }


        [Fact]
        public void Get_ReturnWeatherList_ContainsSummeriesElements()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

            // Act
            var result = controller.Get().Select(item => item.Summary);

            // Assert

            foreach (var item in result)
            {
                Assert.Contains<string>(item, controller.Summaries);
            }

        }
    }
}
