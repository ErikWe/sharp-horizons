namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void Valid_NoException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => ObservationSiteID.Validate(observationSiteID));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDs))]
    public void Invalid_ArgumentException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => ObservationSiteID.Validate(observationSiteID));

        Assert.IsType<ArgumentException>(exception);
    }
}
