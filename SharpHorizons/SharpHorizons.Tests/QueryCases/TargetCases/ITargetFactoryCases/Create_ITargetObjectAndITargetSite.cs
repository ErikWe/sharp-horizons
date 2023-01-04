namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

using Xunit;

public class Create_ITargetObjectAndITargetSite
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var targetObject = GetInvalidTargetObject();
        var site = GetValidTargetSite();

        EitherNull_ArgumentNullException(targetObject, site);
    }

    [Fact]
    public void NullSite_ArgumentNullException()
    {
        var targetObject = GetValidTargetObject();
        var site = GetInvalidTargetSite();

        EitherNull_ArgumentNullException(targetObject, site);
    }

    [Fact]
    public void NullObjectAndSite_ArgumentNullException()
    {
        var targetObject = GetInvalidTargetObject();
        var site = GetInvalidTargetSite();

        EitherNull_ArgumentNullException(targetObject, site);
    }

    private static void EitherNull_ArgumentNullException(ITargetObject targetObject, ITargetSite site)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(targetObject, site));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var targetObject = GetValidTargetObject();
        var site = GetValidTargetSite();

        var actual = factory.Create(targetObject, site);

        Assert.NotNull(actual);
    }

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();

    private static ITargetObject GetInvalidTargetObject() => null!;
    private static ITargetObject GetValidTargetObject()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetObjectFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static ITargetSite GetInvalidTargetSite() => null!;
    private static ITargetSite GetValidTargetSite()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetSiteFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
