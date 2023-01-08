namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginObjectFactoryCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Create_MajorObjectName
{
    [Fact]
    public void Invalid_ArgumentException()
    {
        var factory = GetService();

        var origin = GetInvalidMajorObjectName();

        var exception = Record.Exception(() => factory.Create(origin));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectName();

        var actual = factory.Create(origin);

        Assert.NotNull(actual);
    }

    private static IOriginObjectFactory GetService() => DependencyInjection.GetRequiredService<IOriginObjectFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Earth");
}
