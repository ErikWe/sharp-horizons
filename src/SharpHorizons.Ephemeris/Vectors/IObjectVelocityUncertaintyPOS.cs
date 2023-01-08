namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Velocity3"/> of an object in the radial, right-ascension, and declination directions at some <see cref="IEpoch"/>.</summary>
public interface IObjectVelocityUncertaintyPOS : IVectorsEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the radial direction.</summary>
    public abstract Speed Radial { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the right-ascension direction.</summary>
    public abstract Speed RightAscension { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the declination direction.</summary>
    public abstract Speed Declination { get; }
}
