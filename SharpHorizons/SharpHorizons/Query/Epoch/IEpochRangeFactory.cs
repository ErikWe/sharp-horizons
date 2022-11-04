namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with a fixed <see cref="Time"/>-based <see cref="IStepSize"/>.</summary>
public interface IFixedEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, and a fixed <see cref="IStepSize"/> <paramref name="deltaTime"/>.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="deltaTime"><inheritdoc cref="FixedStepSize.DeltaTime" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime);
}

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with an <see cref="int"/> number of uniformly distributed steps.</summary>
public interface IUniformEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with <paramref name="stepCount"/> uniformly distributed steps.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="stepCount"><inheritdoc cref="UniformStepSize.StepCount" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, int stepCount);
}

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with some calendar-based <see cref="IStepSize"/>.</summary>
/// <remarks>To construct <see cref="IEpochRange"/> using a non-variable calendar-related unit, such as days or weeks, use <see cref="IFixedEpochRangeFactory"/>.</remarks>
public interface ICalendarEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with a <see cref="IStepSize"/> such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit);
}

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with the <see cref="IStepSize"/> represented by the variable amount of time it takes for the position of a <see cref="ITarget"/> to change by some <see cref="Angle"/>, as seen from an <see cref="IOrigin"/>.</summary>
/// <remarks>An <see cref="IEpochRange"/> of this type is only supported in queries for observational state.</remarks>
public interface IAngularEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with the <see cref="IStepSize"/> represented by the variable amount of time it takes for the position of the <see cref="ITarget"/> to change by <paramref name="deltaAngle"/>, as seen from the <see cref="IOrigin"/>.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="deltaAngle"><inheritdoc cref="AngularStepSize.DeltaAngle" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle);
}
