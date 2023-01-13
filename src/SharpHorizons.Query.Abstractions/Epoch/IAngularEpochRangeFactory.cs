namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

using System;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with the <see cref="IStepSize"/> represented by the variable amount of time it takes for the position of some <see cref="ITarget"/> to change by some <see cref="Angle"/>, as seen from some <see cref="IOrigin"/>.</summary>
/// <remarks>An <see cref="IEpochRange"/> of this type is only supported in queries for observational state.</remarks>
public interface IAngularEpochRangeFactory : IEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with the <see cref="IStepSize"/> represented by the variable amount of time it takes for the position of some <see cref="ITarget"/> to change by <paramref name="deltaAngle"/>, as seen from some <see cref="IOrigin"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="deltaAngle"><inheritdoc cref="IAngularStepSize.DeltaAngle" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle);
}
