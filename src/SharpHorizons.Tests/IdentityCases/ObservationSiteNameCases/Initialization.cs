namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        ObservationSiteName actual = new() { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new ObservationSiteName() { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteName() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
