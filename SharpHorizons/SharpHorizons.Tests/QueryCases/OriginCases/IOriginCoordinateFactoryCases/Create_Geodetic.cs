namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginCoordinateFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_Geodetic
{
    [Fact]
    public void Invalid_ArgumentException()
    {
        var factory = GetService();

        var coordinate = GetInvalidGeodetic();

        var exception = Record.Exception(() => factory.Create(coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var coordinate = GetValidGeodetic();

        var actual = factory.Create(coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginCoordinateFactory GetService() => DependencyInjection.GetRequiredService<IOriginCoordinateFactory>();

    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
    private static GeodeticCoordinate GetValidGeodetic() => new();
}
