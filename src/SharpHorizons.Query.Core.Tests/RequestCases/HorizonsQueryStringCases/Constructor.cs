namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryStringStrings))]
    public void Valid_ExactMatch(string queryString)
    {
        HorizonsQueryString actual = new(queryString);

        Assert.Equal(queryString, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryStringStrings))]
    public void Invalid_ArgumentException(string queryString)
    {
        var exception = Record.Exception(() => new HorizonsQueryString(queryString));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new HorizonsQueryString(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
