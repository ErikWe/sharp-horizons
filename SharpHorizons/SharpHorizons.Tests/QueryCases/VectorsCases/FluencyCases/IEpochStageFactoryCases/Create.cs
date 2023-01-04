namespace SharpHorizons.Tests.QueryCases.VectorsCases.FluencyCases.IEpochStageFactoryCases;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

using Xunit;

public class Create
{
    [Fact]
    public void NullTarget_ArgumentNullException()
    {
        var target = GetInvalidTarget();
        var origin = GetValidOrigin();

        EitherNull_ArgumentNullException(target, origin);
    }

    [Fact]
    public void NullOrigin_ArgumentNullException()
    {
        var target = GetValidTarget();
        var origin = GetInvalidOrigin();

        EitherNull_ArgumentNullException(target, origin);
    }

    [Fact]
    public void NullOriginAndTarget_ArgumentNullException()
    {
        var target = GetInvalidTarget();
        var origin = GetInvalidOrigin();

        EitherNull_ArgumentNullException(target, origin);
    }

    private static void EitherNull_ArgumentNullException(ITarget target, IOrigin origin)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(target, origin));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var target = GetValidTarget();
        var origin = GetValidOrigin();

        var actual = factory.Create(target, origin);

        Assert.NotNull(actual);
    }

    private static IEpochStageFactory GetService() => DependencyInjection.GetRequiredService<IEpochStageFactory>();

    private static ITarget GetInvalidTarget() => null!;
    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetInvalidOrigin() => null!;
    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }
}
