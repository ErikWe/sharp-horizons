namespace SharpHorizons.Query;

using Microsoft.Extensions.Options;

using System;

/// <inheritdoc cref="IAPIAddressProvider"/>
internal sealed class APIAddressProvider : IAPIAddressProvider
{
    public Uri Address { get; }

    /// <summary><inheritdoc cref="APIAddressProvider" path="/summary"/></summary>
    /// <param name="queryOptions">Provides the <see cref="QueryOptions"/>.</param>
    public APIAddressProvider(IOptions<QueryOptions> queryOptions)
    {
        Address = new(queryOptions.Value.APIAddress);
    }
}
