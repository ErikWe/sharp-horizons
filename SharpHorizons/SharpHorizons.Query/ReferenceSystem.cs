namespace SharpHorizons.Query;

/// <summary>Specifies what reference system is used in the result of a query.</summary>
public enum ReferenceSystem
{
    /// <summary>The <see cref="ReferenceSystem"/> is unknown.</summary>
    Unknown,
    /// <summary>ICRF, the International Celestial Reference Frame - very similar to J2000.</summary>
    ICRF,
    /// <summary>The Earth mean equator and equinox of the Besselian epoch B1950.</summary>
    B1950
}
