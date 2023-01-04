namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectNameAndGeodetic
{
    public static void InvalidName_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObjectName();
        var coordinate = GetValidGeodetic();

        EitherInvalid_ArgumentException(factory, target, coordinate);
    }

    public static void InvalidCooordinate_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectName();
        var coordinate = GetInvalidGeodetic();

        EitherInvalid_ArgumentException(factory, target, coordinate);
    }

    public static void InvalidNameAndCoordinate_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObjectName();
        var coordinate = GetInvalidGeodetic();

        EitherInvalid_ArgumentException(factory, target, coordinate);
    }

    private static void EitherInvalid_ArgumentException(IMajorObjectTargetFactory factory, MajorObjectName target, GeodeticCoordinate coordinate)
    {
        var exception = Record.Exception(() => factory.Create(target, coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectName();
        var coordinate = GetValidGeodetic();

        var actual = factory.Create(target, coordinate);

        Assert.NotNull(actual);
    }

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Moon");

    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
    private static GeodeticCoordinate GetValidGeodetic() => new();
}
