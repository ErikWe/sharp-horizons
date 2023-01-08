namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectIDAndITargetSite
{
    public static void NullCoordinate_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();
        var site = GetNullTargetSite();

        var exception = Record.Exception(() => factory.Create(target, site));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();
        var site = GetValidTargetSite();

        var actual = factory.Create(target, site);

        Assert.NotNull(actual);
    }

    private static MajorObjectID GetValidMajorObjectID() => new(301);

    private static ITargetSite GetNullTargetSite() => null!;
    private static ITargetSite GetValidTargetSite()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetSiteFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
