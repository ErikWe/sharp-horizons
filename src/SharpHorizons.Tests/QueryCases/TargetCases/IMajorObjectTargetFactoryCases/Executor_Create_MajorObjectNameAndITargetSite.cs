namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectNameAndITargetSite
{
    public static void InvalidName_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObjectName();
        var site = GetValidTargetSite();

        EitherInvalidOrNull_TException<ArgumentException>(factory, target, site);
    }

    public static void NullSite_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectName();
        var site = GetNullTargetSite();

        EitherInvalidOrNull_TException<ArgumentNullException>(factory, target, site);
    }

    public static void InvalidNameAndNullSite_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObjectName();
        var site = GetNullTargetSite();

        EitherInvalidOrNull_TException<ArgumentNullException>(factory, target, site);
    }

    private static void EitherInvalidOrNull_TException<TException>(IMajorObjectTargetFactory factory, MajorObjectName target, ITargetSite site) where TException : Exception
    {
        var exception = Record.Exception(() => factory.Create(target, site));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectName();
        var site = GetValidTargetSite();

        var actual = factory.Create(target, site);

        Assert.NotNull(actual);
    }

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Moon");

    private static ITargetSite GetNullTargetSite() => null!;
    private static ITargetSite GetValidTargetSite()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetSiteFactory>();

        return factory.Create(new CylindricalCoordinate());
    }
}
