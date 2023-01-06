namespace SharpHorizons.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NodaTime;

/// <summary>Extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services)
    {
        services.AddSharpHorizonsExternal();

        services.AddSharpHorizonsQuery();
        services.AddSharpHorizonsInterpretation();

        return services;
    }

    /// <summary>Adds services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>, with configuration provided by <paramref name="configuration"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">Provides configuration of the SharpHorizons services.</param>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharpHorizonsExternal();

        services.AddSharpHorizonsQuery(configuration);
        services.AddSharpHorizonsInterpretation(configuration);

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
