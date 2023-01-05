namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Create_ITargetObject
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var factory = GetService();

        var targetObject = GetNullTargetObject();

        var exception = Record.Exception(() => factory.Create(targetObject));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var targetObject = GetValidTargetObject();

        var actual = factory.Create(targetObject);

        Assert.NotNull(actual);
    }

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();

    private static ITargetObject GetNullTargetObject() => null!;
    private static ITargetObject GetValidTargetObject()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetObjectFactory>();

        return factory.Create(new MajorObjectID(301));
    }
}
