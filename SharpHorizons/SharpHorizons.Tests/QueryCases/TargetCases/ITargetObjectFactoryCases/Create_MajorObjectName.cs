namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetObjectFactoryCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Create_MajorObjectName
{
    [Fact]
    public void Invalid_ArgumentException()
    {
        var factory = GetService();

        var target = GetInvalidMajorObjectName();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var target = GetValidMajorObjectName();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static ITargetObjectFactory GetService() => DependencyInjection.GetRequiredService<ITargetObjectFactory>();

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Moon");
}
