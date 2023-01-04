namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetObjectFactoryCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Create_MajorObject
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var factory = GetService();

        var target = GetInvalidMajorObject();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var target = GetValidMajorObject();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static ITargetObjectFactory GetService() => DependencyInjection.GetRequiredService<ITargetObjectFactory>();

    private static MajorObject GetInvalidMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(301));
}
