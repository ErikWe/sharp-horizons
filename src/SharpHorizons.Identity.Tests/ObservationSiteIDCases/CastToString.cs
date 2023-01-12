namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void Valid_ExactMatchValue(ObservationSiteID observationSiteID)
    {
        var expected = observationSiteID.Value;

        var actual = (string)observationSiteID;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDs))]
    public void Invalid_ArgumentException(ObservationSiteID observationSiteID)
    {
        var exception = Record.Exception(() => (string)observationSiteID);

        Assert.IsType<ArgumentException>(exception);
    }
}
