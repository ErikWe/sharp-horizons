namespace SharpHorizons.Query;

/// <summary>Specifies what corrections are applied to a query result for orbital state vectors.</summary>
public enum VectorCorrection
{
    /// <summary>Applies no corrections - the 'true', instantaneous geometric vectors.</summary>
    None,
    /// <summary>Applies corrections for the time required for light to travel from the target to the origin - the astrometric vectors.</summary>
    LightTime,
    /// <summary>Applies corrections for the time required for light to travel from the target to the origin and for the effects of aberration - the apparent vectors.</summary>
    LightTimeAndAberration
}
