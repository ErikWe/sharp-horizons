namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Epoch;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Position3"/> of an object in the Cartesian directions at an <see cref="IEpoch"/>.</summary>
public interface IPositionalUncertaintyXYZ : IEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> in the Cartesian directions.</summary>
    public abstract Displacement3 UncertaintyXYZ { get; }
}
