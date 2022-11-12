namespace SharpHorizons.Query;

using System;

/// <summary>Provides the address of the Horizons API.</summary>
public interface IAPIAddressProvider
{
    /// <summary>The <see cref="Uri"/> describing the address of the Horizons API.</summary>
    public abstract Uri Address { get; }
}
