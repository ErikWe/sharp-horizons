namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultCases;

using SharpHorizons.Query.Result;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidQueryResults))]
    public void Valid_NoException(QueryResult queryResult)
    {
        var exception = Record.Exception(() => QueryResult.Validate(queryResult));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidQueryResults))]
    public void Invalid_ArgumentException(QueryResult queryResult)
    {
        var exception = Record.Exception(() => QueryResult.Validate(queryResult));

        Assert.IsType<ArgumentException>(exception);
    }
}
