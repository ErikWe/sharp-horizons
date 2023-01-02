namespace SharpHorizons.Query.Epoch;

using System;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with an <see cref="int"/> number of uniformly distributed steps.</summary>
public interface IUniformEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with <paramref name="stepCount"/> uniformly distributed steps.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="stepCount"><inheritdoc cref="IUniformStepSize.StepCount" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, int stepCount);
}
