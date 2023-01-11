namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectNameAndGeodetic
{
    [Fact]
    public void InvalidName_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var coordinate = GetValidGeodetic();

        EitherInvalid_ArgumentException(origin, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var origin = GetValidMajorObjectName();
        var coordinate = GetInvalidGeodetic();

        EitherInvalid_ArgumentException(origin, coordinate);
    }

    [Fact]
    public void InvalidNameAndCoordinate_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var coordinate = GetInvalidGeodetic();

        EitherInvalid_ArgumentException(origin, coordinate);
    }

    private static void EitherInvalid_ArgumentException(MajorObjectName origin, GeodeticCoordinate coordinate)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectName();
        var coordinate = GetValidGeodetic();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Earth");

    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
    private static GeodeticCoordinate GetValidGeodetic() => new();
}
