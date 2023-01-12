namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void Valid_NoException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => observationSiteID.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDs))]
    public void Invalid_InvalidOperationException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => observationSiteID.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
