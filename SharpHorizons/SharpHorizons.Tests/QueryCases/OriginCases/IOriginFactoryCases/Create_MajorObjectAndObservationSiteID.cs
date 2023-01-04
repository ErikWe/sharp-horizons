namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObjectAndObservationSiteID
{
    [Fact]
    public void NullObject_ArgumentNullException()
    {
        var origin = GetInvalidMajorObject();
        var site = GetValidObservationSiteID();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, site);
    }

    [Fact]
    public void InvalidSite_ArgumentException()
    {
        var origin = GetValidMajorObject();
        var site = GetInvalidObservationSiteID();

        EitherNullOrInvalid_TException<ArgumentException>(origin, site);
    }

    [Fact]
    public void NullObjectAndInvalidSite_ArgumentNullException()
    {
        var origin = GetInvalidMajorObject();
        var site = GetInvalidObservationSiteID();

        EitherNullOrInvalid_TException<ArgumentNullException>(origin, site);
    }

    private static void EitherNullOrInvalid_TException<TException>(MajorObject origin, ObservationSiteID site) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(origin, site));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObject();
        var site = GetValidObservationSiteID();

        var actual = factory.Create(origin, site);

        Assert.NotNull(actual);
    }

    private static IOriginFactory GetService() => DependencyInjection.GetRequiredService<IOriginFactory>();

    private static MajorObject GetInvalidMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(399));

    private static ObservationSiteID GetInvalidObservationSiteID() => default;
    private static ObservationSiteID GetValidObservationSiteID() => new("-1");
}
