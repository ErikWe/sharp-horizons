namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNames))]
    public void Valid_NoException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => ObservationSiteName.Validate(observationSiteName));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNames))]
    public void Invalid_ArgumentException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => ObservationSiteName.Validate(observationSiteName));

        Assert.IsType<ArgumentException>(exception);
    }
}
