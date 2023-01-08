﻿namespace SharpHorizons.Extensions.Query.HTTP;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Query.Request.HTTP;
using SharpHorizons.Query.Result.HTTP;
using SharpHorizons.Settings.Query.HTTP;

/// <summary>Hosts extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds HTTP-query-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Query-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizonsHTTPQuery(this IServiceCollection services)
    {
        services.AddSharpHorizonsHTTPQueryOptions();

        services.AddSingleton<IHTTPQueryHandler, HTTPQueryHandler>();
        services.AddSingleton<IHTTPResultHandler, HTTPTextHandler>();

        return services;
    }

    /// <summary>Adds HTTP-query-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>, with configuration provided by the <see cref="IConfiguration"/> <paramref name="configuration"/>.</summary>
    /// <param name="services">Query-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">This <see cref="IConfiguration"/> provides configuration for the added SharpHorizons services.</param>
    public static IServiceCollection AddSharpHorizonsHTTPQuery(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharpHorizonsHTTPQuery();

        services.Configure<HTTPQueryOptions>(configuration.GetSection(HTTPQueryOptions.Section));

        return services;
    }

    /// <summary>Adds HTTP-query- and options-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Query- and options-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsHTTPQueryOptions(this IServiceCollection services)
    {
        services.AddOptions<HTTPQueryOptions>().Configure(HTTPQueryOptions.ApplyDefaults);

        services.AddSingleton<IHorizonsHTTPAddressProvider, HorizonsHTTPAddressProvider>();

        return services;
    }
}