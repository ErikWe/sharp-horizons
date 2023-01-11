namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectAndCylindrical
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetNullMajorObject();
        var coordinate = GetValidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var origin = GetValidMajorObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentException>(origin, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var origin = GetNullMajorObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(MajorObject origin, CylindricalCoordinate coordinate) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, coordinate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObject();
        var coordinate = GetValidCylindrical();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObject GetNullMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(399));

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
