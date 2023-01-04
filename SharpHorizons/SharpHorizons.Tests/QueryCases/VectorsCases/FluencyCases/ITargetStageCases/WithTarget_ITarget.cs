namespace SharpHorizons.Tests.QueryCases.VectorsCases.FluencyCases.ITargetStageCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

using Xunit;

public class WithTarget_ITarget
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var targetStage = GetTargetStage();

        var target = GetInvalidTarget();

        var exception = Record.Exception(() => targetStage.WithTarget(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var targetStage = GetTargetStage();

        var target = GetValidTarget();

        var actual = targetStage.WithTarget(target);

        Assert.NotNull(actual);
    }

    private static ITargetStage GetTargetStage() => DependencyInjection.GetRequiredService<ITargetStageFactory>().Create();

    private static ITarget GetInvalidTarget() => null!;
    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }
}
