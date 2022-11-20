namespace SharpHorizons.Query.Request;

using System;
using SharpHorizons.Query.Request.HTTP;

/// <inheritdoc cref="IURIComposer"/>
internal sealed class URIComposer : IURIComposer
{
    /// <summary><inheritdoc cref="IHorizonsHTTPAddressProvider" path="/summary"/></summary>
    private IHorizonsHTTPAddressProvider APIAddressProvider { get; }

    /// <inheritdoc cref="URIComposer"/>
    /// <param name="apiAddressProvider"><inheritdoc cref="IHorizonsHTTPAddressProvider" path="/summary"/></param>
    public URIComposer(IHorizonsHTTPAddressProvider apiAddressProvider)
    {
        APIAddressProvider = apiAddressProvider;
    }

    HorizonsQueryURI IURIComposer.Compose(HorizonsQueryString query) => new Uri(APIAddressProvider.HTTPAddress, $"?{query}");
}
