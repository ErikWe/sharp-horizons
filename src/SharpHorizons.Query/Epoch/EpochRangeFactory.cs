namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

/// <summary>Handles construction of <see cref="IEpochRange"/>.</summary>
public sealed class EpochRangeFactory : IEpochRangeFactory, IFixedEpochRangeFactory, IUniformEpochRangeFactory, ICalendarEpochRangeFactory, IAngularEpochRangeFactory
{
    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory BackingEpochRangeFactory { get; }

    /// <inheritdoc cref="IFixedEpochRangeFactory"/>
    private IFixedEpochRangeFactory FixedEpochRangeFactory { get; }

    /// <inheritdoc cref="IUniformEpochRangeFactory"/>
    private IUniformEpochRangeFactory UniformEpochRangeFactory { get; }

    /// <inheritdoc cref="ICalendarEpochRangeFactory"/>
    private ICalendarEpochRangeFactory CalendarEpochRangeFactory { get; }

    /// <inheritdoc cref="IAngularEpochRangeFactory"/>
    private IAngularEpochRangeFactory AngularEpochRangeFactory { get; }

    /// <inheritdoc cref="EpochRangeFactory"/>
    /// <param name="backingEpochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    /// <param name="fixedEpochRangeFactory"><inheritdoc cref="FixedEpochRangeFactory" path="/summary"/></param>
    /// <param name="uniformEpochRangeFactory"><inheritdoc cref="UniformEpochRangeFactory" path="/summary"/></param>
    /// <param name="calendarEpochRangeFactory"><inheritdoc cref="CalendarEpochRangeFactory" path="/summary"/></param>
    /// <param name="angularEpochRangeFactory"><inheritdoc cref="AngularEpochRangeFactory" path="/summary"/></param>
    public EpochRangeFactory(IEpochRangeFactory? backingEpochRangeFactory = null, IFixedEpochRangeFactory? fixedEpochRangeFactory = null, IUniformEpochRangeFactory? uniformEpochRangeFactory = null, ICalendarEpochRangeFactory? calendarEpochRangeFactory = null, IAngularEpochRangeFactory? angularEpochRangeFactory = null)
    {
        BackingEpochRangeFactory = backingEpochRangeFactory ?? new SimpleEpochRangeFactory();

        FixedEpochRangeFactory = fixedEpochRangeFactory ?? new FixedEpochRangeFactory();

        UniformEpochRangeFactory = uniformEpochRangeFactory ?? new UniformEpochRangeFactory();
        CalendarEpochRangeFactory = calendarEpochRangeFactory ?? new CalendarEpochRangeFactory();
        AngularEpochRangeFactory = angularEpochRangeFactory ?? new AngularEpochRangeFactory();
    }

    /// <inheritdoc/>
    public IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => BackingEpochRangeFactory.Create(startEpoch, stopEpoch, stepSize);

    /// <inheritdoc cref="IFixedEpochRangeFactory.Create(IEpoch, IEpoch, Time)"/>
    public IEpochRange Fixed(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) => FixedEpochRangeFactory.Create(startEpoch, stopEpoch, deltaTime);

    /// <inheritdoc cref="IUniformEpochRangeFactory.Create(IEpoch, IEpoch, int)"/>
    public IEpochRange Uniform(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) => UniformEpochRangeFactory.Create(startEpoch, stopEpoch, stepCount);

    /// <inheritdoc cref="ICalendarEpochRangeFactory.Create(IEpoch, IEpoch, int, CalendarStepSizeUnit)"/>
    public IEpochRange Calendar(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) => CalendarEpochRangeFactory.Create(startEpoch, stopEpoch, count, unit);

    /// <inheritdoc cref="IAngularEpochRangeFactory.Create(IEpoch, IEpoch, Angle)"/>
    /// <remarks><inheritdoc cref="IAngularEpochRangeFactory" path="/remarks"/></remarks>
    public IEpochRange Angular(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) => AngularEpochRangeFactory.Create(startEpoch, stopEpoch, deltaAngle);

    IEpochRange IFixedEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) => Fixed(startEpoch, stopEpoch, deltaTime);
    IEpochRange IUniformEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) => Uniform(startEpoch, stopEpoch, stepCount);
    IEpochRange ICalendarEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) => Calendar(startEpoch, stopEpoch, count, unit);
    IEpochRange IAngularEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) => Angular(startEpoch, stopEpoch, deltaAngle);
}
