namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectIDAndCylindrical
{
    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var coordinate = GetInvalidCylindrical();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var coordinate = GetValidCylindrical();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectID GetValidMajorObjectID() => new(399);

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
