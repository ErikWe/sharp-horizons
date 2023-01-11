namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectAndITargetSite
{
    public static void NullObject_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetNullMajorObject();
        var site = GetValidTargetSite();

        MajorObjectAndITargetSite_EitherNull_ArgumentNullException(factory, target, site);
    }

    public static void NullSite_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();
        var site = GetNullTargetSite();

        MajorObjectAndITargetSite_EitherNull_ArgumentNullException(factory, target, site);
    }

    public static void NullObjectAndSite_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetNullMajorObject();
        var site = GetNullTargetSite();

        MajorObjectAndITargetSite_EitherNull_ArgumentNullException(factory, target, site);
    }

    private static void MajorObjectAndITargetSite_EitherNull_ArgumentNullException(IMajorObjectTargetFactory factory, MajorObject target, ITargetSite site)
    {
        var exception = Record.Exception(() => factory.Create(target, site));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();
        var site = GetValidTargetSite();

        var actual = factory.Create(target, site);

        Assert.NotNull(actual);
    }

    private static MajorObject GetNullMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(301));

    private static ITargetSite GetNullTargetSite() => null!;
    private static ITargetSite GetValidTargetSite()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetSiteFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
