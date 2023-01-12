namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNames))]
    public void Valid_NoException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => observationSiteName.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNames))]
    public void Invalid_InvalidOperationException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => observationSiteName.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
