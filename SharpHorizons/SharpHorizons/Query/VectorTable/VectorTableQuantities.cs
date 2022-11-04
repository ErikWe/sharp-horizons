namespace SharpHorizons.Query.VectorTable;

using SharpHorizons.Vectors;

using SharpMeasures;

using System;

/// <summary>Specifies what quantities are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
/// <remarks>Only the following combinations are supported by Horizons:
/// <list type="bullet">
/// <item><see cref="Position"/></item>
/// <item><see cref="Velocity"/></item>
/// <item><see cref="Distance"/></item>
/// <item><see cref="Position"/> | <see cref="Velocity"/></item>
/// <item><see cref="Position"/> | <see cref="Distance"/></item>
/// <item><see cref="Position"/> | <see cref="Velocity"/> | <see cref="Distance"/></item>
/// </list></remarks>
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
    /// <summary>Include the <see cref="OrbitalStateVectors"/> - the <see cref="Position3"/> and <see cref="Velocity3"/> of the object.</summary>
    StateVectors = Position | Velocity,
    /// <summary>Include the <see cref="OrbitalStateVectors"/> and information about the <see cref="SharpMeasures.Distance"/> to the object.</summary>
    All = StateVectors | Distance
}