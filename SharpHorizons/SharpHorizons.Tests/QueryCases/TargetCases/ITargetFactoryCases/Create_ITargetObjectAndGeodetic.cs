namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_ITargetObjectAndGeodetic
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var targetObject = GetInvalidTargetObject();
        var coordinate = GetValidGeodetic();

        EitherNullOrInvalid_TException<ArgumentNullException>(targetObject, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var targetObject = GetValidTargetObject();
        var coordinate = GetInvalidGeodetic();

        EitherNullOrInvalid_TException<ArgumentException>(targetObject, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var targetObject = GetInvalidTargetObject();
        var coordinate = GetInvalidGeodetic();

        EitherNullOrInvalid_TException<ArgumentNullException>(targetObject, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(ITargetObject targetObject, GeodeticCoordinate coordinate)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(targetObject, coordinate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var targetObject = GetValidTargetObject();
        var coordinate = GetValidGeodetic();

        var actual = factory.Create(targetObject, coordinate);

        Assert.NotNull(actual);
    }

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();

    private static ITargetObject GetInvalidTargetObject() => null!;
    private static ITargetObject GetValidTargetObject()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetObjectFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static GeodeticCoordinate GetValidGeodetic() => new();
    private static GeodeticCoordinate GetInvalidGeodetic() => new(new Longitude(double.NaN), new Latitude(double.NaN), new Height(double.NaN));
}
