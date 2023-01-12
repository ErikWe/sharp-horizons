namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultCases;

using SharpHorizons.Query.Result;

using System;

using Xunit;

public class SignatureAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidQueryResults))]
    public void Valid_NoException(QueryResult queryResult)
    {
        var exception = Record.Exception(() => queryResult.Signature);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidQueryResults))]
    public void Invalid_InvalidOperationException(QueryResult queryResult)
    {
        var exception = Record.Exception(() => queryResult.Signature);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
