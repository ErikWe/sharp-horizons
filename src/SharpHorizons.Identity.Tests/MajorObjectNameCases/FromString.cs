namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class FromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = MajorObjectName.FromString(name);

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => MajorObjectName.FromString(name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => MajorObjectName.FromString(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
