namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectAndGeodetic
{
    public static void NullMajorObject_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObject();
        var coordinate = GetValidGeodetic();

        EitherNullOrInvalid_TException<ArgumentNullException>(factory, target, coordinate);
    }

    public static void InvalidCooordinate_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();
        var coordinate = GetInvalidGeodetic();

        EitherNullOrInvalid_TException<ArgumentException>(factory, target, coordinate);
    }

    public static void NullMajorObjectAndInvalidCoordinate_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObject();
        var coordinate = GetInvalidGeodetic();

        EitherNullOrInvalid_TException<ArgumentNullException>(factory, target, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(IMajorObjectTargetFactory factory, MajorObject target, GeodeticCoordinate coordinate) where TException : Exception
    {
        var exception = Record.Exception(() => factory.Create(target, coordinate));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();
        var coordinate = GetValidGeodetic();

        var actual = factory.Create(target, coordinate);

        Assert.NotNull(actual);
    }

    private static MajorObject GetInvalidMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(301));

    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
    private static GeodeticCoordinate GetValidGeodetic() => new();
}
