namespace SharpHorizons.Query.Vectors;

using System;

/// <summary>Specifies what corrections are applied to the result of a <see cref="IVectorsQuery"/>.</summary>
[Flags]
public enum VectorCorrection
{
    /// <summary>Applies no corrections - the 'true', instantaneous geometric vectors.</summary>
    None = 0,
    /// <summary>Corrects for the time required for light to travel from the target to the origin - the astrometric vectors.</summary>
    LightTime = 1,
    /// <summary>Corrects for the effects of stellar aberration.</summary>
    /// <remarks>Horizons does not support <see cref="Aberration"/> without <see cref="LightTime"/>.</remarks>
    Aberration = 2,
    /// <summary>Applies all corrections - the apparent vectors.</summary>
    All = LightTime | Aberration,
}
