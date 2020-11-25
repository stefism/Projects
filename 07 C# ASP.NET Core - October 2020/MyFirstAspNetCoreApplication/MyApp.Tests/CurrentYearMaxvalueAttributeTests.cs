using MyFirstAspNetCoreApplication.ValidationAttributes;
using System;
using Xunit;

namespace MyApp.Tests
{
    public class CurrentYearMaxvalueAttributeTests
    {
        [Fact]
        public void IsValidReturnsFalseForYearAfterCurrenYear()
        {
            // Arange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1));

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsFalseForDateTimeAfterCurrenYear()
        {
            // Arange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1));

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsTrueForYearBeforeCurrenYear()
        {
            // Arange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(-1));

            // Assert
            Assert.True(isValid);
        }
    }
}
