namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(MajorObjectName).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void ValueAccess_Valid_NoException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => majorObjectName.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => MajorObjectName.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void Validate_Valid_NoException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => MajorObjectName.Validate(majorObjectName));

        Assert.Null(exception);
    }
}
