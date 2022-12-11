namespace SharpHorizons.Settings.Query;

using Microsoft.Extensions.Configuration;

/// <summary>Allows query-related options to be specified.</summary>
internal sealed class QueryOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="QueryOptions"/>.</summary>
    internal static string Section { get; } = "Query";

    /// <summary>The HTTP address of the Horizons API.</summary>
    public string HorizonsHTTPAddress { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="QueryOptions"/>.</param>
    public static void ApplyDefaults(QueryOptions options)
    {
        options.HorizonsHTTPAddress = DefaultQuerySettings.Default.HorizonsHTTPAddress;
    }
}
