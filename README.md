[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.quarter.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.quarter/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.quarter/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.quarter/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.quarter.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.quarter/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.quarter/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.quarter/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.Quarter

Computes current, previous, and next calendar-quarter boundaries for `DateTime`, with optional time-zone-aware UTC results.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.Quarter
```

## Calendar-field boundaries

```csharp
using Soenneker.Extensions.DateTime.Quarter;

System.DateTime value = new(2026, 8, 29, 16, 42, 30, DateTimeKind.Utc);

System.DateTime start = value.ToStartOfQuarter();       // 2026-07-01 00:00:00
System.DateTime end = value.ToEndOfQuarter();           // last tick of 2026-09-30
System.DateTime nextStart = value.ToStartOfNextQuarter();
System.DateTime previousEnd = value.ToEndOfPreviousQuarter();
```

Calendar quarters are January–March, April–June, July–September, and October–December.

| Method pair | Selected quarter |
| --- | --- |
| `ToStartOfQuarter()` / `ToEndOfQuarter()` | Current |
| `ToStartOfPreviousQuarter()` / `ToEndOfPreviousQuarter()` | Previous |
| `ToStartOfNextQuarter()` / `ToEndOfNextQuarter()` | Next |

Start methods return midnight on the quarter's first date. End methods return one tick before the following quarter. These methods operate on the input calendar fields, preserve `Kind`, and handle year rollover through `DateTime` calendar arithmetic.

## Time-zone-aware boundaries

```csharp
TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
System.DateTime utc = new(2026, 8, 29, 18, 0, 0, DateTimeKind.Utc);

System.DateTime localQuarterStartUtc = utc.ToStartOfTzQuarter(eastern);
System.DateTime localQuarterEndUtc = utc.ToEndOfTzQuarter(eastern);
```

Time-zone variants are available for the current, previous, and next quarter by adding `Tz` to the method name, such as `ToStartOfPreviousTzQuarter()` and `ToEndOfNextTzQuarter()`. They select the quarter using the input instant's local calendar and return the boundary as a UTC `DateTime`.

If the input `Kind` is not `Utc`, its fields are treated as UTC rather than converted from the machine's local zone. Supply an actual UTC value to avoid ambiguity.

Quarter ends are one tick before the following valid local quarter boundary. If a local quarter begins in a daylight-saving gap, the boundary advances to the first valid local minute; if it is ambiguous, the earlier UTC instant is selected.
