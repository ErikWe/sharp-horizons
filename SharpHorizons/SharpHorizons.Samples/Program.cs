namespace ConsoleApp1;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SharpHorizons;
using SharpHorizons.Vectors;

using System;

internal class Program
{
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices).Build();

        host.Start();

        var uh = host.Services.GetService<IVectorsQueryFactory>();

        Console.WriteLine(uh?.Fluent());
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSharpHorizons();
    }
}