namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectIDAndGeodetic
{
    public static void InvalidCooordinate_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();
        var coordinate = GetInvalidGeodetic();

        var exception = Record.Exception(() => factory.Create(target, coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();
        var coordinate = GetValidGeodetic();

        var actual = factory.Create(target, coordinate);

        Assert.NotNull(actual);
    }

    private static MajorObjectID GetValidMajorObjectID() => new(301);

    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
    private static GeodeticCoordinate GetValidGeodetic() => new();
}
