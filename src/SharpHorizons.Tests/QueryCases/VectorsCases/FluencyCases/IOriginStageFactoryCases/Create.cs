namespace SharpHorizons.Tests.QueryCases.VectorsCases.FluencyCases.IOriginStageFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

using Xunit;

public class Create
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var factory = GetService();

        var target = GetNullTarget();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var target = GetValidTarget();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static IOriginStageFactory GetService() => DependencyInjection.GetRequiredService<IOriginStageFactory>();

    private static ITarget GetNullTarget() => null!;
    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }
}
