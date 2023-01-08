namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        MajorObjectName actual = new() { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MajorObjectName() { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MajorObjectName() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
