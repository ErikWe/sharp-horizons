namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObjectNameAndObservationSite
{
    [Fact]
    public void InvalidName_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var site = GetValidObservationSite();

        EitherInvalidOrNull_TException<ArgumentException>(origin, site);
    }

    [Fact]
    public void NullSite_ArgumentNullException()
    {
        var origin = GetValidMajorObjectName();
        var site = GetNullObservationSite();

        EitherInvalidOrNull_TException<ArgumentNullException>(origin, site);
    }

    [Fact]
    public void InvalidNameAndNullSite_ArgumentNullException()
    {
        var origin = GetInvalidMajorObjectName();
        var site = GetNullObservationSite();

        EitherInvalidOrNull_TException<ArgumentNullException>(origin, site);
    }

    private static void EitherInvalidOrNull_TException<TException>(MajorObjectName origin, ObservationSite site) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, site));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectName();
        var site = GetValidObservationSite();

        var actual = factory.Create(origin, site);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Earth");

    private static ObservationSite GetNullObservationSite() => null!;
    private static ObservationSite GetValidObservationSite() => new(new ObservationSiteID("-1"), new ObservationSiteName("Arecibo"));
}
