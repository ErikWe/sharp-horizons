﻿namespace SharpHorizons.Query.Request.HTTP;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Query.HTTP;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IHorizonsHTTPAddressProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class HorizonsHTTPAddressProvider : IHorizonsHTTPAddressProvider
{
    /// <summary>Provides the <see cref="Settings.Query.HTTP.HTTPQueryOptions"/></summary>
    private IOptions<HTTPQueryOptions> HTTPQueryOptions { get; }

    public Uri HTTPAddress => new(HTTPQueryOptions.Value.HorizonsHTTPAddress);

    /// <inheritdoc cref="HorizonsHTTPAddressProvider"/>
    /// <param name="httpQueryOptions"><inheritdoc cref="HTTPQueryOptions" path="/summary"/></param>
    public HorizonsHTTPAddressProvider(IOptions<HTTPQueryOptions> httpQueryOptions)
    {
        HTTPQueryOptions = httpQueryOptions;
    }
}
