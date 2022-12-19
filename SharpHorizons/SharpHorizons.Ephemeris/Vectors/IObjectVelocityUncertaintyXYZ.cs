namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Velocity3"/> of an object in the Cartesian directions at some <see cref="IEpoch"/>.</summary>
public interface IObjectVelocityUncertaintyXYZ : IVectorsEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the Cartesian directions.</summary>
    public abstract Velocity3 UncertaintyXYZ { get; }
}
