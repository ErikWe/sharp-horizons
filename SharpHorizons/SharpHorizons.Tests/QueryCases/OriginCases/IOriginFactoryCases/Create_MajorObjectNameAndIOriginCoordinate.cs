namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectNameAndIOriginCoordinate
{
    [Fact]
    public void InvalidName_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var coordinate = GetValidCoordinate();

        EitherInvalidOrNull_TException<ArgumentException>(origin, coordinate);
    }

    [Fact]
    public void NullCoordinate_ArgumentNullException()
    {
        var origin = GetValidMajorObjectName();
        var coordinate = GetInvalidCoordinate();

        EitherInvalidOrNull_TException<ArgumentNullException>(origin, coordinate);
    }

    [Fact]
    public void InvalidNameAndNullCoordinate_ArgumentNullException()
    {
        var origin = GetInvalidMajorObjectName();
        var coordinate = GetInvalidCoordinate();

        EitherInvalidOrNull_TException<ArgumentNullException>(origin, coordinate);
    }

    private static void EitherInvalidOrNull_TException<TException>(MajorObjectName origin, IOriginCoordinate coordinate) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectName();
        var coordinate = GetValidCoordinate();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Earth");

    private static IOriginCoordinate GetInvalidCoordinate() => null!;
    private static IOriginCoordinate GetValidCoordinate()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginCoordinateFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
