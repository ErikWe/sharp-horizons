namespace ConsoleApp1;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SharpHorizons;
using SharpHorizons.Calendars;
using SharpHorizons.Identity;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using SharpMeasures;

using System;

internal class Program
{
    private static void Main()
    {
        var host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(ConfigureConfiguration).ConfigureServices(ConfigureServices).Build();

        host.Start();

        var targetFactory = host.Services.GetRequiredService<ITargetFactory>();
        var originFactory = host.Services.GetRequiredService<IOriginFactory>();
        var epochRangeFactory = host.Services.GetRequiredService<IFixedEpochRangeFactory>();

        var target = targetFactory.Create(new MajorObjectID(301));
        var origin = originFactory.Create(new MajorObjectID(399));
        var epochSelection = epochRangeFactory.Create(new JulianDay(3), new JulianDay(4), Time.OneHour);

        var queryFactory = host.Services.GetRequiredService<IVectorsQueryFactory>();

        var query = queryFactory.Build(target, origin, epochSelection);

        var composer = host.Services.GetRequiredService<IVectorsQueryComposer>();

        var uri = composer.Compose(query);

        Console.WriteLine(uri);
    }

    private static void ConfigureConfiguration(HostBuilderContext context, IConfigurationBuilder configuration)
    {
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSharpHorizons(context.Configuration.GetSection("SharpHorizons"));
    }
}