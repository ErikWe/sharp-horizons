namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Position3"/> of an object in the radial, right-ascension, and declination directions at some <see cref="IEpoch"/>.</summary>
public interface IPositionalUncertaintyPOS : IEphemerisEntry
{
    /// <summary>The optional 1σ-uncertainty in the <see cref="Position3"/> in the radial, right-ascension, and declination directions.</summary>
    public abstract Displacement3 UncertaintyPOS { get; }
}
