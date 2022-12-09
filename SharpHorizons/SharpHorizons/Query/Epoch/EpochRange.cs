namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEpochRange"/>
internal sealed record class EpochRange : IEpochRange
{
    public required IStartEpoch StartEpoch { get; init; }
    public required IStopEpoch StopEpoch { get; init; }
    public required IStepSize StepSize { get; init; }

    public EpochFormat Format { get; init; } = EpochFormat.JulianDays;
    public CalendarType Calendar { get; init; } = CalendarType.Gregorian;
    public TimeSystem TimeSystem { get; init; } = TimeSystem.UT;
    public Time Offset { get; init; } = Time.Zero;

    /// <summary>Used to compose <see cref="IStartEpochArgument"/> that describe <see cref="StartEpoch"/>.</summary>
    public required IStartEpochComposer<IEpochRange> StartEpochComposer { private get; init; }

    /// <summary>Used to compose <see cref="IStopEpochArgument"/> that describe <see cref="StopEpoch"/>.</summary>
    public required IStopEpochComposer<IEpochRange> StopEpochComposer { private get; init; }

    /// <summary>Used to compose <see cref="ICalendarTypeArgument"/> that describe <see cref="Calendar"/>.</summary>
    public required IEpochCalendarComposer CalendarComposer { private get; init; }

    /// <summary>Used to compose <see cref="ITimeSystemArgument"/> that describe <see cref="TimeSystem"/>.</summary>
    public required ITimeSystemComposer TimeSystemComposer { private get; init; }

    /// <summary>Used to compose <see cref="ITimeZoneArgument"/> that describe <see cref="Offset"/>.</summary>
    public required ITimeZoneComposer TimeZoneComposer { private get; init; }

    /// <inheritdoc cref="EpochRange"/>
    public EpochRange() { }

    /// <inheritdoc cref="EpochRange"/>
    /// <param name="startEpoch"><inheritdoc cref="StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochRange(IStartEpoch startEpoch, IStopEpoch stopEpoch, IStepSize stepSize, IStartEpochComposer<IEpochRange> startEpochComposer, IStopEpochComposer<IEpochRange> stopEpochComposer, IEpochCalendarComposer calendarComposer, ITimeSystemComposer timeSystemComposer, ITimeZoneComposer timeZoneComposer)
    {
        StartEpoch = startEpoch;
        StopEpoch = stopEpoch;

        StepSize = stepSize;

        StartEpochComposer = startEpochComposer;
        StopEpochComposer = stopEpochComposer;
        CalendarComposer = calendarComposer;
        TimeSystemComposer = timeSystemComposer;
        TimeZoneComposer = timeZoneComposer;
    }

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Range;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotCollection();
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotCollection();
    ICalendarTypeArgument IEpochSelection.ComposeEpochCalendarArgument() => CalendarComposer.Compose(Calendar);
    ITimeSystemArgument IEpochSelection.ComposeTimeSystemArgument() => TimeSystemComposer.Compose(TimeSystem);
    ITimeZoneArgument IEpochSelection.ComposeTimeZoneArgument() => TimeZoneComposer.Compose(Offset);
    IStartEpochArgument IEpochSelection.ComposeStartTimeArgument() => StartEpochComposer.Compose(this);
    IStopEpochArgument IEpochSelection.ComposeStopTimeArgument() => StopEpochComposer.Compose(this);
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => StepSize.ComposeArgument();
}