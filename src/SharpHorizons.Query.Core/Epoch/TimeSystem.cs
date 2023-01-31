namespace SharpHorizons.Query.Epoch;

/// <summary>Specifies in what time-system <see cref="IEpoch"/> are expressed in a query.</summary>
public enum TimeSystem
{
    /// <summary>The <see cref="TimeSystem"/> is unknown.</summary>
    Unknown,
    /// <summary><see cref="IEpoch"/> are expressed in Universal Time (UT).</summary>
    UniversalTime,
    /// <summary><see cref="IEpoch"/> are expressed in Terrestial Time (TT).</summary>
    TerrestialTime,
    /// <summary><see cref="IEpoch"/> are expressed in Barycentric Dynamical Time (TDB).</summary>
    BarycentricDynamicalTime
}
