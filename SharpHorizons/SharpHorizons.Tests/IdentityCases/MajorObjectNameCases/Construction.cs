namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        MajorObjectName actual = new(name);

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MajorObjectName(name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MajorObjectName(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void Initialization_Valid_ExactMatch(string name)
    {
        MajorObjectName actual = new() { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void Initialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MajorObjectName() { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MajorObjectName() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void Reinitialization_Valid_ExactMatch(string name)
    {
        var actual = new MajorObjectName("Earth") with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MajorObjectName("Earth") with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MajorObjectName("Earth") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNameStrings))]
    public void CastFromInt_ExactMatch(string name)
    {
        var actual = (MajorObjectName)name;

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNameStrings))]
    public void CastFromInt_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => (MajorObjectName)name);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void CastFromInt_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (MajorObjectName)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
