namespace ConsoleApp1;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SharpHorizons;
using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Request.HTTP;
using SharpHorizons.Query.Result.HTTP;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using SharpMeasures;

using System;
using System.Threading.Tasks;

internal class Program
{
    private async static Task Main()
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
        var httpTextExtractor = host.Services.GetRequiredService<IHTTPResultExtractor>();
        var vectorsHeaderInterpreter = host.Services.GetRequiredService<IVectorsQueryHeaderInterpreter>();

        var query = queryFactory.Build(target, origin, epochSelection).WithConfiguration(outputFormat: SharpHorizons.Query.OutputFormat.JSON);
        var uri = vectorsComposer.Compose(query);
        var httpResult = httpQueryHandler.RequestAsync(uri).Result;
        var textResult = await httpTextExtractor.ExtractAsync(httpResult);
        var vectorsHeader = vectorsHeaderInterpreter.Interpret(textResult);

        Console.WriteLine(vectorsHeader.TargetHeader.Target.ComposeArgument());
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
