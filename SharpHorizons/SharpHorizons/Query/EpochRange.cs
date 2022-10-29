namespace SharpHorizons.Query;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System.ComponentModel;

/// <summary>Uses the timespan between two <see cref="IEpoch"/> and an associated <see cref="IStepSize"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
public sealed record class EpochRange : IEpochSelection
{
    /// <summary>The start-point of the timespan, with <see cref="Stop"/> representing the stop-point.</summary>
    public IEpoch Start { get; }
    /// <summary>The stop-point of the timespan, with <see cref="Start"/> representing the start-point.</summary>
    public IEpoch Stop { get; }

    /// <summary>The <see cref="IStepSize"/>, describing the difference between each <see cref="IEpoch"/> in the selection.</summary>
    public IStepSize StepSize { get; }

    /// <summary>Uses the timespan between <paramref name="start"/> and <paramref name="stop"/> with the associated <paramref name="stepSize"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="start">The start-point of the timespan, with <paramref name="stop"/> representing the stop-point.</param>
    /// <param name="stop">The stop-point of the timespan, with <paramref name="start"/> representing the start-point.</param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    private EpochRange(IEpoch start, IEpoch stop, IStepSize stepSize)
    {
        Start = start;
        Stop = stop;

        StepSize = stepSize;
    }

    /// <summary>Uses the timespan between <paramref name="start"/> and <paramref name="stop"/> with a fixed <see cref="IStepSize"/> <paramref name="deltaTime"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="start">The start-point of the timespan, with <paramref name="stop"/> representing the stop-point.</param>
    /// <param name="stop">The stop-point of the timespan, with <paramref name="start"/> representing the start-point.</param>
    /// <param name="deltaTime"><inheritdoc cref="FixedStepSize.DeltaTime" path="/summary"/></param>
    public static EpochRange Fixed(IEpoch start, IEpoch stop, Time deltaTime) => new(start, stop, new FixedStepSize(deltaTime));

    /// <summary>Uses the timespan between <paramref name="start"/> and <paramref name="stop"/> with a total of <paramref name="stepCount"/> uniformly distributed steps to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="start">The start-point of the timespan, with <paramref name="stop"/> representing the stop-point.</param>
    /// <param name="stop">The stop-point of the timespan, with <paramref name="start"/> representing the start-point.</param>
    /// <param name="stepCount"><inheritdoc cref="UniformStepSize.StepCount" path="/summary"/></param>
    public static EpochRange Uniform(IEpoch start, IEpoch stop, int stepCount) => new(start, stop, new UniformStepSize(stepCount));

    /// <summary>Uses the timespan between <paramref name="start"/> and <paramref name="stop"/>, with a non-uniform <see cref="IStepSize"/> such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>, to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="start">The start-point of the timespan, with <paramref name="stop"/> representing the stop-point.</param>
    /// <param name="stop">The stop-point of the timespan, with <paramref name="start"/> representing the start-point.</param>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <remarks>To use a uniform calendar-related unit, such as days or weeks, use <see cref="Fixed(IEpoch, IEpoch, Time)"/>.</remarks>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static EpochRange Calendar(IEpoch start, IEpoch stop, int count, CalendarStepSizeUnit unit) => new(start, stop, new CalendarStepSize(count, unit));

    /// <summary>Uses the timespan between <paramref name="start"/> and <paramref name="stop"/>, with non-uniform steps that each correspond to a change <paramref name="deltaAngle"/> in the position of the target object, to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="start">The start-point of the timespan, with <paramref name="stop"/> representing the stop-point.</param>
    /// <param name="stop">The stop-point of the timespan, with <paramref name="start"/> representing the start-point.</param>
    /// <param name="deltaAngle"><inheritdoc cref="AngularStepSize.DeltaAngle" path="/summary"/></param>
    /// <remarks>An angular step-size is only supported in queries for observational state.</remarks>
    public static EpochRange Angular(IEpoch start, IEpoch stop, Angle deltaAngle) => new(start, stop, new AngularStepSize(deltaAngle));

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Range;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Collection);
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Collection);
    IStartTimeArgument IEpochSelection.ComposeStartTimeArgument() => StartTimeArgument.Compose(Start);
    IStopTimeArgument IEpochSelection.ComposeStopTimeArgument() => StopTimeArgument.Compose(Stop);
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => StepSize.ComposeArgument();
}