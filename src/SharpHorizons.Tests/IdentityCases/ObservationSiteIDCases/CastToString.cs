namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDs))]
    public void Valid_ExactMatch(ObservationSiteID observationSiteID)
    {
        var actual = (string)observationSiteID;

        Assert.Equal(observationSiteID.Value, actual);
    }

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(ObservationSiteID));

        Assert.IsType<ArgumentException>(exception);
    }
}
