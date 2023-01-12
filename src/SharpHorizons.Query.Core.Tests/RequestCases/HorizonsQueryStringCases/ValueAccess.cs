namespace SharpHorizons.Tests.QueryCases.RequestCases.HorizonsQueryStringCases;

using SharpHorizons.Query.Request;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidHorizonQueryString))]
    public void Valid_NoException(HorizonsQueryString horizonsQueryString)
    {
        var exception = Record.Exception(() => horizonsQueryString.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidHorizonQueryString))]
    public void Invalid_InvalidOperationException(HorizonsQueryString horizonsQueryString)
    {
        var exception = Record.Exception(() => horizonsQueryString.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
