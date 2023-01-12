namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryString))]
    public void Valid_NoException(HorizonsQueryString horizonsQueryString)
    {
        var exception = Record.Exception(() => HorizonsQueryString.Validate(horizonsQueryString));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryString))]
    public void Invalid_ArgumentException(HorizonsQueryString horizonsQueryString)
    {
        var exception = Record.Exception(() => HorizonsQueryString.Validate(horizonsQueryString));

        Assert.IsType<ArgumentException>(exception);
    }
}
