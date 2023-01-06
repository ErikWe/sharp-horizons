namespace SharpHorizons.Query;

using SharpMeasures;

/// <summary>Specifies with what precision <see cref="Time"/> is expressed in a query and in the associated result.</summary>
public enum TimePrecision
{
    /// <summary>The <see cref="TimePrecision"/> is unknown.</summary>
    Unknown,
    /// <summary><see cref="Time"/> is expressed with <see cref="UnitOfTime.Minute"/>-level precision in a query and in the associated result.</summary>
    Minute,
    /// <summary><see cref="Time"/> is expressed with <see cref="UnitOfTime.Second"/>-level precision in a query and in the associated result.</summary>
    Second,
    /// <summary><see cref="Time"/> is expressed with <see cref="UnitOfTime.Millisecond"/>-level precision in a query and in the associated result.</summary>
    Millisecond
}
