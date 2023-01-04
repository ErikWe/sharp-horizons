namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectAndIOriginCoordinate
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetInvalidMajorObject();
        var coordinate = GetValidOriginCoordinate();

        EitherNull_ArgumentNullException(origin, coordinate);
    }

    [Fact]
    public void NullOriginCoordinate_ArgumentNullException()
    {
        var origin = GetValidMajorObject();
        var coordinate = GetInvalidOriginCoordinate();

        EitherNull_ArgumentNullException(origin, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var origin = GetInvalidMajorObject();
        var coordinate = GetInvalidOriginCoordinate();

        EitherNull_ArgumentNullException(origin, coordinate);
    }

    private static void EitherNull_ArgumentNullException(MajorObject origin, IOriginCoordinate coordinate)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObject();
        var coordinate = GetValidOriginCoordinate();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObject GetInvalidMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(399));

    private static IOriginCoordinate GetInvalidOriginCoordinate() => null!;
    private static IOriginCoordinate GetValidOriginCoordinate()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginCoordinateFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
