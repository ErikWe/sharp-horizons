namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Velocity3"/> of an object in the radial, transverse, and normal directions at some <see cref="IEpoch"/>.</summary>
public interface IObjectVelocityUncertaintyRTN : IVectorsEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the radial direction.</summary>
    public abstract Speed Radial { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the transverse direction.</summary>
    public abstract Speed Transverse { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the normal direction.</summary>
    public abstract Speed Normal { get; }
}
