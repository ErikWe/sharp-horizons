namespace SharpHorizons.Query;

/// <summary>Specifies whether the difference between Barycentric Dynamical Time (TDB) and Universal Time (UT) is included in a query result.</summary>
public enum TimeDeltaInclusion
{
    /// <summary>The difference between TDB and UT is not included.</summary>
    Disable,
    /// <summary>The difference between TDB and UT is included.</summary>
    Enable
}