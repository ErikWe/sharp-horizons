namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObjectNameAndObservationSiteID
{
    [Fact]
    public void InvalidName_ArgumentException()
    {
        var origin = GetInvalidMajorObjectName();
        var site = GetValidObservationSiteID();

        EitherInvalid_ArgumentException(origin, site);
    }

    [Fact]
    public void InvalidSite_ArgumentException()
    {
        var origin = GetValidMajorObjectName();
        var site = GetInvalidObservationSiteID();

        EitherInvalid_ArgumentException(origin, site);
    }

    [Fact]
    public void NullObjectAndInvalidSite_ArgumentNullException()
    {
        var origin = GetInvalidMajorObjectName();
        var site = GetInvalidObservationSiteID();

        EitherInvalid_ArgumentException(origin, site);
    }

    private static void EitherInvalid_ArgumentException(MajorObjectName origin, ObservationSiteID site)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, site));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectName();
        var site = GetValidObservationSiteID();

        var actual = factory.Create(origin, site);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Earth");

    private static ObservationSiteID GetInvalidObservationSiteID() => default;
    private static ObservationSiteID GetValidObservationSiteID() => new("-1");
}
