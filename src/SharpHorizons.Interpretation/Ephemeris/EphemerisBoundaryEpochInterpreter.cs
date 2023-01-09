namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using NodaTime;
using NodaTime.Text;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="IStartEpoch"/> or <see cref="IStopEpoch"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisBoundaryEpochInterpreter : IEphemerisStartEpochInterpreter, IEphemerisStopEpochInterpreter
{
    /// <summary>The <see cref="LocalDateTimePattern"/> used internally when parsing the <see cref="IEpoch"/>.</summary>
    private static LocalDateTimePattern DatePattern { get; } = LocalDateTimePattern.CreateWithInvariantCulture("uuuu-MMM-d H:m:s.FFFF");

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider InterpretationOptionsProvider { get; }

    /// <inheritdoc cref="ITimeSystemOffsetProvider"/>
    private ITimeSystemOffsetProvider TimeSystemOffsetProvider { get; }

    /// <inheritdoc cref="ITimeSystemInterpreter"/>
    private ITimeSystemInterpreter TimeSystemInterpreter { get; }

    /// <inheritdoc cref="ITimeZoneOffsetInterpreter"/>
    private ITimeZoneOffsetInterpreter TimeZoneOffsetInterpreter { get; }

    /// <inheritdoc cref="EphemerisBoundaryEpochInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="timeSystemOffsetProvider"><inheritdoc cref="TimeSystemOffsetProvider" path="/summary"/></param>
    /// <param name="timeSystemInterpreter"><inheritdoc cref="TimeSystemInterpreter" path="/summary"/></param>
    /// <param name="timeZoneOffsetInterpreter"><inheritdoc cref="TimeZoneOffsetInterpreter" path="/summary"/></param>
    public EphemerisBoundaryEpochInterpreter(IEphemerisInterpretationOptionsProvider interpretationOptionsProvider, ITimeSystemOffsetProvider timeSystemOffsetProvider, ITimeSystemInterpreter timeSystemInterpreter, ITimeZoneOffsetInterpreter timeZoneOffsetInterpreter)
    {
        InterpretationOptionsProvider = interpretationOptionsProvider;

        TimeSystemOffsetProvider = timeSystemOffsetProvider;
        TimeSystemInterpreter = timeSystemInterpreter;
        TimeZoneOffsetInterpreter = timeZoneOffsetInterpreter;
    }

    Optional<IEpoch> IInterpreter<IEpoch>.Interpret(QueryResult queryResult)
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

        var era = InterpretEra(spaceSplit[0]);

        if (era is Era.Unknown)
        {
            return new();
        }

        if (TimeSystemInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var timeSystem } || timeSystem is TimeSystem.Unknown)
        {
            return new();
        }

        if (TimeZoneOffsetInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var timeZoneOffset })
        {
            return new();
        }

        return InterpretEpoch(spaceSplit, era, timeSystem, timeZoneOffset);
    }

    /// <summary>Interprets the <see cref="Era"/> described by <paramref name="eraString"/>.</summary>
    /// <param name="eraString">The <see cref="Era"/> described by this <see cref="string"/> is interpreted.</param>
    private Era InterpretEra(string eraString)
    {
        if (eraString == InterpretationOptionsProvider.BoundaryEpochCE)
        {
            return Era.CE;
        }

        if (eraString == InterpretationOptionsProvider.BoundaryEpochBCE)
        {
            return Era.BCE;
        }

        return Era.Unknown;
    }

    /// <summary>Attempts to interpret an <see cref="IEpoch"/>.</summary>
    /// <param name="spaceSplit">The content of the line of the ephemeris header, split by whitespace.</param>
    /// <param name="era">The interpreted <see cref="Era"/> of the <see cref="IEpoch"/>.</param>
    /// <param name="timeSystem">The interpreted <see cref="TimeSystem"/> used to express the <see cref="IEpoch"/>.</param>
    /// <param name="timeZoneOffset">The interpreted <see cref="Time"/> offset from UTC used to express the <see cref="IEpoch"/>.</param>
    private Optional<IEpoch> InterpretEpoch(string[] spaceSplit, Era era, TimeSystem timeSystem, Time timeZoneOffset)
    {
        var timeZone = DateTimeZone.ForOffset(Offset.FromHoursAndMinutes((int)timeZoneOffset.Hours, (int)(timeZoneOffset.Minutes - (timeZoneOffset.Hours * 60))));

        var eraText = era is Era.BCE ? "-" : string.Empty;

        var formattedDate = $"{eraText}{spaceSplit[1]} {spaceSplit[2]}";

        var dateParse = DatePattern.Parse(formattedDate);

        if (dateParse.Success is false)
        {
            return new();
        }

        var zonedDateTime = dateParse.Value.InZoneStrictly(timeZone);

        var offset = TimeSystemOffsetProvider.Offset(new Epoch(zonedDateTime), timeSystem, TimeSystem.UT);

        var adjustedZonedDateTime = zonedDateTime.PlusMilliseconds((int)offset.Milliseconds);

        return new Epoch(adjustedZonedDateTime);
    }

    /// <summary>Represents the era of a date in the Julian and Gregorian calendars.</summary>
    private enum Era
    {
        /// <summary>The <see cref="Era"/> of a date is unknown - either <see cref="BCE"/> or <see cref="CE"/>.</summary>
        Unknown,
        /// <summary>Before current era, a date before year 0.</summary>
        BCE,
        /// <summary>Current era, a date after year 0.</summary>
        CE
    }
}
