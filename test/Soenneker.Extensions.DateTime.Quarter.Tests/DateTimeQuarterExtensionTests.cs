using AwesomeAssertions;
using Soenneker.Tests.Unit;
using System;

namespace Soenneker.Extensions.DateTime.Quarter.Tests;

public class DateTimeQuarterExtensionTests : UnitTest
{
    [Test]
    public void Time_zone_quarter_boundaries_handle_year_rollover()
    {
        var value = new System.DateTime(2023, 11, 15, 12, 0, 0, DateTimeKind.Utc);

        System.DateTime nextStart = value.ToStartOfNextTzQuarter(TimeZoneInfo.Utc);
        System.DateTime previousEnd = value.ToEndOfPreviousTzQuarter(TimeZoneInfo.Utc);

        nextStart.Should().Be(new System.DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        previousEnd.Should().Be(new System.DateTime(2023, 9, 30, 23, 59, 59, DateTimeKind.Utc).AddTicks(9_999_999));
    }

    [Test]
    [Arguments("2023-01-15", "2023-01-01")]
    [Arguments("2023-04-01", "2023-04-01")]
    [Arguments("2023-12-31", "2023-10-01")]
    public void ToStartOfQuarter_Should_CorrectlyCalculateStartOfQuarter(string inputDate, string expectedDate)
    {
        // Arrange
        System.DateTime dateTime = System.DateTime.Parse(inputDate);

        // Act
        System.DateTime result = DateTimeQuarterExtension.ToStartOfQuarter(dateTime);

        // Assert
        result.Should().Be(System.DateTime.Parse(expectedDate));
    }

    [Test]
    [Arguments("2023-01-15", "2023-03-31 23:59:59.9999999")]
    [Arguments("2023-04-01", "2023-06-30 23:59:59.9999999")]
    [Arguments("2023-12-31", "2023-12-31 23:59:59.9999999")]
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

