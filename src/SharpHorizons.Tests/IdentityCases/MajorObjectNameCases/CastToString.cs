namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void Valid_ExactMatch(MajorObjectName majorObjectName)
    {
        var actual = (string)majorObjectName;

        Assert.Equal(majorObjectName.Value, actual);
    }

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(MajorObjectName));

        Assert.IsType<ArgumentException>(exception);
    }
}
