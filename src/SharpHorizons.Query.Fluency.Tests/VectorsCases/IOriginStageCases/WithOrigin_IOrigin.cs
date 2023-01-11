namespace SharpHorizons.Tests.QueryCases.FluencyCases.VectorsCases.IOriginStageCases;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

using Xunit;

public class WithOrigin_IOrigin
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var originStage = GetOriginStage();

        var origin = GetNullOrigin();

        var exception = Record.Exception(() => originStage.WithOrigin(origin));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var originStage = GetOriginStage();

        var origin = GetValidOrigin();

        var actual = originStage.WithOrigin(origin);

        Assert.NotNull(actual);
    }

    private static IOriginStage GetOriginStage() => DependencyInjection.GetRequiredService<IOriginStageFactory>().Create(GetValidTarget());

    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetNullOrigin() => null!;
    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }
}
