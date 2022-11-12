namespace SharpHorizons.Query;

using Microsoft.Extensions.Configuration;

/// <summary>Allows query-related options to be specified.</summary>
internal sealed class QueryOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> describing <see cref="QueryOptions"/>.</summary>
    internal static string Section { get; } = "Query";

    /// <summary>The address of the Horizons API.</summary>
    public string APIAddress { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="QueryOptions"/>.</param>
    internal static void ApplyDefaults(QueryOptions options)
    {
        options.APIAddress = DefaultQuerySettings.Default.APIAddress;
    }
}
