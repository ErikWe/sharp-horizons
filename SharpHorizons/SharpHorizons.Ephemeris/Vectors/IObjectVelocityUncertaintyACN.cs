namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents the uncertainty in the <see cref="Velocity3"/> of an object in the along-track, cross-track, and normal directions at some <see cref="IEpoch"/>.</summary>
public interface IObjectVelocityUncertaintyACN : IVectorsEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the along-track direction.</summary>
    public abstract Speed AlongTrack { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the cross-track direction.</summary>
    public abstract Speed CrossTrack { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the normal direction.</summary>
    public abstract Speed Normal { get; }
}
