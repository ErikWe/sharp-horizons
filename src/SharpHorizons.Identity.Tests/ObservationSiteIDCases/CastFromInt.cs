namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;
using System.Globalization;

using Xunit;

public class CastFromInt
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDInts))]
    public void Valid_MatchInvariantCulture(int id)
    {
        var actual = (ObservationSiteID)id;

        Assert.Equal(id.ToString(CultureInfo.InvariantCulture), actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDInts))]
    public void Invalid_ArgumentOutOfRangeException(int id)
    {
        var exception = Record.Exception(() => (ObservationSiteID)id);

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
