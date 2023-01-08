namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Describes the uncertainty in the <see cref="Position3"/> of an object in the radial, transverse, and normal directions at some <see cref="IEpoch"/>.</summary>
public interface IObjectPositionUncertaintyRTN : IVectorsEphemerisEntry
{
    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> of the object in the radial direction.</summary>
    public abstract Distance Radial { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> of the object in the transverse direction.</summary>
    public abstract Distance Transverse { get; }

    /// <summary>The 1σ-uncertainty in the <see cref="Position3"/> of the object in the normal direction.</summary>
    public abstract Distance Normal { get; }
}
