namespace SharpHorizons.Settings.Query;

using Microsoft.Extensions.Configuration;

/// <summary>Allows options related to queries to be specified.</summary>
internal sealed class QueryOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="QueryOptions"/>.</summary>
    internal static string Section { get; } = "Query";

    /// <summary>The HTTP address of the Horizons API.</summary>
    public string HorizonsHTTPAddress { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="QueryOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="QueryOptions"/>.</param>
    public static void ApplyDefaults(QueryOptions options)
    {
        options.HorizonsHTTPAddress = DefaultQuerySettings.Default.HorizonsHTTPAddress;
    }
}
