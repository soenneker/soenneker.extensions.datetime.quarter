[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.quarter.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.quarter/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.quarter/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.quarter/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.quarter.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.quarter/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.quarter/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.quarter/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.Quarter
A collection of helpful DateTime quarter (year) based extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.Quarter
```

## Quick start

```csharp
using Soenneker.Extensions.DateTime.Quarter;

DateTime dateTime = DateTime.UtcNow;
var result = dateTime.ToStartOfQuarter();
```

## Common operations

- `ToStartOfQuarter()` - Adjusts the specified `dateTime` to the start of its quarter. Returns a `System.DateTime` representing the first moment of the quarter.
- `ToStartOfNextQuarter()` - Returns midnight on the first day of the next calendar quarter.
- `ToStartOfPreviousQuarter()` - Returns midnight on the first day of the previous calendar quarter.
- `ToEndOfQuarter()` - Adjusts the specified `dateTime` to the end of its quarter. Returns a `System.DateTime` representing the last moment of the quarter.
- `ToEndOfNextQuarter()` - Returns the final tick of the next calendar quarter.
- `ToEndOfPreviousQuarter()` - Returns the final tick of the previous calendar quarter.
- `ToStartOfTzQuarter()` - Adjusts the specified UTC `utcNow`, converted to the time zone specified by `tzInfo`, to the start of the previous quarter in that time zone. Returns a `System.DateTime` representing the first moment of the previous quarter in UTC, adjusted for the specified time zone.
- `ToStartOfNextTzQuarter()` - Converts the specified UTC `utcNow` to the time zone specified by `tzInfo`, and adjusts it to the end of its quarter in that time zone. Returns a `System.DateTime` representing the last moment of the quarter in UTC, adjusted for the specified time zone.
- `ToStartOfPreviousTzQuarter()` - Adjusts the specified UTC `utcNow`, converted to the time zone specified by `tzInfo`, to the start of the previous quarter in that time zone. Returns a `System.DateTime` representing the first moment of the previous quarter in UTC, adjusted for the specified time zone.
- `ToEndOfTzQuarter()` - Converts the specified UTC `utcNow` to the time zone specified by `tzInfo`, and adjusts it to the end of its quarter in that time zone. Returns a `System.DateTime` representing the last moment of the quarter in UTC, adjusted for the specified time zone.
- `ToEndOfNextTzQuarter()` - Adjusts the specified UTC `utcNow`, converted to the time zone specified by `tzInfo`, to the end of the next quarter in that time zone. Returns a `System.DateTime` representing the last moment of the next quarter in UTC, adjusted for the specified time zone.
- `ToEndOfPreviousTzQuarter()` - Adjusts the specified UTC `utcNow`, converted to the time zone specified by `tzInfo`, to the end of the previous quarter in that time zone. Returns a `System.DateTime` representing the last moment of the previous quarter in UTC, adjusted for the specified time zone.
