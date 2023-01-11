namespace SharpHorizons.Query;

/// <summary>Specifies what reference system is used in the result of a query.</summary>
public enum ReferenceSystem
{
    /// <summary>The <see cref="ReferenceSystem"/> is unknown.</summary>
    Unknown,
    /// <summary>ICRF, the International Celestial Reference Frame, is used in the result of a query.</summary>
    ICRF,
    /// <summary>The Earth mean equator and equinox of the Besselian epoch B1950 is used as the <see cref="ReferenceSystem"/> in the result of a query.</summary>
    B1950
}
