namespace SharpHorizons.Query.Vectors.Table;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

using System;

/// <summary>Specifies what quantities are included in the result of a <see cref="IVectorsQuery"/>.</summary>
[Flags]
public enum VectorTableQuantities
{
    /// <summary>No quantites are included.</summary>
    None = 0,
    /// <summary>Include the <see cref="Position3"/> of the object.</summary>
    Position = 1,
    /// <summary>Include the <see cref="Velocity3"/> of the object.</summary>
    Velocity = 2,
    /// <summary>Include information about the <see cref="SharpMeasures.Distance"/> to the object.</summary>
    Distance = 4,
    /// <summary>Include the <see cref="IOrbitalStateVectors"/> - the <see cref="Position3"/> and <see cref="Velocity3"/> of the object.</summary>
    StateVectors = Position | Velocity,
    /// <summary>Include the <see cref="IOrbitalStateVectors"/> and information about the <see cref="SharpMeasures.Distance"/> to the object.</summary>
    All = StateVectors | Distance
}
