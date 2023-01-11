namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void Reinitialization_Valid_ExactMatch(string name)
    {
        var actual = InitialObservationSiteName with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialObservationSiteName with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialObservationSiteName with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static ObservationSiteName InitialObservationSiteName => new("Arecibo");
}
