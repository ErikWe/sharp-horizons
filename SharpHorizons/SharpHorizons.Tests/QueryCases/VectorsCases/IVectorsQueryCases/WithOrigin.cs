namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;

using Xunit;

public class WithOrigin
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var vectorsQuery = GetVectorsQuery();

        var origin = GetNullOrigin();

        var exception = Record.Exception(() => vectorsQuery.WithOrigin(origin));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.Origin;

        var origin = GetDifferentOrigin();

        var actual = vectorsQuery.WithOrigin(origin);

        Assert.NotEqual(previous, origin);
        Assert.Equal(origin, actual.Origin);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.Origin;

        var origin = GetDifferentOrigin();

        vectorsQuery.WithOrigin(origin);

        Assert.NotEqual(previous, origin);
        Assert.Equal(previous, vectorsQuery.Origin);
    }

    private static IVectorsQuery GetVectorsQuery()
    {
        var factory = DependencyInjection.GetRequiredService<IVectorsQueryFactory>();

        return factory.Create(GetValidTarget(), GetValidOrigin(), GetValidEpochSelection());
    }

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

    private static IOrigin GetDifferentOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(10));
    }

    private static IEpochSelection GetValidEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }
}
