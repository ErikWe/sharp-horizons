﻿namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query;
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

/// <summary>Represents the header of the <see cref="QueryResult"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsHeader : IEphemerisHeader
{
    /// <summary>Describes the <see cref="Query.OutputUnits"/> used in the <see cref="QueryResult"/>.</summary>
    public abstract OutputUnits OutputUnits { get; }

    /// <summary>Describes what <see cref="VectorCorrection"/> were applied to the <see cref="QueryResult"/>.</summary>
    public abstract VectorCorrection Correction { get; }

    /// <summary>Describes the <see cref="VectorTableContent"/> of the <see cref="QueryResult"/>.</summary>
    public abstract VectorTableContent TableContent { get; }

    /// <summary>Describes the <see cref="Query.ReferencePlane"/> used in the <see cref="QueryResult"/>.</summary>
    public abstract ReferencePlane ReferencePlane { get; }
}
