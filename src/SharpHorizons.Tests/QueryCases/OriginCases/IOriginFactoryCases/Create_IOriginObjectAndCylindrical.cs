namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_IOriginObjectAndCylindrical
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetNullOriginObject();
        var coordinate = GetValidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var origin = GetValidOriginObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentException>(origin, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var origin = GetNullOriginObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(IOriginObject origin, CylindricalCoordinate coordinate) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidOriginObject();
        var coordinate = GetValidCylindrical();

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

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
