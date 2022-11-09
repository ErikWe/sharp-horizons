namespace SharpHorizons.Query;

/// <summary>Specifies an ephemeris type.</summary>
public enum EphemerisType
{
    /// <summary>Ephemeris of observable states.</summary>
    Observables,
    /// <summary>Ephemeris of orbital state vectors.</summary>
    Vectors,
    /// <summary>Ephemeris of osculating orbital elements.</summary>
    Elements,
    /// <summary>Ephemeris of close approaches.</summary>
    CloseApproach
}