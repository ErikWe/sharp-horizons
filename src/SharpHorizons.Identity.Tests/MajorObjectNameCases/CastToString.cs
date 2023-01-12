namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void Valid_ExactMatchValue(MajorObjectName majorObjectName)
    {
        var expected = majorObjectName.Value;

        var actual = (string)majorObjectName;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNames))]
    public void Invalid_ArgumentException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => (string)majorObjectName);

        Assert.IsType<ArgumentException>(exception);
    }
}
