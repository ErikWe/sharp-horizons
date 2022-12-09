namespace SharpHorizons.Query;

using SharpMeasures;

/// <summary>Specifies with what precision <see cref="Time"/> is expressed in a query and in the result of a query.</summary>
public enum TimePrecision
{
    /// <summary>The <see cref="TimePrecision"/> is unknown.</summary>
    Unknown,
    /// <summary><see cref="Time"/> is expressed with <see cref="UnitOfTime.Minute"/>-level precision.</summary>
    Minute,
    /// <summary><see cref="Time"/> is expressed with <see cref="UnitOfTime.Second"/>-level precision.</summary>
    Second,
    /// <summary><see cref="Time"/> is expressed with <see cref="UnitOfTime.Millisecond"/>-level precision.</summary>
    Millisecond
}
