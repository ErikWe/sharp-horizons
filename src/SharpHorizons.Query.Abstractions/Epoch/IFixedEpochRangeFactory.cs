namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with a fixed <see cref="Time"/>-based <see cref="IStepSize"/>.</summary>
public interface IFixedEpochRangeFactory : IEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, and a fixed <see cref="IStepSize"/> <paramref name="deltaTime"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="deltaTime"><inheritdoc cref="IFixedStepSize.DeltaTime" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime);
}
