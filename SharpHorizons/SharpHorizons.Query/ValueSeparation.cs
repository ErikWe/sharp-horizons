namespace SharpHorizons.Query;

/// <summary>Specifies how individual values are separated in the result of a query.</summary>
public enum ValueSeparation
{
    /// <summary>The <see cref="ValueSeparation"/> is unknown.</summary>
    Unknown,
    /// <summary>Individual values are separated by commas in the result of a query.</summary>
    CommaSeparation,
    /// <summary>Individual values are separated by whitespace in the result of a query.</summary>
    WhitespaceSeparation
}
