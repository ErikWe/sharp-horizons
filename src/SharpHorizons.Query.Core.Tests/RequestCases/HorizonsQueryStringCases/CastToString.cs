namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryString))]
    public void Valid_ExactMatch(HorizonsQueryString horizonsQueryString)
    {
        var actual = (string)horizonsQueryString;

        Assert.Equal(horizonsQueryString.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryString))]
    public void Invalid_ArgumentException(HorizonsQueryString horizonsQueryString)
    {
        var exception = Record.Exception(() => (string)horizonsQueryString);

        Assert.IsType<ArgumentException>(exception);
    }
}
