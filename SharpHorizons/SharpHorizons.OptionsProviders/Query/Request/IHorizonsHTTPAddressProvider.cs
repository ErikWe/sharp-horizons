namespace SharpHorizons.Query.Request;

using System;

/// <summary>Provides the HTTP address of the Horizons API.</summary>
public interface IHorizonsHTTPAddressProvider
{
    /// <summary>The <see cref="Uri"/> describing the HTTP address of the Horizons API.</summary>
    public abstract Uri HTTPAddress { get; }
}
