namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents the <see cref="Position3"/> of an object at some <see cref="IEpoch"/>.</summary>
public interface IObjectPosition : IVectorsEphemerisEntry
{
    /// <summary>The <see cref="Position3"/> of the object.</summary>
    public abstract Position3 Position { get; }
}
