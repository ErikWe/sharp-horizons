namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Uses the timespan between two <see cref="IEpoch"/> and an associated <see cref="IStepSize"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
public sealed record class EpochRange : IEpochSelection
{
    /// <summary>The start-point of the timespan, with <see cref="StopEpoch"/> representing the stop-point.</summary>
    public IEpoch StartEpoch { get; }
    /// <summary>The stop-point of the timespan, with <see cref="StartEpoch"/> representing the start-point.</summary>
    public IEpoch StopEpoch { get; }

    /// <summary>The <see cref="IStepSize"/>, describing the difference between each <see cref="IEpoch"/> in the selection.</summary>
    public IStepSize StepSize { get; }

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/> with the associated <paramref name="stepSize"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    private EpochRange(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);
        ArgumentNullException.ThrowIfNull(stepSize);

        StartEpoch = startEpoch;
        StopEpoch = stopEpoch;

        StepSize = stepSize;
    }

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/> with a fixed <see cref="IStepSize"/> <paramref name="deltaTime"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="deltaTime"><inheritdoc cref="FixedStepSize.DeltaTime" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public static EpochRange Fixed(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) => new(startEpoch, stopEpoch, new FixedStepSize(deltaTime));

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/> with a total of <paramref name="stepCount"/> uniformly distributed steps to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="stepCount"><inheritdoc cref="UniformStepSize.StepCount" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public static EpochRange Uniform(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) => new(startEpoch, stopEpoch, new UniformStepSize(stepCount));

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with a non-uniform <see cref="IStepSize"/> such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>, to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <remarks>To use a uniform calendar-related unit, such as days or weeks, use <see cref="Fixed(IEpoch, IEpoch, Time)"/>.</remarks>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static EpochRange Calendar(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) => new(startEpoch, stopEpoch, new CalendarStepSize(count, unit));

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with non-uniform steps that each correspond to a change <paramref name="deltaAngle"/> in the position of the target object, to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="deltaAngle"><inheritdoc cref="AngularStepSize.DeltaAngle" path="/summary"/></param>
    /// <remarks>An angular step-size is only supported in queries for observational state.</remarks>
    /// <exception cref="ArgumentNullException"/>
    public static EpochRange Angular(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) => new(startEpoch, stopEpoch, new AngularStepSize(deltaAngle));

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Range;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Collection);
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Collection);
    IStartTimeArgument IEpochSelection.ComposeStartTimeArgument() => StartTimeArgument.Compose(StartEpoch);
    IStopTimeArgument IEpochSelection.ComposeStopTimeArgument() => StopTimeArgument.Compose(StopEpoch);
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => StepSize.ComposeArgument();
}