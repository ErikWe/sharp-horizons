namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents the uncertainty in the <see cref="Position3"/> of an object in the along-track, cross-track, and normal directions at some <see cref="IEpoch"/>.</summary>
public interface IObjectPositionUncertaintyACN : IVectorsEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> of the object in the along-track direction.</summary>
    public abstract Distance AlongTrack { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> of the object in the cross-track direction.</summary>
    public abstract Distance CrossTrack { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> of the object in the normal direction.</summary>
    public abstract Distance Normal { get; }
}
