namespace SharpHorizons.Query.Epoch;

/// <summary>Specifies in what time-system <see cref="IEpoch"/> are expressed in a query.</summary>
public enum TimeSystem
{
    /// <summary>The <see cref="TimeSystem"/> is unknown.</summary>
    Unknown,
    /// <summary><see cref="IEpoch"/> are expressed in UT, Universal Time.</summary>
    UT,
    /// <summary><see cref="IEpoch"/> are expressed in TT, Terrestial Time.</summary>
    TT,
    /// <summary><see cref="IEpoch"/> are expressed in TDB, Barycentric Dynamical Time.</summary>
    TDB
}
