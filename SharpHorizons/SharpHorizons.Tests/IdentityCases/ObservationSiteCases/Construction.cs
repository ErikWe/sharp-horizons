namespace SharpHorizons.Tests.IdentityCases.ObservationSiteCases;

using System;

using Xunit;

public class Construction
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

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Initialization_Valid_ExactMatch(ObservationSiteID id, ObservationSiteName name)
    {
        ObservationSite actual = new() { ID = id, Name = name };

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Initialization_Invalid_ArgumentException(ObservationSiteID id, ObservationSiteName name)
    {
        var exception = Record.Exception(() => new ObservationSite() { ID = id, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Reinitialization_Valid_ExactMatch(ObservationSiteID id, ObservationSiteName name)
    {
        var actual = new ObservationSite(new ObservationSiteID(1), new ObservationSiteName("Place")) with { ID = id, Name = name };

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Reinitialization_Invalid_ArgumentException(ObservationSiteID id, ObservationSiteName name)
    {
        var exception = Record.Exception(() => new ObservationSite(new ObservationSiteID(1), new ObservationSiteName("Place")) with { ID = id, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }
}
