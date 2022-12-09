namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>Provides means of selecting the <see cref="IEpoch"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface IEpochStage
{
    /// <summary>Uses <paramref name="epochSelection"/> as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochSelection">The <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithEpochs(IEpochSelection epochSelection);

    /// <summary>Selects <paramref name="epochs"/> as the <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochs">The <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <param name="format">The <see cref="EpochFormat"/> of the individual <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithEpochs(IEnumerable<IEpoch> epochs, EpochFormat format);

    /// <summary>Selects <paramref name="epochs"/> as the <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochs">The <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithEpochs(IEnumerable<IEpoch> epochs);

    /// <summary>Selects <paramref name="epochs"/> as the <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochs">The <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <param name="format">The <see cref="EpochFormat"/> of the individual <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithEpochs(EpochFormat format, params IEpoch[] epochs);

    /// <summary>Selects <paramref name="epochs"/> as the <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochs">The <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithEpochs(params IEpoch[] epochs);

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/> with a fixed <see cref="IStepSize"/> <paramref name="deltaTime"/> to describe the selection of <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="deltaTime"><inheritdoc cref="IFixedStepSize.DeltaTime" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithFixedEpochRange(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime);

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/> with a total of <paramref name="stepCount"/> uniformly distributed steps to describe the selection of <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="stepCount"><inheritdoc cref="IUniformStepSize.StepCount" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IVectorsQuery WithUniformEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int stepCount);

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with a non-uniform <see cref="IStepSize"/> such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>, to describe the selection of <see cref="IEpoch"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="startEpoch">The start-point of the timespan, with <paramref name="stopEpoch"/> representing the stop-point.</param>
    /// <param name="stopEpoch">The stop-point of the timespan, with <paramref name="startEpoch"/> representing the start-point.</param>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <remarks>To use a uniform calendar-related unit, such as days or weeks, use <see cref="WithFixedEpochRange(IEpoch, IEpoch, Time)"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithCalendarEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit);
}
