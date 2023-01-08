namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;
using System.Globalization;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void String_Valid_ExactMatch(string id)
    {
        ObservationSiteID actual = new(id);

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void String_Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => new ObservationSiteID(id));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void String_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteID(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDInts))]
    public void Int_Valid_MatchInvariantCulture(int id)
    {
        ObservationSiteID actual = new(id);

        Assert.Equal(id.ToString(CultureInfo.InvariantCulture), actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDInts))]
    public void Int_Invalid_ArgumentOutOfRangeException(int id)
    {
        var exception = Record.Exception(() => new ObservationSiteID(id));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
