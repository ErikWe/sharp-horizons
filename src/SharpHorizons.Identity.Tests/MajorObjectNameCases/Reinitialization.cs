namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = InitialMajorObjectName with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialMajorObjectName with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialMajorObjectName with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static MajorObjectName InitialMajorObjectName => new("Earth");
}
