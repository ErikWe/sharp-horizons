namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void Valid_ExactMatch(string id)
    {
        ObservationSiteID actual = new() { Value = id };

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => new ObservationSiteID() { Value = id });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteID() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
