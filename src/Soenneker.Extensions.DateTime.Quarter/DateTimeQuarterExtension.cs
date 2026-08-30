using System.Diagnostics.Contracts;
using Soenneker.Enums.UnitOfTime;

namespace Soenneker.Extensions.DateTime.Quarter;

/// <summary>
/// Provides extension methods for <see cref="System.DateTime"/> to handle quarter calculations.
/// </summary>
public static class DateTimeQuarterExtension
{
    /// <summary>
    /// Adjusts the specified <paramref name="dateTime"/> to the start of its quarter.
    /// </summary>
    /// <param name="dateTime">The date and time to adjust.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the first moment of the quarter.</returns>
    [Pure]
    public static System.DateTime ToStartOfQuarter(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOf(UnitOfTime.Quarter);
        return result;
    }

    /// <summary>
    /// Returns midnight on the first day of the calendar quarter following the one containing the value.
    /// </summary>
    /// <param name="dateTime">The date and time to adjust.</param>
    /// <returns>The start of the next quarter.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextQuarter(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOf(UnitOfTime.Quarter).AddMonths(3);
        return result;
    }

    /// <summary>
    /// Returns midnight on the first day of the calendar quarter preceding the one containing the value.
    /// </summary>
    /// <param name="dateTime">The date and time to adjust.</param>
    /// <returns>The start of the previous quarter.</returns>
    [Pure]
    public static System.DateTime ToStartOfPreviousQuarter(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOf(UnitOfTime.Quarter).AddMonths(-3);
        return result;
    }

    /// <summary>
    /// Adjusts the specified <paramref name="dateTime"/> to the end of its quarter.
    /// </summary>
    /// <param name="dateTime">The date and time to adjust.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the last moment of the quarter.</returns>
    [Pure]
    public static System.DateTime ToEndOfQuarter(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(UnitOfTime.Quarter);
        return result;
    }

    /// <summary>
    /// Returns the final tick of the calendar quarter following the one containing the value.
    /// </summary>
    /// <param name="dateTime">The date and time to adjust.</param>
    /// <returns>The end of the next quarter.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextQuarter(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(UnitOfTime.Quarter).AddMonths(3);
        return result;
    }

    /// <summary>
    /// Returns the final tick of the calendar quarter preceding the one containing the value.
    /// </summary>
    /// <param name="dateTime">The date and time to adjust.</param>
    /// <returns>The end of the previous quarter.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousQuarter(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(UnitOfTime.Quarter).AddMonths(-3);
        return result;
    }

    /// <summary>
    /// Returns the start of the current local quarter as a UTC value.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>The first valid instant of the current local quarter, expressed in UTC.</returns>
    [Pure]
    public static System.DateTime ToStartOfTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        return GetStartOfTzQuarter(utcNow, tzInfo, 0);
    }

    /// <summary>
    /// Returns the start of the next local quarter as a UTC value.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>The first valid instant of the next local quarter, expressed in UTC.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        return GetStartOfTzQuarter(utcNow, tzInfo, 1);
    }

    /// <summary>
    /// Adjusts the specified UTC <paramref name="utcNow"/>, converted to the time zone specified by <paramref name="tzInfo"/>, to the start of the previous quarter in that time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the first moment of the previous quarter in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfPreviousTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        return GetStartOfTzQuarter(utcNow, tzInfo, -1);
    }

    /// <summary>
    /// Converts the specified UTC <paramref name="utcNow"/> to the time zone specified by <paramref name="tzInfo"/>, and adjusts it to the end of its quarter in that time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the last moment of the quarter in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        return GetStartOfTzQuarter(utcNow, tzInfo, 1).AddTicks(-1);
    }

    /// <summary>
    /// Adjusts the specified UTC <paramref name="utcNow"/>, converted to the time zone specified by <paramref name="tzInfo"/>, to the end of the next quarter in that time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the last moment of the next quarter in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        return GetStartOfTzQuarter(utcNow, tzInfo, 2).AddTicks(-1);
    }

    /// <summary>
    /// Adjusts the specified UTC <paramref name="utcNow"/>, converted to the time zone specified by <paramref name="tzInfo"/>, to the end of the previous quarter in that time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the last moment of the previous quarter in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        return GetStartOfTzQuarter(utcNow, tzInfo, 0).AddTicks(-1);
    }

    private static System.DateTime GetStartOfTzQuarter(System.DateTime utc, System.TimeZoneInfo timeZoneInfo, int quarterOffset)
    {
        System.DateTime utcInstant = utc.Kind == System.DateTimeKind.Utc
            ? utc
            : System.DateTime.SpecifyKind(utc, System.DateTimeKind.Utc);
        System.DateTime local = System.TimeZoneInfo.ConvertTimeFromUtc(utcInstant, timeZoneInfo);
        int quarterStartMonth = ((local.Month - 1) / 3) * 3 + 1;
        var boundary = new System.DateTime(local.Year, quarterStartMonth, 1, 0, 0, 0, System.DateTimeKind.Unspecified).AddMonths(quarterOffset * 3);

        while (timeZoneInfo.IsInvalidTime(boundary))
            boundary = boundary.AddMinutes(1);

        if (timeZoneInfo.IsAmbiguousTime(boundary))
        {
            System.TimeSpan[] offsets = timeZoneInfo.GetAmbiguousTimeOffsets(boundary);
            System.TimeSpan chosenOffset = offsets[0] >= offsets[1] ? offsets[0] : offsets[1];
            return System.DateTime.SpecifyKind(boundary - chosenOffset, System.DateTimeKind.Utc);
        }

        return System.TimeZoneInfo.ConvertTimeToUtc(boundary, timeZoneInfo);
    }
}
