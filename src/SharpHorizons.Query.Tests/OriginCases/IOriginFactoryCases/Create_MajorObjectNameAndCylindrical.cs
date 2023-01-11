namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectNameAndCylindrical
{
    [Fact]
    public void InvalidName_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var coordinate = GetValidCylindrical();

        EitherInvalid_ArgumentException(origin, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var origin = GetValidMajorObjectName();
        var coordinate = GetInvalidCylindrical();

        EitherInvalid_ArgumentException(origin, coordinate);
    }

    [Fact]
    public void InvalidNameAndCoordinate_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var coordinate = GetInvalidCylindrical();

        EitherInvalid_ArgumentException(origin, coordinate);
    }

    private static void EitherInvalid_ArgumentException(MajorObjectName origin, CylindricalCoordinate coordinate)
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
        var coordinate = GetValidCylindrical();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Earth");

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
