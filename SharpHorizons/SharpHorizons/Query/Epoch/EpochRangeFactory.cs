namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;

using SharpMeasures;

using System;

/// <summary>Handles construction of <see cref="IEpochRange"/>.</summary>
public sealed class EpochRangeFactory : IFixedEpochRangeFactory, IUniformEpochRangeFactory, ICalendarEpochRangeFactory, IAngularEpochRangeFactory
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
    private IStartEpochComposer<IEpoch> StartEpochComposer { get; }

    /// <summary>Composes <see cref="IStopEpochArgument"/> that describe <see cref="IEpoch"/>.</summary>
    private IStopEpochComposer<IEpoch> StopEpochComposer { get; }

    /// <inheritdoc cref="StepSizeFactory"/>
    /// <param name="fixedStepSizeFactory"><inheritdoc cref="FixedStepSizeFactory" path="/summary"/></param>
    /// <param name="uniformStepSizeFactory"><inheritdoc cref="UniformStepSizeFactory" path="/summary"/></param>
    /// <param name="calendarStepSizeFactory"><inheritdoc cref="CalendarStepSizeFactory" path="/summary"/></param>
    /// <param name="angularStepSizeFactory"><inheritdoc cref="AngularStepSizeFactory" path="/summary"/></param>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    public EpochRangeFactory(IFixedStepSizeFactory? fixedStepSizeFactory = null, IUniformStepSizeFactory? uniformStepSizeFactory = null, ICalendarStepSizeFactory? calendarStepSizeFactory = null, IAngularStepSizeFactory? angularStepSizeFactory = null, IStartEpochComposer<IEpoch>? startEpochComposer = null, IStopEpochComposer<IEpoch>? stopEpochComposer = null)
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

    /// <inheritdoc cref="EpochRange(IStartEpoch, IStopEpoch, IStepSize)"/>
    /// <exception cref="ArgumentNullException"/>
    private IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return new EpochRange(new StartEpoch(startEpoch, StartEpochComposer), new StopEpoch(stopEpoch, StopEpochComposer), stepSize);
    }
}
