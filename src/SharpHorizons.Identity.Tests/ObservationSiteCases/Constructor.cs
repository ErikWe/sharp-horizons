namespace SharpHorizons.Tests.IdentityCases.ObservationSiteCases;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(ObservationSiteID id, ObservationSiteName name)
    {
        ObservationSite actual = new(id, name);

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(ObservationSiteID id, ObservationSiteName name)
    {
        var exception = Record.Exception(() => new ObservationSite(id, name));

        Assert.IsType<ArgumentException>(exception);
    }
}
