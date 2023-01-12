namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNames))]
    public void Valid_ExactMatch(ObservationSiteName observationSiteName)
    {
        var actual = (string)observationSiteName;

        Assert.Equal(observationSiteName.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNames))]
    public void Invalid_ArgumentException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => (string)observationSiteName);

        Assert.IsType<ArgumentException>(exception);
    }
}
