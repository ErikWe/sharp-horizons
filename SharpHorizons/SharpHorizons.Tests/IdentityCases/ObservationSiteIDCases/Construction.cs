namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System;
using System.Globalization;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void Valid_ExactMatch(string id)
    {
        ObservationSiteID actual = new(id);

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => new ObservationSiteID(id));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteID(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDInts))]
    public void FromInt_Valid_MatchInvariantCulture(int id)
    {
        ObservationSiteID actual = new(id);

        Assert.Equal(id.ToString(CultureInfo.InvariantCulture), actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDInts))]
    public void FromInt_Invalid_ArgumentOutOfRangeException(int id)
    {
        var exception = Record.Exception(() => new ObservationSiteID(id));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void Initialization_Valid_ExactMatch(string id)
    {
        ObservationSiteID actual = new() { Value = id };

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void Initialization_Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => new ObservationSiteID() { Value = id });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteID() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void Reinitialization_Valid_ExactMatch(string id)
    {
        var actual = new ObservationSiteID("1") with { Value = id };

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void Reinitialization_Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => new ObservationSiteID("1") with { Value = id });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteID("1") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDStrings))]
    public void CastFromString_Valid_ExactMatch(string id)
    {
        var actual = (ObservationSiteID)id;

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDStrings))]
    public void CastFromString_Invalid_ArgumentException(string id)
    {
        var exception = Record.Exception(() => (ObservationSiteID)id);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void CastFromString_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (ObservationSiteID)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteIDInts))]
    public void CastFromInt_Valid_MatchInvariantCulture(int id)
    {
        var actual = (ObservationSiteID)id;

        Assert.Equal(id.ToString(CultureInfo.InvariantCulture), actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteIDInts))]
    public void CastFromInt_Invalid_ArgumentOutOfRangeException(int id)
    {
        var exception = Record.Exception(() => (ObservationSiteID)id);

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
