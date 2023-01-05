namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_IOriginObjectAndIOriginCoordinate
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetNullOriginObject();
        var coordinate = GetValidCoordinate();

        EitherNull_ArgumentNullException(origin, coordinate);
    }

    [Fact]
    public void NullCoordinate_ArgumentNullException()
    {
        var origin = GetValidOriginObject();
        var coordinate = GetNullCoordinate();

        EitherNull_ArgumentNullException(origin, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var origin = GetNullOriginObject();
        var coordinate = GetNullCoordinate();

        EitherNull_ArgumentNullException(origin, coordinate);
    }

    private static void EitherNull_ArgumentNullException(IOriginObject origin, IOriginCoordinate coordinate)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidOriginObject();
        var coordinate = GetValidCoordinate();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static IOriginObject GetNullOriginObject() => null!;
    private static IOriginObject GetValidOriginObject()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginObjectFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static IOriginCoordinate GetNullCoordinate() => null!;
    private static IOriginCoordinate GetValidCoordinate()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginCoordinateFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
