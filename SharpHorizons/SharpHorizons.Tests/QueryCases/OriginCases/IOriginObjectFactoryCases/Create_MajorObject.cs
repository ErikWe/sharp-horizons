namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginObjectFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObject
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var factory = GetService();

        var origin = GetInvalidMajorObject();

        var exception = Record.Exception(() => factory.Create(origin));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObject();

        var actual = factory.Create(origin);

        Assert.NotNull(actual);
    }

    private static IOriginObjectFactory GetService() => DependencyInjection.GetRequiredService<IOriginObjectFactory>();

    private static MajorObject GetInvalidMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(399));
}
