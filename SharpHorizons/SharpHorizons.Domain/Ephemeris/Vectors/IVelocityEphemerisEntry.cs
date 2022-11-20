namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Epoch;

using SharpMeasures;

/// <summary>Represents the <see cref="Velocity3"/> of an object at an <see cref="IEpoch"/>.</summary>
public interface IVelocityEphemerisEntry
{
    /// <summary>The <see cref="Velocity3"/> of the object.</summary>
    public abstract Velocity3 Velocity { get; }
}
