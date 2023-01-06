namespace SharpHorizons.Query.Request;

using SharpHorizons.Query.Request.HTTP;

using System;

/// <inheritdoc cref="IURIComposer"/>
internal sealed class URIComposer : IURIComposer
{
    /// <inheritdoc cref="IHorizonsHTTPAddressProvider"/>
    private IHorizonsHTTPAddressProvider APIAddressProvider { get; }

    /// <inheritdoc cref="URIComposer"/>
    /// <param name="apiAddressProvider"><inheritdoc cref="IHorizonsHTTPAddressProvider" path="/summary"/></param>
    public URIComposer(IHorizonsHTTPAddressProvider apiAddressProvider)
    {
        APIAddressProvider = apiAddressProvider;
    }

    HorizonsQueryURI IURIComposer.Compose(HorizonsQueryString query)
    {
        HorizonsQueryString.Validate(query);

        return new(new Uri(APIAddressProvider.HTTPAddress, $"?{query}"));
    }
}
