namespace SharpHorizons.Query.Request;

using Microsoft.Extensions.Options;

using System;

/// <inheritdoc cref="IHorizonsHTTPAddressProvider"/>
internal sealed class HorizonsHTTPAddressProvider : IHorizonsHTTPAddressProvider
{
    public Uri HTTPAddress { get; }

    /// <summary><inheritdoc cref="HorizonsHTTPAddressProvider" path="/summary"/></summary>
    /// <param name="queryOptions">Provides the <see cref="QueryOptions"/>.</param>
    public HorizonsHTTPAddressProvider(IOptions<QueryOptions> queryOptions)
    {
        HTTPAddress = new(queryOptions.Value.HorizonsHTTPAddress);
    }
}
