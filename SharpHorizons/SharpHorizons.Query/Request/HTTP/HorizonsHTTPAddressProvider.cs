namespace SharpHorizons.Query.Request.HTTP;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Query;

using System;

/// <inheritdoc cref="IHorizonsHTTPAddressProvider"/>
internal sealed class HorizonsHTTPAddressProvider : IHorizonsHTTPAddressProvider
{
    public Uri HTTPAddress { get; }

    /// <inheritdoc cref="HorizonsHTTPAddressProvider"/>
    /// <param name="queryOptions">Provides the <see cref="QueryOptions"/>.</param>
    public HorizonsHTTPAddressProvider(IOptions<QueryOptions> queryOptions)
    {
        HTTPAddress = new(queryOptions.Value.HorizonsHTTPAddress);
    }
}
