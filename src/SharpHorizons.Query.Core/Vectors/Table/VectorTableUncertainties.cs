﻿namespace SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

using System;

/// <summary>Specifies what uncertainties in the <see cref="Position3"/> of an object are included in the result of a <see cref="IVectorsQuery"/>.</summary>
[Flags]
public enum VectorTableUncertainties
{
    /// <summary>No uncertainties are included.</summary>
    None = 0,
    /// <summary>Includes uncertainties in the <see cref="Position3"/> in the Cartesian directions.</summary>
    XYZ = 1,
    /// <summary>Includes uncertainties in the <see cref="Position3"/> in the along-track, cross-track, and normal directions.</summary>
    ACN = 2,
    /// <summary>Includes uncertainties in the <see cref="Position3"/> in the radial, transverse, and normal directions.</summary>
    RTN = 4,
    /// <summary>Includes uncertainties in the <see cref="Position3"/> in the radial, right-ascension, and declination directions.</summary>
    POS = 8,
    /// <summary>Includs all available uncertainties.</summary>
    All = XYZ | ACN | RTN | POS
}
