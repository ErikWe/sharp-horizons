namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultSignatureCases;

using SharpHorizons.Query.Result;

using System;

using Xunit;

public class SourceAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidQueryResultSignatures))]
    public void Valid_NoException(QueryResultSignature queryResultSignature)
    {
        var exception = Record.Exception(() => queryResultSignature.Source);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidQueryResultSignatures))]
    public void Invalid_InvalidOperationException(QueryResultSignature queryResultSignature)
    {
        var exception = Record.Exception(() => queryResultSignature.Source);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
