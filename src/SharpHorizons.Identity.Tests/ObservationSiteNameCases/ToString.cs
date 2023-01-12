namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNames))]
    public void Valid_ExactMatchValue(ObservationSiteName observationSiteName)
    {
        var expected = observationSiteName.Value;

        var actual = observationSiteName.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNames))]
    public void Invalid_InvalidOperationException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(observationSiteName.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
