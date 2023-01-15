namespace SharpHorizons.Settings.Query.HTTP;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to HTTP queries to be specified.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class HTTPQueryOptions
{
    /// <summary>The <see cref="string"/> HTTP address of the Horizons API.</summary>
    public string HorizonsHTTPAddress { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="HTTPQueryOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="HTTPQueryOptions"/>.</param>
    public static void ApplyDefaults(HTTPQueryOptions options)
    {
        options.HorizonsHTTPAddress = DefaultQuerySettings.Default.HorizonsHTTPAddress;
    }
}
