namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

/// <summary>Handles construction of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryFactory
{
    /// <summary>Constructs a <see cref="IVectorsQuery"/> describing a query for the <see cref="IOrbitalStateVectors"/> of <paramref name="target"/> relative to <paramref name="origin"/> at <paramref name="epochs"/>.</summary>
    /// <param name="target"><inheritdoc cref="IVectorsQuery.Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="IVectorsQuery.Origin" path="/summary"/></param>
    /// <param name="epochs"><inheritdoc cref="IVectorsQuery.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery Build(ITarget target, IOrigin origin, IEpochSelection epochs);

    /// <summary>Start the processes of fluently defining a <see cref="IVectorsQuery"/>.</summary>
    public abstract ITargetStage Fluent();
}