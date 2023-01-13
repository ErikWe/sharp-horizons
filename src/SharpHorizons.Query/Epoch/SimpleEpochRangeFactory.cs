namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using System;

/// <inheritdoc cref="IEpochRangeFactory"/>
public sealed class SimpleEpochRangeFactory : IEpochRangeFactory
{
    /// <summary>Composes <see cref="IStartEpochArgument"/> that describe <see cref="IEpoch"/>.</summary>
    private IStartEpochComposer<IEpochRange> StartEpochComposer { get; }

    /// <summary>Composes <see cref="IStopEpochArgument"/> that describe <see cref="IEpoch"/>.</summary>
    private IStopEpochComposer<IEpochRange> StopEpochComposer { get; }

    /// <inheritdoc cref="IEpochCalendarComposer"/>
    private IEpochCalendarComposer CalendarComposer { get; }

    /// <inheritdoc cref="ITimeSystemComposer"/>
    private ITimeSystemComposer TimeSystemComposer { get; }

    /// <inheritdoc cref="ITimeZoneComposer"/>
    private ITimeZoneComposer TimeZoneComposer { get; }

    /// <inheritdoc cref="SimpleEpochRangeFactory"/>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    public SimpleEpochRangeFactory(IStartEpochComposer<IEpochRange>? startEpochComposer = null, IStopEpochComposer<IEpochRange>? stopEpochComposer = null, IEpochCalendarComposer? calendarComposer = null, ITimeSystemComposer? timeSystemComposer = null, ITimeZoneComposer? timeZoneComposer = null)
    {
        EpochRangeEpochComposer? defaultEpochComposer = null;

        if (startEpochComposer is null || stopEpochComposer is null)
        {
            defaultEpochComposer = new EpochRangeEpochComposer();
        }

        StartEpochComposer = startEpochComposer ?? defaultEpochComposer!;
        StopEpochComposer = stopEpochComposer ?? defaultEpochComposer!;

        CalendarComposer = calendarComposer ?? new EpochCalendarComposer();
        TimeSystemComposer = timeSystemComposer ?? new TimeSystemComposer();
        TimeZoneComposer = timeZoneComposer ?? new TimeZoneComposer();
    }

    IEpochRange IEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);
        ArgumentNullException.ThrowIfNull(stepSize);

        if (startEpoch.CompareTo(stopEpoch) >= 0)
        {
            throw new ArgumentException($"The {nameof(startEpoch)} should represent a later {nameof(IEpoch)} than the {nameof(stopEpoch)}.");
        }

        return new EpochRange(new EphemerisBoundaryEpoch(startEpoch), new EphemerisBoundaryEpoch(stopEpoch), stepSize, StartEpochComposer, StopEpochComposer, CalendarComposer, TimeSystemComposer, TimeZoneComposer);
    }
}
