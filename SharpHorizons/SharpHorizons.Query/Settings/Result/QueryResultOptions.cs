namespace SharpHorizons.Settings.Query.Result;

using Microsoft.Extensions.Configuration;

/// <summary>Allows options related to query results to be specified.</summary>
internal sealed class QueryResultOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="QueryResultOptions"/>.</summary>
    internal static string Section { get; } = "Query:Result";

    /// <summary>The key corresponding to the source in a response formatted as raw text.</summary>
    public string RawTextSource { get; set; } = null!;

    /// <summary>The key corresponding to the version in a response formatted as raw text.</summary>
    public string RawTextVersion { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="QueryResultOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="QueryResultOptions"/>.</param>
    public static void ApplyDefaults(QueryResultOptions options)
    {
        options.RawTextSource = DefaultQueryResultSettings.Default.RawTextSource;
        options.RawTextVersion = DefaultQueryResultSettings.Default.RawTextVersion;
    }
}
