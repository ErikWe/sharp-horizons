namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisStepSizeInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisStepSizeInterpreter : IEphemerisStepSizeInterpreter
{
    /// <inheritdoc cref="IFixedStepSizeFactory"/>
    private IFixedStepSizeFactory FixedStepSizeFactory { get; }

    /// <inheritdoc cref="IUniformStepSizeFactory"/>
    private IUniformStepSizeFactory UniformStepSizeFactory { get; }

    /// <inheritdoc cref="ICalendarStepSizeFactory"/>
    private ICalendarStepSizeFactory CalendarStepSizeFactory { get; }

    /// <inheritdoc cref="IAngularStepSizeFactory"/>
    private IAngularStepSizeFactory AngularStepSizeFactory { get; }

    /// <inheritdoc cref="EphemerisStepSizeInterpreter"/>
    /// <param name="fixedStepSizeFactory"><inheritdoc cref="FixedStepSizeFactory" path="/summary"/></param>
    /// <param name="uniformStepSizeFactory"><inheritdoc cref="UniformStepSizeFactory" path="/summary"/></param>
    /// <param name="calendarStepSizeFactory"><inheritdoc cref="CalendarStepSizeFactory" path="/summary"/></param>
    /// <param name="angularStepSizeFactory"><inheritdoc cref="AngularStepSizeFactory" path="/summary"/></param>
    public EphemerisStepSizeInterpreter(IFixedStepSizeFactory fixedStepSizeFactory, IUniformStepSizeFactory uniformStepSizeFactory, ICalendarStepSizeFactory calendarStepSizeFactory, IAngularStepSizeFactory angularStepSizeFactory)
    {
        FixedStepSizeFactory = fixedStepSizeFactory;
        UniformStepSizeFactory = uniformStepSizeFactory;
        CalendarStepSizeFactory = calendarStepSizeFactory;
        AngularStepSizeFactory = angularStepSizeFactory;
    }

    Optional<IStepSize> IInterpreter<IStepSize>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryResult.Content[(firstColonIndex + 1)..].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: >= 2 } spaceSplit)
        {
            return new();
        }

        if (int.TryParse(spaceSplit[0], out var intValue) is false)
        {
            return new();
        }

        return spaceSplit[1].ToUpperInvariant() switch
        {
            "STEPS" => new(UniformStepSizeFactory.Create(intValue)),
            "ARCSEC" => new(AngularStepSizeFactory.Create(intValue * Angle.OneArcsecond)),
            "MINUTES" => new(FixedStepSizeFactory.Create(intValue * Time.OneMinute)),
            "HOURS" => new(FixedStepSizeFactory.Create(intValue * Time.OneHour)),
            "DAYS" => new(FixedStepSizeFactory.Create(intValue * Time.OneDay)),
            "CALENDAR" => (spaceSplit.Length > 2 ? spaceSplit[2].ToUpperInvariant() : string.Empty) switch
            {
                "MONTHS" => new(CalendarStepSizeFactory.Create(intValue, CalendarStepSizeUnit.Month)),
                "YEARS" => new(CalendarStepSizeFactory.Create(intValue, CalendarStepSizeUnit.Year)),
                _ => new()
            },
            _ => new()
        };
    }
}
