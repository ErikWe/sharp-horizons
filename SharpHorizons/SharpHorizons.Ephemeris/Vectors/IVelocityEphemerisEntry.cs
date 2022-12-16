namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents the <see cref="Velocity3"/> of an object at some <see cref="IEpoch"/>.</summary>
public interface IVelocityEphemerisEntry : IVectorsEphemerisEntry
{
    /// <summary>The <see cref="Velocity3"/> of the object.</summary>
    public abstract Velocity3 Velocity { get; }
}
