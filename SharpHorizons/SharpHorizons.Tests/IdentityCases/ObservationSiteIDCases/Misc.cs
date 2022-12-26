namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(ObservationSiteID).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void ValueAccess_Valid_NoException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => observationSiteID.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => ObservationSiteID.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void Validate_Valid_NoException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => ObservationSiteID.Validate(observationSiteID));

        Assert.Null(exception);
    }
}
