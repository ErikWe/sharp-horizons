namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <summary>Handles construction of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryFactory
{
    /// <summary>Constructs a <see cref="IVectorsQuery"/>, describing a query for an <see cref="IEphemeris{TEntry}"/> of <see cref="IOrbitalStateVectors"/>-related properties of <paramref name="target"/> relative to <paramref name="origin"/> at some <see cref="IEpoch"/> described by <paramref name="epochSelection"/>.</summary>
    /// <param name="target"><inheritdoc cref="IVectorsQuery.Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="IVectorsQuery.Origin" path="/summary"/></param>
    /// <param name="epochSelection"><inheritdoc cref="IVectorsQuery.EpochSelection" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery Create(ITarget target, IOrigin origin, IEpochSelection epochSelection);
}
