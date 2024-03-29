﻿namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Result;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITimeZoneOffsetInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class TimeZoneOffsetInterpreter : ITimeZoneOffsetInterpreter
{
    Optional<Time> IInterpreter<Time>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryResult.Content[(firstColonIndex + 1)..].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: 4 } spaceSplit)
        {
            return new();
        }

        var timeZoneString = spaceSplit[3];

        var startIndex = timeZoneString.IndexOf('+', StringComparison.Ordinal);

        if (startIndex is -1)
        {
            startIndex = timeZoneString.IndexOf('-', StringComparison.Ordinal);

            if (startIndex is -1)
            {
                return Time.Zero;
            }
        }

        var colonSplit = timeZoneString[startIndex..].Split(':');

        if (int.TryParse(colonSplit[0], out var hour) is false)
        {
            return new();
        }

        if (colonSplit.Length is 1)
        {
            return hour * Time.OneHour;
        }

        if (int.TryParse(colonSplit[1], out var minute) is false)
        {
            return new();
        }

        return (hour * Time.OneHour) + (minute * Time.OneMinute);
    }
}
