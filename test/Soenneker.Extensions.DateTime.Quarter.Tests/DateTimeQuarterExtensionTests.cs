using AwesomeAssertions;
using Soenneker.Tests.Unit;
using System;
using Xunit;

namespace Soenneker.Extensions.DateTime.Quarter.Tests;

public class DateTimeQuarterExtensionTests : UnitTest
{
    [Theory]
    [InlineData("2023-01-15", "2023-01-01")]
    [InlineData("2023-04-01", "2023-04-01")]
    [InlineData("2023-12-31", "2023-10-01")]
    public void ToStartOfQuarter_Should_CorrectlyCalculateStartOfQuarter(string inputDate, string expectedDate)
    {
        // Arrange
        System.DateTime dateTime = System.DateTime.Parse(inputDate);

        // Act
        System.DateTime result = DateTimeQuarterExtension.ToStartOfQuarter(dateTime);

        // Assert
        result.Should().Be(System.DateTime.Parse(expectedDate));
    }

    [Theory]
    [InlineData("2023-01-15", "2023-03-31 23:59:59.9999999")]
    [InlineData("2023-04-01", "2023-06-30 23:59:59.9999999")]
    [InlineData("2023-12-31", "2023-12-31 23:59:59.9999999")]
    public void ToEndOfQuarter_Should_CorrectlyCalculateEndOfQuarter(string inputDate, string expectedDateString)
    {
        // Arrange
        System.DateTime dateTime = System.DateTime.Parse(inputDate);
        System.DateTime expectedDate = System.DateTime.ParseExact(expectedDateString, "yyyy-MM-dd HH:mm:ss.fffffff", null);

        // Act
        System.DateTime result = DateTimeQuarterExtension.ToEndOfQuarter(dateTime);

        // Assert
        result.Should().BeCloseTo(expectedDate, TimeSpan.FromMilliseconds(1));
    }
}
