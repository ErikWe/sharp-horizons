namespace SharpHorizons.Query;

/// <summary>Specifies the reference plane used to express orbital state vectors and orbital elements. Used together with <see cref="ReferenceSystem"/> to determine the coordinate basis.</summary>
public enum ReferencePlane
{
    /// <summary>The ecliptic, the orbit of Earth around the Sun.</summary>
    Ecliptic,
    /// <summary>The unaltered <see cref="ReferenceSystem"/>.</summary>
    Frame,
    /// <summary>The equator of the origin object.</summary>
    BodyEquator
}
