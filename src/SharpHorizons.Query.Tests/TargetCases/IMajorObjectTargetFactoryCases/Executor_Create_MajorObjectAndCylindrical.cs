namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectAndCylindrical
{
    public static void NullObject_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetNullMajorObject();
        var coordinate = GetValidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(factory, target, coordinate);
    }

    public static void InvalidCooordinate_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentException>(factory, target, coordinate);
    }

    public static void NullObjectAndInvalidCoordinate_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetNullMajorObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(factory, target, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(IMajorObjectTargetFactory factory, MajorObject target, CylindricalCoordinate coordinate) where TException : Exception
    {
        var exception = Record.Exception(() => factory.Create(target, coordinate));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();
        var coordinate = GetValidCylindrical();

        var actual = factory.Create(target, coordinate);

        Assert.NotNull(actual);
    }

    private static MajorObject GetNullMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(301));

    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
    private static CylindricalCoordinate GetValidCylindrical() => new();
}
