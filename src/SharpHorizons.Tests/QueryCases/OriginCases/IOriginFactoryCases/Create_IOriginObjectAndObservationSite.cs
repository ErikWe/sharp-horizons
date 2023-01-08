namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_IOriginObjectAndObservationSite
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetNullOriginObject();
        var site = GetValidObservationSite();

        EitherNull_ArgumentNullException(origin, site);
    }

    [Fact]
    public void NullSite_ArgumentNullException()
    {
        var origin = GetValidOriginObject();
        var site = GetNullObservationSite();

        EitherNull_ArgumentNullException(origin, site);
    }

    [Fact]
    public void NullObjectAndSite_ArgumentNullException()
    {
        var origin = GetNullOriginObject();
        var site = GetNullObservationSite();

        EitherNull_ArgumentNullException(origin, site);
    }

    private static void EitherNull_ArgumentNullException(IOriginObject origin, ObservationSite site)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, site));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidOriginObject();
        var site = GetValidObservationSite();

        var actual = factory.Create(origin, site);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static IOriginObject GetNullOriginObject() => null!;
    private static IOriginObject GetValidOriginObject()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginObjectFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static ObservationSite GetNullObservationSite() => null!;
    private static ObservationSite GetValidObservationSite() => new(new ObservationSiteID("-1"), new ObservationSiteName("Arecibo"));
}
