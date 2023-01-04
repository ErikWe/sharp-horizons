namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectIDAndCylindrical
{
    public static void InvalidCooordinate_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();
        var coordinate = GetInvalidCylindrical();

        var exception = Record.Exception(() => factory.Create(target, coordinate));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();
        var coordinate = GetValidCylindrical();

        var actual = factory.Create(target, coordinate);

        Assert.NotNull(actual);
    }

    private static MajorObjectID GetValidMajorObjectID() => new(301);

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
