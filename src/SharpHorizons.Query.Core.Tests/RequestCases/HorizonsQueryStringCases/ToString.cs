namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryString))]
    public void Valid_ExactMatchValue(HorizonsQueryString horizonsQueryString)
    {
        var expected = horizonsQueryString.Value;

        var actual = horizonsQueryString.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryString))]
    public void Invalid_InvalidOperationException(HorizonsQueryString horizonsQueryString)
    {
        var exception = Record.Exception(horizonsQueryString.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
