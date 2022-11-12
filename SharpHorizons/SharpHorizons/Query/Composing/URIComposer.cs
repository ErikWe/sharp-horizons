namespace SharpHorizons.Query.Composing;

using SharpHorizons.Query;

using System;

/// <inheritdoc cref="IURIComposer"/>
internal sealed class URIComposer : IURIComposer
{
    /// <summary><inheritdoc cref="IAPIAddressProvider" path="/summary"/></summary>
    private IAPIAddressProvider APIAddressProvider { get; }

    /// <summary><inheritdoc cref="URIComposer" path="/summary"/></summary>
    /// <param name="apiAddressProvider"><inheritdoc cref="IAPIAddressProvider" path="/summary"/></param>
    public URIComposer(IAPIAddressProvider apiAddressProvider)
    {
        APIAddressProvider = apiAddressProvider;
    }

    Uri IURIComposer.Compose(HorizonsQueryString query) => new(APIAddressProvider.Address, $"?{query}");
}
