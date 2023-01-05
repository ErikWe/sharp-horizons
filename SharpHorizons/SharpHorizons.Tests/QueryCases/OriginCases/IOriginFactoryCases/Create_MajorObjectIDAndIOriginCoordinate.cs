namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectIDAndIOriginCoordinate
{
    [Fact]
    public void NullCoordinate_ArgumentNullException()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var coordinate = GetNullCoordinate();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var coordinate = GetValidCoordinate();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectID GetValidMajorObjectID() => new(399);

    private static IOriginCoordinate GetNullCoordinate() => null!;
    private static IOriginCoordinate GetValidCoordinate()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginCoordinateFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
