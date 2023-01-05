namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_ITargetObjectAndCylindrical
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var targetObject = GetNullTargetObject();
        var coordinate = GetValidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(targetObject, coordinate);
    }

    [Fact]
    public void InvalidCoordinate_ArgumentException()
    {
        var targetObject = GetValidTargetObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentException>(targetObject, coordinate);
    }

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException()
    {
        var targetObject = GetNullTargetObject();
        var coordinate = GetInvalidCylindrical();

        EitherNullOrInvalid_TException<ArgumentNullException>(targetObject, coordinate);
    }

    private static void EitherNullOrInvalid_TException<TException>(ITargetObject targetObject, CylindricalCoordinate coordinate)
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
        var coordinate = GetValidCylindrical();

        var actual = factory.Create(targetObject, coordinate);

        Assert.NotNull(actual);
    }

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();

    private static ITargetObject GetNullTargetObject() => null!;
    private static ITargetObject GetValidTargetObject()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetObjectFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static CylindricalCoordinate GetValidCylindrical() => new();
    private static CylindricalCoordinate GetInvalidCylindrical() => new(new Distance(double.NaN), new Azimuth(double.NaN), new Height(double.NaN));
}
