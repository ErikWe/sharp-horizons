namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(ObservationSiteName).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNames))]
    public void ValueAccess_Valid_NoException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => observationSiteName.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => ObservationSiteName.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidObservationSiteNames))]
    public void Validate_Valid_NoException(ObservationSiteName observationSiteName)
    {
        var exception = Record.Exception(() => ObservationSiteName.Validate(observationSiteName));

        Assert.Null(exception);
    }
}
