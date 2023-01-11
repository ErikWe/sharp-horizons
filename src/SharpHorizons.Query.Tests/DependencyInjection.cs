namespace SharpHorizons.Tests.QueryCases;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Extensions.Query;

using System;

internal static class DependencyInjection
{
    private static IServiceProvider? Provider { get; set; }

    private static IServiceProvider GetProvider()
    {
        if (Provider is not null)
        {
            return Provider;
        }

        ServiceCollection services = new();

        services.AddSharpHorizonsQuery();

        Provider = services.BuildServiceProvider();

        return Provider;
    }

    public static T GetRequiredService<T>() where T : notnull => GetProvider().GetRequiredService<T>();
}
