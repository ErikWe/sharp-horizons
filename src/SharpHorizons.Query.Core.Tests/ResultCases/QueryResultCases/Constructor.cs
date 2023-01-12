namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultCases;

using SharpHorizons.Query.Result;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidQueryResultTuples))]
    public void Valid_ExactMatch(QueryResultSignature signature, string content)
    {
        QueryResult actual = new(signature, content);

        Assert.Equal(signature, actual.Signature);
        Assert.Equal(content, actual.Content);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidQueryResultTuples))]
    public void BothInvalid_ArgumentException(QueryResultSignature signature, string content)
    {
        var exception = Record.Exception(() => new QueryResult(signature, content));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void InvalidSignatureNullContent_ArgumentException()
    {
        QueryResultSignature signature = default;
        string content = null!;

        var exception = Record.Exception(() => new QueryResult(signature, content));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void InvalidSignatureValidContent_ArgumentException()
    {
        QueryResultSignature signature = default;
        var content = "Data...";

        var exception = Record.Exception(() => new QueryResult(signature, content));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void ValidSignatureNullContent_ArgumentNullException()
    {
        QueryResultSignature signature = new("NASA/JPL Horizons API", "1.2");
        string content = null!;

        var exception = Record.Exception(() => new QueryResult(signature, content));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
