namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void Valid_ExactMatch(string id)
    {
        var actual = (ObservationSiteID)id;

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => (ObservationSiteID)id);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (ObservationSiteID)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
