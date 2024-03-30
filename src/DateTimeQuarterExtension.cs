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
    /// Adjusts the specified UTC <paramref name="utcNow"/>, converted to the time zone specified by <paramref name="tzInfo"/>, to the start of the previous quarter in that time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the first moment of the previous quarter in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime start = utcNow.ToTz(tzInfo).ToStartOfQuarter().ToUtc(tzInfo);
        return start;
    }

    /// <summary>
    /// Converts the specified UTC <paramref name="utcNow"/> to the time zone specified by <paramref name="tzInfo"/>, and adjusts it to the end of its quarter in that time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert and adjust.</param>
    /// <param name="tzInfo">The time zone to convert to.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the last moment of the quarter in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextTzQuarter(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime start = utcNow.ToStartOfTzQuarter(tzInfo).AddMonths(3);
        return start;
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
        System.DateTime start = utcNow.ToStartOfTzQuarter(tzInfo).AddMonths(-3);
        return start;
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
        System.DateTime start = utcNow.ToTz(tzInfo).ToEndOfQuarter().ToUtc(tzInfo);
        return start;
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
        System.DateTime start = utcNow.ToEndOfTzQuarter(tzInfo).AddMonths(3);
        return start;
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
        System.DateTime start = utcNow.ToEndOfTzQuarter(tzInfo).AddMonths(-3);
        return start;
    }
}
