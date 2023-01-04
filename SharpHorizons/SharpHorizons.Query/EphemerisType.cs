namespace SharpHorizons.Query;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Elements;
using SharpHorizons.Ephemeris.Vectors;

/// <summary>Specifies the type of <see cref="IEphemeris{TEntry}"/> that is generated.</summary>
public enum EphemerisType
{
    /// <summary>The <see cref="EphemerisType"/> is unknown.</summary>
    Unknown,
    /// <summary>An <see cref="IEphemeris{TEntry}"/> of observable states is generated.</summary>
    Observables,
    /// <summary>An <see cref="IEphemeris{TEntry}"/> of <see cref="IOrbitalStateVectors"/>-related properties is generated.</summary>
    Vectors,
    /// <summary>An <see cref="IEphemeris{TEntry}"/> of <see cref="IOsculatingOrbitalElements"/>-related properties is generated.</summary>
    Elements,
    /// <summary>An <see cref="IEphemeris{TEntry}"/> of close approaches is generated.</summary>
    CloseApproach
}
