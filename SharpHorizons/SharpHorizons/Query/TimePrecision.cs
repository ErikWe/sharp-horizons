namespace SharpHorizons.Query;

/// <summary>Determines with what precision time is expressed in a query and in the result of a query.</summary>
public enum TimePrecision
{
    /// <summary>Time is expressed with minute-level precision.</summary>
    Minute,
    /// <summary>Time is expressed with second-level precision.</summary>
    Second,
    /// <summary>Time is expressed with millisecond-level precision.</summary>
    Millisecond
}