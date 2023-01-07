namespace SharpHorizons.Extensions.Query.Fluency;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Fluency;

/// <summary>Hosts extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds fluent query-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Fluent query-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizonsFluentQuery(this IServiceCollection services)
    {
        services.AddSharpHorizonsVectorsQuery();

        return services;
    }

    /// <summary>Adds fluent <see cref="IVectorsQuery"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Fluent <see cref="IVectorsQuery"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsVectorsQuery(this IServiceCollection services)
    {
        services.AddSingleton<ITargetStageFactory, TargetStageFactory>();
        services.AddSingleton<IOriginStageFactory, OriginStageFactory>();
        services.AddSingleton<IEpochStageFactory, EpochStageFactory>();

        return services;
    }
}
