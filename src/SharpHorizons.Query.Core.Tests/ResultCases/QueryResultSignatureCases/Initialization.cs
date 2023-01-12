namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultSignatureCases;

using SharpHorizons.Query.Result;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidQueryResultSignatureTuples))]
    public void Valid_ExactMatch(string source, string version)
    {
        QueryResultSignature actual = new() { Source = source, Version = version };

        Assert.Equal(source, actual.Source);
        Assert.Equal(version, actual.Version);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidQueryResultSignatureTuples))]
    public void BothInvalid_ArgumentException(string source, string version)
    {
        var exception = Record.Exception(() => new QueryResultSignature() { Source = source, Version = version });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void BothNull_ArgumentNullException()
    {
        string source = null!;
        string version = null!;

        var exception = Record.Exception(() => new QueryResultSignature() { Source = source, Version = version });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void InvalidSourceNullVersion_ArgumentException()
    {
        var source = string.Empty;
        string version = null!;

        var exception = Record.Exception(() => new QueryResultSignature() { Source = source, Version = version });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void NullSourceInvalidVersion_ArgumentNullException()
    {
        string source = null!;
        var version = string.Empty;

        var exception = Record.Exception(() => new QueryResultSignature() { Source = source, Version = version });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void InvalidSourceValidVersion_ArgumentException()
    {
        var source = string.Empty;
        var version = "1.2";

        var exception = Record.Exception(() => new QueryResultSignature() { Source = source, Version = version });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void ValidSourceInvalidVersion_ArgumentException()
    {
        var source = "NASA/JPL Horizons API";
        var version = string.Empty;

        var exception = Record.Exception(() => new QueryResultSignature() { Source = source, Version = version });

        Assert.IsType<ArgumentException>(exception);
    }
}
