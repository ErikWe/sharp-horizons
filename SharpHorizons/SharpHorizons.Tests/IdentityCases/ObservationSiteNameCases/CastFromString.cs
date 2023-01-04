﻿namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = (ObservationSiteName)name;

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidObservationSiteNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => (ObservationSiteName)name);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (ObservationSiteName)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
