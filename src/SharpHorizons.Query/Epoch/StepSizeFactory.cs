namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

/// <summary>Handles construction of <see cref="IStepSize"/>.</summary>
public sealed class StepSizeFactory : IFixedStepSizeFactory, IUniformStepSizeFactory, ICalendarStepSizeFactory, IAngularStepSizeFactory
{
    /// <inheritdoc cref="IFixedStepSizeFactory"/>
    private IFixedStepSizeFactory FixedStepSizeFactory { get; }

    /// <inheritdoc cref="IUniformStepSizeFactory"/>
    private IUniformStepSizeFactory UniformStepSizeFactory { get; }

    /// <inheritdoc cref="ICalendarStepSizeFactory"/>
    private ICalendarStepSizeFactory CalendarStepSizeFactory { get; }

    /// <inheritdoc cref="IAngularStepSizeFactory"/>
    private IAngularStepSizeFactory AngularStepSizeFactory { get; }

    /// <inheritdoc cref="StepSizeFactory"/>
    /// <param name="fixedStepSizeFactory"><inheritdoc cref="FixedStepSizeFactory" path="/summary"/></param>
    /// <param name="uniformStepSizeFactory"><inheritdoc cref="UniformStepSizeFactory" path="/summary"/></param>
    /// <param name="calendarStepSizeFactory"><inheritdoc cref="CalendarStepSizeFactory" path="/summary"/></param>
    /// <param name="angularStepSizeFactory"><inheritdoc cref="AngularStepSizeFactory" path="/summary"/></param>
    public StepSizeFactory(IFixedStepSizeFactory? fixedStepSizeFactory = null, IUniformStepSizeFactory? uniformStepSizeFactory = null, ICalendarStepSizeFactory? calendarStepSizeFactory = null, IAngularStepSizeFactory? angularStepSizeFactory = null)
    {
        FixedStepSizeFactory = fixedStepSizeFactory ?? new FixedStepSizeFactory();
        UniformStepSizeFactory = uniformStepSizeFactory ?? new UniformStepSizeFactory();
        CalendarStepSizeFactory = calendarStepSizeFactory ?? new CalendarStepSizeFactory();
        AngularStepSizeFactory = angularStepSizeFactory ?? new AngularStepSizeFactory();
    }

    /// <inheritdoc cref="IFixedStepSizeFactory.Create(Time)"/>
    public IFixedStepSize Fixed(Time deltaTime) => FixedStepSizeFactory.Create(deltaTime);

    /// <inheritdoc cref="IUniformStepSizeFactory.Create(int)"/>
    public IUniformStepSize Uniform(int stepCount) => UniformStepSizeFactory.Create(stepCount);

    /// <inheritdoc cref="ICalendarStepSizeFactory.Create(int, CalendarStepSizeUnit)"/>
    public ICalendarStepSize Calendar(int count, CalendarStepSizeUnit unit) => CalendarStepSizeFactory.Create(count, unit);

    /// <inheritdoc cref="IAngularStepSizeFactory.Create(Angle)"/>
    public IAngularStepSize Angular(Angle deltaAngle) => AngularStepSizeFactory.Create(deltaAngle);

    IFixedStepSize IFixedStepSizeFactory.Create(Time deltaTime) => Fixed(deltaTime);
    IUniformStepSize IUniformStepSizeFactory.Create(int stepCount) => Uniform(stepCount);
    ICalendarStepSize ICalendarStepSizeFactory.Create(int count, CalendarStepSizeUnit unit) => Calendar(count, unit);
    IAngularStepSize IAngularStepSizeFactory.Create(Angle deltaAngle) => Angular(deltaAngle);
}
