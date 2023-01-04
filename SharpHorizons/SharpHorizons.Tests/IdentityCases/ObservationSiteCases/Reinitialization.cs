namespace SharpHorizons.Tests.IdentityCases.ObservationSiteCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(ObservationSiteID id, ObservationSiteName name)
    {
        var actual = InitialObservationSite with { ID = id, Name = name };

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(ObservationSiteID id, ObservationSiteName name)
    {
        var exception = Record.Exception(() => InitialObservationSite with { ID = id, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    private static ObservationSite InitialObservationSite => new(new ObservationSiteID(-1), new ObservationSiteName("Arecibo"));
}
