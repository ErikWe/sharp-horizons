namespace SharpHorizons.Query;

/// <summary>Specifies the format of the result of a query.</summary>
public enum OutputFormat
{
    /// <summary>The <see cref="OutputFormat"/> is unknown.</summary>
    Unknown,
    /// <summary>The result of a query is formatted as raw text.</summary>
    Text,
    /// <summary>The result of a query is formatted as JSON.</summary>
    JSON
}
