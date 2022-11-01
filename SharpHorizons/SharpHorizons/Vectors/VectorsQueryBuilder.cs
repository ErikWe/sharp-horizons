namespace SharpHorizons.Vectors;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Vectors.Fluency;

using System;

/// <summary>Handles construction of a <see cref="IVectorsQuery"/>, describing a query for the <see cref="OrbitalStateVectors"/> of a <see cref="ITarget"/> relative to an <see cref="IOrigin"/> at some <see cref="IEpoch"/>.</summary>
public static class VectorsQueryBuilder
{
    /// <summary>Constructs a <see cref="IVectorsQuery"/> describing a query for the <see cref="OrbitalStateVectors"/> of <paramref name="target"/> relative to <paramref name="origin"/> at <paramref name="epochs"/>.</summary>
    /// <param name="target"><inheritdoc cref="VectorsQuery.Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="VectorsQuery.Origin" path="/summary"/></param>
    /// <param name="epochs"><inheritdoc cref="VectorsQuery.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public static IVectorsQuery Build(ITarget target, IOrigin origin, IEpochSelection epochs)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(origin);
        ArgumentNullException.ThrowIfNull(epochs);

        return new VectorsQuery(target, origin, epochs);
    }

    /// <summary>Start the processes of fluently defining a <see cref="IVectorsQuery"/>.</summary>
    public static ITargetStage Fluently() => new TargetStage();
}
