namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryStringStrings))]
    public void Valid_ExactMatch(string queryString)
    {
        var actual = InitialHorizonsQueryString with { Value = queryString };

        Assert.Equal(queryString, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryStringStrings))]
    public void Invalid_ArgumentException(string queryString)
    {
        var exception = Record.Exception(() => InitialHorizonsQueryString with { Value = queryString });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialHorizonsQueryString with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static HorizonsQueryString InitialHorizonsQueryString => new("COMMAND=301");
}
