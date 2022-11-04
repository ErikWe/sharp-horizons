namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

/// <summary>Handles construction of <see cref="IStepSize"/>.</summary>
public sealed class StepSizeFactory : IFixedStepSizeFactory, IUniformStepSizeFactory, ICalendarStepSizeFactory, IAngularStepSizeFactory
{
    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IFixedStepSize"/>.</summary>
    private IStepSizeComposer<IFixedStepSize> FixedComposer { get; }

    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IUniformStepSize"/>.</summary>
    private IStepSizeComposer<IUniformStepSize> UniformComposer { get; }

    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="ICalendarStepSize"/>.</summary>
    private IStepSizeComposer<ICalendarStepSize> CalendarComposer { get; }

    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IAngularStepSize"/>.</summary>
    private IStepSizeComposer<IAngularStepSize> AngularComposer { get; }

    /// <inheritdoc cref="StepSizeFactory"/>
    /// <param name="fixedComposer"><inheritdoc cref="FixedComposer" path="/summary"/></param>
    /// <param name="uniformComposer"><inheritdoc cref="UniformComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="angularComposer"><inheritdoc cref="AngularComposer" path="/summary"/></param>
    public StepSizeFactory(IStepSizeComposer<IFixedStepSize>? fixedComposer = null, IStepSizeComposer<IUniformStepSize>? uniformComposer = null, IStepSizeComposer<ICalendarStepSize>? calendarComposer = null, IStepSizeComposer<IAngularStepSize>? angularComposer = null)
    {
        FixedComposer = fixedComposer ?? new FixedStepSizeComposer();
        UniformComposer = uniformComposer ?? new UniformStepSizeComposer();
        CalendarComposer = calendarComposer ?? new CalendarStepSizeComposer();
        AngularComposer = angularComposer ?? new AngularStepSizeComposer();
    }

    /// <inheritdoc cref="IFixedStepSizeFactory.Create(Time)"/>
    public IFixedStepSize Fixed(Time deltaTime) => new FixedStepSize(deltaTime, FixedComposer);

    /// <inheritdoc cref="IUniformStepSizeFactory.Create(int)"/>
    public IUniformStepSize Uniform(int stepCount) => new UniformStepSize(stepCount, UniformComposer);

    /// <inheritdoc cref="ICalendarStepSizeFactory.Create(int, CalendarStepSizeUnit)"/>
    public ICalendarStepSize Calendar(int count, CalendarStepSizeUnit unit) => new CalendarStepSize(count, unit, CalendarComposer);

    /// <inheritdoc cref="IAngularStepSizeFactory.Create(Angle)"/>
    public IAngularStepSize Angular(Angle deltaAngle) => new AngularStepSize(deltaAngle, AngularComposer);

    IFixedStepSize IFixedStepSizeFactory.Create(Time deltaTime) => Fixed(deltaTime);
    IUniformStepSize IUniformStepSizeFactory.Create(int stepCount) => Uniform(stepCount);
    ICalendarStepSize ICalendarStepSizeFactory.Create(int count, CalendarStepSizeUnit unit) => Calendar(count, unit);
    IAngularStepSize IAngularStepSizeFactory.Create(Angle deltaAngle) => Angular(deltaAngle);
}
