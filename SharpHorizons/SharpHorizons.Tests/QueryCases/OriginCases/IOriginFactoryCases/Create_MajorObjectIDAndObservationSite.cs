namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObjectIDAndObservationSite
{
    [Fact]
    public void NullSite_ArgumentNullException()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var site = GetInvalidObservationSite();

        var exception = Record.Exception(() => factory.Create(origin, site));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();
        var site = GetValidObservationSite();

        var actual = factory.Create(origin, site);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObjectID GetValidMajorObjectID() => new(399);

    private static ObservationSite GetInvalidObservationSite() => null!;
    private static ObservationSite GetValidObservationSite() => new(new ObservationSiteID("-1"), new ObservationSiteName("Arecibo"));
}
