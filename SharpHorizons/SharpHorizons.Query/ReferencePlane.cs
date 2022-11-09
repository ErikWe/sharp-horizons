namespace SharpHorizons.Query;

/// <summary>Specifies what reference plane is used in the result of a query.</summary>
public enum ReferencePlane
{
    /// <summary>The ecliptic, the orbit of Earth around the Sun.</summary>
    Ecliptic,
    /// <summary>The unaltered <see cref="ReferenceSystem"/>.</summary>
    Frame,
    /// <summary>The equator of the origin object.</summary>
    BodyEquator
}
