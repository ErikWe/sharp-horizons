namespace SharpHorizons.Query.Epoch;

using System;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, and some <see cref="IStepSize"/>.</summary>
public interface IEpochRangeFactory : IAngularEpochRangeFactory, ICalendarEpochRangeFactory, IFixedEpochRangeFactory, IUniformEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, and some <paramref name="stepSize"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="IEpochRange.StepSize" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize);
}
