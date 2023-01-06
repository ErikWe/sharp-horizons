namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpMeasures;

using System;

/// <summary>Handles construction of <see cref="IEpochRange"/>.</summary>
public sealed class EpochRangeFactory : IEpochRangeFactory, IFixedEpochRangeFactory, IUniformEpochRangeFactory, ICalendarEpochRangeFactory, IAngularEpochRangeFactory
{
    /// <inheritdoc cref="IFixedStepSizeFactory"/>
    private IFixedStepSizeFactory FixedStepSizeFactory { get; }

    /// <inheritdoc cref="IUniformStepSizeFactory"/>
    private IUniformStepSizeFactory UniformStepSizeFactory { get; }

    /// <inheritdoc cref="ICalendarStepSizeFactory"/>
    private ICalendarStepSizeFactory CalendarStepSizeFactory { get; }

    /// <inheritdoc cref="IAngularStepSizeFactory"/>
    private IAngularStepSizeFactory AngularStepSizeFactory { get; }

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

    /// <inheritdoc cref="StepSizeFactory"/>
    /// <param name="fixedStepSizeFactory"><inheritdoc cref="FixedStepSizeFactory" path="/summary"/></param>
    /// <param name="uniformStepSizeFactory"><inheritdoc cref="UniformStepSizeFactory" path="/summary"/></param>
    /// <param name="calendarStepSizeFactory"><inheritdoc cref="CalendarStepSizeFactory" path="/summary"/></param>
    /// <param name="angularStepSizeFactory"><inheritdoc cref="AngularStepSizeFactory" path="/summary"/></param>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    public EpochRangeFactory(IFixedStepSizeFactory? fixedStepSizeFactory = null, IUniformStepSizeFactory? uniformStepSizeFactory = null, ICalendarStepSizeFactory? calendarStepSizeFactory = null, IAngularStepSizeFactory? angularStepSizeFactory = null,
        IStartEpochComposer<IEpochRange>? startEpochComposer = null, IStopEpochComposer<IEpochRange>? stopEpochComposer = null, IEpochCalendarComposer? calendarComposer = null, ITimeSystemComposer? timeSystemComposer = null, ITimeZoneComposer? timeZoneComposer = null)
    {
        StepSizeFactory? defaultStepSizeFactory = null;
        EpochRangeEpochComposer? defaultEpochComposer = null;

        if (fixedStepSizeFactory is null || uniformStepSizeFactory is null || calendarStepSizeFactory is null || angularStepSizeFactory is null)
        {
            defaultStepSizeFactory = new StepSizeFactory();
        }

        if (startEpochComposer is null || stopEpochComposer is null)
        {
            defaultEpochComposer = new EpochRangeEpochComposer();
        }

        FixedStepSizeFactory = fixedStepSizeFactory ?? defaultStepSizeFactory!;
        UniformStepSizeFactory = uniformStepSizeFactory ?? defaultStepSizeFactory!;
        CalendarStepSizeFactory = calendarStepSizeFactory ?? defaultStepSizeFactory!;
        AngularStepSizeFactory = angularStepSizeFactory ?? defaultStepSizeFactory!;

        StartEpochComposer = startEpochComposer ?? defaultEpochComposer!;
        StopEpochComposer = stopEpochComposer ?? defaultEpochComposer!;

        CalendarComposer = calendarComposer ?? new EpochCalendarComposer();
        TimeSystemComposer = timeSystemComposer ?? new TimeSystemComposer();
        TimeZoneComposer = timeZoneComposer ?? new TimeZoneComposer();
    }

    /// <inheritdoc/>
    public IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize)
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

    /// <inheritdoc cref="IFixedEpochRangeFactory.Create(IEpoch, IEpoch, Time)"/>
    public IEpochRange Fixed(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) => Create(startEpoch, stopEpoch, FixedStepSizeFactory.Create(deltaTime));

    /// <inheritdoc cref="IUniformEpochRangeFactory.Create(IEpoch, IEpoch, int)"/>
    public IEpochRange Uniform(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) => Create(startEpoch, stopEpoch, UniformStepSizeFactory.Create(stepCount));

    /// <inheritdoc cref="ICalendarEpochRangeFactory.Create(IEpoch, IEpoch, int, CalendarStepSizeUnit)"/>
    public IEpochRange Calendar(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) => Create(startEpoch, stopEpoch, CalendarStepSizeFactory.Create(count, unit));

    /// <inheritdoc cref="IAngularEpochRangeFactory.Create(IEpoch, IEpoch, Angle)"/>
    /// <remarks><inheritdoc cref="IAngularEpochRangeFactory" path="/remarks"/></remarks>
    public IEpochRange Angular(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) => Create(startEpoch, stopEpoch, AngularStepSizeFactory.Create(deltaAngle));

    IEpochRange IFixedEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) => Fixed(startEpoch, stopEpoch, deltaTime);
    IEpochRange IUniformEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) => Uniform(startEpoch, stopEpoch, stepCount);
    IEpochRange ICalendarEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) => Calendar(startEpoch, stopEpoch, count, unit);
    IEpochRange IAngularEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) => Angular(startEpoch, stopEpoch, deltaAngle);
}
