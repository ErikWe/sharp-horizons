namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using NodaTime;
using NodaTime.Text;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="IStartEpoch"/> or <see cref="IStopEpoch"/>.</summary>
internal sealed class EphemerisBoundaryEpochInterpreter : IEphemerisStartEpochInterpreter, IEphemerisStopEpochInterpreter
{
    /// <summary>The <see cref="LocalDateTimePattern"/> used internally when parsing the <see cref="IEpoch"/>.</summary>
    private static LocalDateTimePattern DatePattern { get; } = LocalDateTimePattern.CreateWithInvariantCulture("uuuu-MMM-d H:m:s.f");

    /// <inheritdoc cref="ITimeSystemOffsetProvider"/>
    private ITimeSystemOffsetProvider TimeSystemOffsetProvider { get; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider InterpretationOptionsProvider { get; }

    /// <inheritdoc cref="EphemerisBoundaryEpochInterpreter"/>
    /// <param name="timeSystemOffsetProvider"><inheritdoc cref="TimeSystemOffsetProvider" path="/summary"/></param>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    public EphemerisBoundaryEpochInterpreter(ITimeSystemOffsetProvider timeSystemOffsetProvider, IEphemerisInterpretationOptionsProvider interpretationOptionsProvider)
    {
        TimeSystemOffsetProvider = timeSystemOffsetProvider;

        InterpretationOptionsProvider = interpretationOptionsProvider;
    }

    Optional<IStartEpoch> IPartInterpreter<IStartEpoch>.TryInterpret(string queryPart)
    {
        if (Interpret(queryPart) is EphemerisBoundaryEpoch epoch)
        {
            return epoch;
        }

        return new();
    }

    Optional<IStopEpoch> IPartInterpreter<IStopEpoch>.TryInterpret(string queryPart)
    {
        if (Interpret(queryPart) is EphemerisBoundaryEpoch epoch)
        {
            return epoch;
        }

        return new();
    }

    /// <summary>Attempts to interpret an <see cref="IEpoch"/> from <paramref name="queryPart"/>.</summary>
    /// <param name="queryPart">An <see cref="IEpoch"/> is interpreted from this <see cref="string"/>, if possible.</param>
    /// <exception cref="ArgumentNullException"/>
    private EphemerisBoundaryEpoch? Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        var firstColonIndex = queryPart.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return null;
        }

        if (queryPart[(firstColonIndex + 1)..].Trim().Split(' ') is not { Length: 4 } spaceSplit)
        {
            return null;
        }

        var era = InterpretEra(spaceSplit[0]);

        if (era is Era.Unknown)
        {
            return null;
        }

        var eraText = era is Era.BCE ? "-" : string.Empty;

        var formattedDate = $"{eraText}{spaceSplit[1]} {spaceSplit[1]}";

        var dateParse = DatePattern.Parse(formattedDate);

        if (dateParse.Success is false)
        {
            return null;
        }

        if (InterpretTimeZone(spaceSplit[3]) is not DateTimeZone zone)
        {
            return null;
        }

        var timeSystem = InterpretTimeSystem(spaceSplit[3]);

        if (timeSystem is TimeSystem.Unknown)
        {
            return null;
        }

        var zonedDateTime = dateParse.Value.InZoneStrictly(zone);

        var offset = TimeSystemOffsetProvider.Offset(new Epoch(zonedDateTime), timeSystem, TimeSystem.UT);

        var adjustedZonedDateTime = zonedDateTime.PlusMilliseconds((int)offset.Milliseconds);

        return new EphemerisBoundaryEpoch(new Epoch(adjustedZonedDateTime));
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

    /// <summary>Interprets the <see cref="TimeSystem"/> described by <paramref name="timeSystemString"/>.</summary>
    /// <param name="timeSystemString">The <see cref="TimeSystem"/> described by this <see cref="string"/> is interpreted.</param>
    private static TimeSystem InterpretTimeSystem(string timeSystemString)
    {
        if (timeSystemString.StartsWith("UT"))
        {
            return TimeSystem.UT;
        }

        if (timeSystemString.StartsWith("TT"))
        {
            return TimeSystem.TT;
        }

        if (timeSystemString.StartsWith("TDB"))
        {
            return TimeSystem.TDB;
        }

        return TimeSystem.Unknown;
    }

    /// <summary>Attempts to interpret the <see cref="DateTimeZone"/> described by <paramref name="zoneString"/>.</summary>
    /// <param name="zoneString">The <see cref="DateTimeZone"/> described by this <see cref="string"/> is interpreted, if possible.</param>
    private static DateTimeZone? InterpretTimeZone(string zoneString)
    {
        var startIndex = zoneString.IndexOf('+');

        if (startIndex is -1)
        {
            startIndex = zoneString.IndexOf('-');
        
            if (startIndex is -1)
            {
                return DateTimeZone.Utc;
            }
        }

        var colonSplit = zoneString[startIndex..].Split(':');

        if (int.TryParse(colonSplit[0], out var hour) is false)
        {
            return null;
        }

        if (colonSplit.Length is 1)
        {
            return DateTimeZone.ForOffset(Offset.FromHours(hour));
        }

        if (int.TryParse(colonSplit[1], out var minute) is false)
        {
            return null;
        }

        return DateTimeZone.ForOffset(Offset.FromHoursAndMinutes(hour, minute));
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
