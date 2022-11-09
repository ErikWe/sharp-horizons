namespace SharpHorizons.Query.VectorTable;

using System;

/// <summary>Specifies what uncertainties are included in the result of a query for <see cref="IOrbitalStateVectors"/>.</summary>
[Flags]
public enum VectorTableUncertainties
{
    /// <summary>No uncertainties are included.</summary>
    None = 0,
    /// <summary>Includes uncertainties in the Cartesian directions.</summary>
    XYZ = 1,
    /// <summary>Includes uncertainties in the along-track, cross-track, and normal directions.</summary>
    ACN = 2,
    /// <summary>Includes uncertainties in the radial, transverse, and normal directions.</summary>
    RTN = 4,
    /// <summary>Includes uncertainties in the radial, right-ascension, and declination directions.</summary>
    POS = 8,
    /// <summary>Includs all available uncertainties.</summary>
    All = XYZ | ACN | RTN | POS
}