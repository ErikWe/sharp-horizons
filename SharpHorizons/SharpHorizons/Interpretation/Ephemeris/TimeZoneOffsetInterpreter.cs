namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;

using SharpMeasures;

/// <inheritdoc cref="ITimeZoneOffsetInterpreter"/>
internal sealed class TimeZoneOffsetInterpreter : ITimeZoneOffsetInterpreter
{
    Optional<Time> IPartInterpreter<Time>.Interpret(string queryPart)
    {
        var firstColonIndex = queryPart.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryPart[(firstColonIndex + 1)..].Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries) is not { Length: 4 } spaceSplit)
        {
            return new();
        }

        var timeZoneString = spaceSplit[3];

        var startIndex = timeZoneString.IndexOf('+');

        if (startIndex is -1)
        {
            startIndex = timeZoneString.IndexOf('-');

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

        return hour * Time.OneHour + minute * Time.OneMinute;
    }
}
