namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class FromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryStringStrings))]
    public void Valid_ExactMatch(string queryString)
    {
        var actual = HorizonsQueryString.FromString(queryString);

        Assert.Equal(queryString, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryStringStrings))]
    public void Invalid_ArgumentException(string queryString)
    {
        var exception = Record.Exception(() => HorizonsQueryString.FromString(queryString));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => HorizonsQueryString.FromString(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
