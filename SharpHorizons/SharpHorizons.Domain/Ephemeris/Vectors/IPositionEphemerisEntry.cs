namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Epoch;

using SharpMeasures;

/// <summary>Represents the <see cref="Position3"/> of an object at an <see cref="IEpoch"/>.</summary>
public interface IPositionEphemerisEntry : IEphemerisEntry
{
    /// <summary>The <see cref="Position3"/> of the object relative.</summary>
    public abstract Position3 Position { get; }
}