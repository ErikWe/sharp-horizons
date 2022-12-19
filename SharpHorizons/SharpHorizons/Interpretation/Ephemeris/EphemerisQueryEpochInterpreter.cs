namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using NodaTime;
using NodaTime.Text;

using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IEphemerisQueryEpochInterpreter"/>
internal sealed class EphemerisQueryEpochInterpreter : IEphemerisQueryEpochInterpreter
{
    /// <summary>The <see cref="LocalDateTimePattern"/> used internally when parsing the <see cref="IEpoch"/>.</summary>
    private static LocalDateTimePattern DatePattern { get; } = LocalDateTimePattern.CreateWithInvariantCulture("yyyy-MMM-d H:m:s");

    /// <summary>The <see cref="DateTimeZone"/> of JPL (Pasadena, California).</summary>
    private DateTimeZone JPLTimeZone { get; }

    /// <inheritdoc cref="EphemerisQueryEpochInterpreter"/>
    /// <param name="interpretationsOptionsProvider"><inheritdoc cref="IInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="timeZoneProvider"><inheritdoc cref="IDateTimeZoneProvider" path="/summary"/></param>
    public EphemerisQueryEpochInterpreter(IInterpretationOptionsProvider interpretationsOptionsProvider, IDateTimeZoneProvider timeZoneProvider)
    {
        JPLTimeZone = timeZoneProvider[interpretationsOptionsProvider.HorizonsTimeZoneID];
    }

    Optional<IEpoch> IInterpreter<IEpoch>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Split('/') is not { Length: 3 } slashSplit || slashSplit[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: 8 } spaceSplit || spaceSplit[4].Split(':') is not { Length: 3 } colonSplit)
        {
            return new();
        }

        var formattedDate = $"{spaceSplit[5]}-{spaceSplit[2]}-{spaceSplit[3]} {colonSplit[0]}:{colonSplit[1]}:{colonSplit[2]}";

        var dateParse = DatePattern.Parse(formattedDate);

        if (dateParse.Success is false)
        {
            return new();
        }

        var zonedDateTime = dateParse.Value.InZoneLeniently(JPLTimeZone);

        return new Epoch(zonedDateTime);
    }
}
