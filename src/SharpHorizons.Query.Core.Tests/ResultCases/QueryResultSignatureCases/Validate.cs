namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultSignatureCases;

using SharpHorizons.Query.Result;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidQueryResultSignatures))]
    public void Valid_NoException(QueryResultSignature queryResultSignature)
    {
        var exception = Record.Exception(() => QueryResultSignature.Validate(queryResultSignature));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidQueryResultSignatures))]
    public void Invalid_ArgumentException(QueryResultSignature queryResultSignature)
    {
        var exception = Record.Exception(() => QueryResultSignature.Validate(queryResultSignature));

        Assert.IsType<ArgumentException>(exception);
    }
}
