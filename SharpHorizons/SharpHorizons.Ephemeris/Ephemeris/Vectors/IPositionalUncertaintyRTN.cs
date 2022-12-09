namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Position3"/> of an object in the radial, transverse, and normal directions at some <see cref="IEpoch"/>.</summary>
public interface IPositionalUncertaintyRTN : IEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> in the radial, transverse, and normal directions.</summary>
    public abstract Displacement3 UncertaintyRTN { get; }
}
