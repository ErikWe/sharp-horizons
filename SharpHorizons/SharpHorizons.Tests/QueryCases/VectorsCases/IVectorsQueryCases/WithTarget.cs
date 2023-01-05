namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;

using Xunit;

public class WithTarget
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var vectorsQuery = GetVectorsQuery();

        var target = GetNullTarget();

        var exception = Record.Exception(() => vectorsQuery.WithTarget(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.Target;

        var target = GetDifferentTarget();

        var actual = vectorsQuery.WithTarget(target);

        Assert.NotEqual(previous, target);
        Assert.Equal(target, actual.Target);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.Target;

        var target = GetDifferentTarget();

        vectorsQuery.WithTarget(target);

        Assert.NotEqual(previous, target);
        Assert.Equal(previous, vectorsQuery.Target);
    }

    private static IVectorsQuery GetVectorsQuery()
    {
        var factory = DependencyInjection.GetRequiredService<IVectorsQueryFactory>();

        return factory.Create(GetValidTarget(), GetValidOrigin(), GetValidEpochSelection());
    }

    private static ITarget GetNullTarget() => null!;
    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static ITarget GetDifferentTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(499));
    }

    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetValidEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }
}
