namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObjectIDAndObservationSiteID
{
    [Fact]
    public void InvalidSite_ArgumentException()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var site = GetInvalidObservationSiteID();

        var exception = Record.Exception(() => factory.Create(origin, site));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var site = GetValidObservationSiteID();

        var actual = factory.Create(origin, site);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectID GetValidMajorObjectID() => new(399);

    private static ObservationSiteID GetInvalidObservationSiteID() => default;
    private static ObservationSiteID GetValidObservationSiteID() => new("-1");
}
