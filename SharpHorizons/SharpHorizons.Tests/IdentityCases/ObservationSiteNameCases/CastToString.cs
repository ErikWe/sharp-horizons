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

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(ObservationSiteName));

        Assert.IsType<ArgumentException>(exception);
    }
}
