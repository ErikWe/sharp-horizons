namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void Valid_ExactMatchValue(ObservationSiteID observationSiteID)
    {
        var expected = observationSiteID.Value;

        var actual = observationSiteID.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDs))]
    public void Invalid_InvalidOperationException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(observationSiteID.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
