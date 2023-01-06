namespace SharpHorizons.Query;

using SharpHorizons.Query.Epoch;

/// <summary>Specifies whether the difference between <see cref="TimeSystem.TDB"/> and <see cref="TimeSystem.UT"/> is included in the result of a query.</summary>
public enum TimeDeltaInclusion
{
    /// <summary>The difference between<see cref="TimeSystem.TDB"/> and <see cref="TimeSystem.UT"/> is not included in the result of a query.</summary>
    Disable,
    /// <summary>The difference between<see cref="TimeSystem.TDB"/> and <see cref="TimeSystem.UT"/> is included in the result of a query.</summary>
    Enable
}
