namespace SharpHorizons.Query;

using System;

/// <summary>Specifies what corrections to apply to the result of a query for orbital state vectors.</summary>
public enum VectorCorrection
{
    /// <summary>No correction is applied - the 'true', instantaneous geometric vectors.</summary>
    None,
    /// <summary>Corrects for the time required for light to travel from the target to the origin - the astrometric vectors.</summary>
    LightTime,
    /// <summary>Corrects for the time required for light to travel from the target to the origin and for the effects of aberration - the apparent vectors.</summary>
    LightTimeAndAberration
}
