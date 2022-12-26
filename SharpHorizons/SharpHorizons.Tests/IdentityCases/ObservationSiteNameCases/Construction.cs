namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        ObservationSiteName actual = new(name);

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new ObservationSiteName(name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteName(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void Initialization_Valid_ExactMatch(string name)
    {
        ObservationSiteName actual = new() { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void Initialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new ObservationSiteName() { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteName() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void Reinitialization_Valid_ExactMatch(string name)
    {
        var actual = new ObservationSiteName("1") with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new ObservationSiteName("1") with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new ObservationSiteName("1") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void CastFromString_ExactMatch(string name)
    {
        var actual = (ObservationSiteName)name;

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void CastFromString_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => (ObservationSiteName)name);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void CastFromString_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (ObservationSiteName)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
