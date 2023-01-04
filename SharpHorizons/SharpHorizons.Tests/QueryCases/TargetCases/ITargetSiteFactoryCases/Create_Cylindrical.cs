namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetSiteFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_Cylindrical
{
    [Fact]
    public void Invalid_ArgumentException()
    {
        var factory = GetService();

        var coordinate = GetInvalidCylindrical();

        var exception = Record.Exception(() => factory.Create(coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var coordinate = GetValidCylindrical();

        var actual = factory.Create(coordinate);

        Assert.NotNull(actual);
    }

    private static ITargetSiteFactory GetService() => DependencyInjection.GetRequiredService<ITargetSiteFactory>();

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
