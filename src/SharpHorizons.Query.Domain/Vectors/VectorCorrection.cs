namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

using System;

/// <summary>Specifies what corrections are applied to the result of a <see cref="IVectorsQuery"/>.</summary>
[Flags]
public enum VectorCorrection
{
    /// <summary>No correction is applied to the result of a <see cref="IVectorsQuery"/>.</summary>
    None = 0,
    /// <summary>Applies corrections accounting for the <see cref="Time"/> required for light to travel from the <see cref="ITarget"/> to the <see cref="IOrigin"/>.</summary>
    LightTime = 1,
    /// <summary>Applies corrections accounting for the effects of stellar aberration.</summary>
    /// <remarks>Horizons does not support <see cref="Aberration"/> without <see cref="LightTime"/>.</remarks>
    Aberration = 2,
    /// <summary>Applies corrections accounting for stellar aberration and for the <see cref="Time"/> required for light to travel from the <see cref="ITarget"/> to the <see cref="IOrigin"/>.</summary>
    All = LightTime | Aberration,
}
