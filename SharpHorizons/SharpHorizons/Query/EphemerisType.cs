namespace SharpHorizons.Query;

using SharpHorizons.Vectors;

/// <summary>Determines what type of ephemeris is generated.</summary>
public enum EphemerisType
{
    /// <summary>Generate ephemerides for observable states.</summary>
    Observables,
    /// <summary>Generate ephemerides for <see cref="OrbitalStateVectors"/>.</summary>
    Vectors,
    /// <summary>Generate ephemerides for osculating orbital elements.</summary>
    Elements,
    /// <summary>Generate ephemerides for close approaches.</summary>
    CloseApproach
}