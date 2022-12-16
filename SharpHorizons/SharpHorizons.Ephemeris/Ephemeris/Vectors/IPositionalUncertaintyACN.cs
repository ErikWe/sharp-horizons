namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents the uncertainty in the <see cref="Position3"/> of an object in the along-track, cross-track, and normal directions at some <see cref="IEpoch"/>.</summary>
public interface IPositionalUncertaintyACN : IEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> in the along-track, cross-track, and normal directions.</summary>
    public abstract Displacement3 UncertaintyACN { get; }
}
