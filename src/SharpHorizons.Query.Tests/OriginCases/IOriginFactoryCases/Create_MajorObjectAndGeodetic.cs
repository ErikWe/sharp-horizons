namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_MajorObjectAndGeodetic
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetNullMajorObject();
        var coordinate = GetValidGeodetic();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var origin = GetValidMajorObject();
        var coordinate = GetInvalidGeodetic();

        EitherNullOrInvalid_TException<ArgumentException>(origin, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var origin = GetNullMajorObject();
        var coordinate = GetInvalidGeodetic();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(MajorObject origin, GeodeticCoordinate coordinate) where TException : Exception
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
        var coordinate = GetValidGeodetic();

        var actual = factory.Create(origin, coordinate);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObject GetNullMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(399));

    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
    private static GeodeticCoordinate GetValidGeodetic() => new();
}
