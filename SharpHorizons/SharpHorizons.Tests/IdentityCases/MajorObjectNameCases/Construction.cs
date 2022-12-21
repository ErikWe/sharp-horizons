namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Construction
{
    [Theory]
    [MemberData(nameof(ValidMajorObjectNames))]
    public void Valid_ExactMatch(string name)
    {
        MajorObjectName majorObjectName = new(name);

        Assert.Equal(name, majorObjectName.Value);
    }

    [Fact]
    public void EmptyString_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new MajorObjectName(string.Empty));
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new MajorObjectName(null!));
    }

    [Theory]
    [MemberData(nameof(ValidMajorObjectNames))]
    public void Initialization_Valid_ExactMatch(string name)
    {
        MajorObjectName majorObjectName = new() { Value = name };

        Assert.Equal(name, majorObjectName.Value);
    }

    [Fact]
    public void Initialization_EmptyString_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new MajorObjectName() { Value = string.Empty });
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new MajorObjectName() { Value = null! });
    }

    [Theory]
    [MemberData(nameof(ValidMajorObjectNames))]
    public void CastFromInt_ExactMatch(string name)
    {
        var majorObjectName = (MajorObjectName)name;

        Assert.Equal(name, majorObjectName.Value);
    }

    [Fact]
    public void CastFromInt_EmptyString_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => (MajorObjectName)string.Empty);
    }

    [Fact]
    public void CastFromInt_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (MajorObjectName)null!);
    }

    public static IEnumerable<object[]> ValidMajorObjectNames() => new object[][]
    {
        new object[] { "Earth" },
        new object[] { "Earth Barycenter" },
        new object[] { "*-0a +?!&%" }
    };
}
