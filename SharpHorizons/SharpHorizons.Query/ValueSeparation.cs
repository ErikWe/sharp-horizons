namespace SharpHorizons.Query;

/// <summary>Specifies how values are separated in the result of a query.</summary>
public enum ValueSeparation
{
    /// <summary>The <see cref="ValueSeparation"/> is unknown.</summary>
    Unknown,
    /// <summary>Values are separated by commas.</summary>
    CommaSeparation,
    /// <summary>Values are separated by whitespaces.</summary>
    WhitespaceSeparation
}
