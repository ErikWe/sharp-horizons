namespace ConsoleApp1;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SharpHorizons;
using SharpHorizons.Extensions;
using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Request.HTTP;
using SharpHorizons.Query.Result.HTTP;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

using System;
using System.Threading.Tasks;

internal sealed class Program
{
    private static async Task Main()
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
        var vectorsComposer = host.Services.GetRequiredService<IVectorsQueryComposer>();
        var httpQueryHandler = host.Services.GetRequiredService<IHTTPQueryHandler>();
        var httpTextHandler = host.Services.GetRequiredService<IHTTPResultHandler>();
        var headerInterpreter = host.Services.GetRequiredService<IVectorsHeaderInterpreter>();
        var orbitalStateVectorsInterpreter = host.Services.GetRequiredService<IOrbitalStateVectorsEphemerisInterpreter>();

        var query = queryFactory.CreateBuilder(target, origin, epochSelection).SpecifyOutputFormat(OutputFormat.JSON).SpecifyTableContent(new(VectorTableQuantities.StateVectors, VectorTableUncertainties.All)).SpecifyOutputLabels(OutputLabels.Enable).Build();
        var uri = vectorsComposer.Compose(query);
        var httpResult = await httpQueryHandler.RequestAsync(uri);
        var textResult = await httpTextHandler.ExtractAsync(httpResult);
        var header = headerInterpreter.Interpret(textResult.Value);
        var orbitalStateVectors = orbitalStateVectorsInterpreter.Interpret(header.Value, textResult.Value);

        Console.WriteLine(orbitalStateVectors.Count);
    }

    private static void ConfigureConfiguration(IConfigurationBuilder configuration)
    {
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSharpHorizons(context.Configuration.GetSection("SharpHorizons"));
    }
}
