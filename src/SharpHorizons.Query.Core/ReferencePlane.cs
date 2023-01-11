namespace SharpHorizons.Query;

using SharpHorizons.Query.Origin;

/// <summary>Specifies what reference plane is used in the result of a query.</summary>
public enum ReferencePlane
{
    /// <summary>The <see cref="ReferencePlane"/> is unknown.</summary>
    Unknown,
    /// <summary>The ecliptic, the orbit of Earth around the Sun, is used as the <see cref="ReferencePlane"/> in the result of a query.</summary>
    Ecliptic,
    /// <summary>The unaltered <see cref="ReferenceSystem"/> is used as the <see cref="ReferencePlane"/> in the result of a query.</summary>
    Frame,
    /// <summary>The equator of the <see cref="IOrigin"/> is used as the <see cref="ReferencePlane"/> in the result of a query.</summary>
    BodyEquator
}
