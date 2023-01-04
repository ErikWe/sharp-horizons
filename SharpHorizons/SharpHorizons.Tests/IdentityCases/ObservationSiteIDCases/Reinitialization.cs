namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void Valid_ExactMatch(string id)
    {
        var actual = InitialObservationSiteID with { Value = id };

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => InitialObservationSiteID with { Value = id });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialObservationSiteID with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static ObservationSiteID InitialObservationSiteID => new("-1");
}
