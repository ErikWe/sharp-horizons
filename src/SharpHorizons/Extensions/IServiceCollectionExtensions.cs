namespace SharpHorizons.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NodaTime;

using SharpHorizons.Extensions.Interpretation;
using SharpHorizons.Extensions.Query;
using SharpHorizons.Extensions.Query.Fluency;
using SharpHorizons.Extensions.Query.HTTP;

using System;

/// <summary>Extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services)
    {
        services.AddSharpHorizonsExternal();

        services.AddSharpHorizonsQuery();
        services.AddSharpHorizonsHTTPQuery();
        services.AddSharpHorizonsFluentQuery();

        services.AddSharpHorizonsInterpretation();

        return services;
    }

    /// <summary>Adds services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>, with configuration provided by <paramref name="configuration"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">Provides configuration of the SharpHorizons services.</param>
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSharpHorizonsExternal();

        services.AddSharpHorizonsQuery(configuration.GetSection("Query"));
        services.AddSharpHorizonsHTTPQuery(configuration.GetSection("Query:HTTP"));
        services.AddSharpHorizonsFluentQuery();

        services.AddSharpHorizonsInterpretation(configuration.GetSection("Interpretation"));

        return services;
    }

    /// <summary>Adds external services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">External services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsExternal(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddSingleton(DateTimeZoneProviders.Tzdb);

        return services;
    }
}
