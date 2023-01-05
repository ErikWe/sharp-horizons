namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;

using Xunit;

public class WithEpochSelection
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var vectorsQuery = GetVectorsQuery();

        var epochSelection = GetNullEpochSelection();

        var exception = Record.Exception(() => vectorsQuery.WithEpochSelection(epochSelection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.EpochSelection;

        var epochSelection = GetDifferentEpochSelection();

        var actual = vectorsQuery.WithEpochSelection(epochSelection);

        Assert.NotEqual(previous, epochSelection);
        Assert.Equal(epochSelection, actual.EpochSelection);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.EpochSelection;

        var epochSelection = GetDifferentEpochSelection();

        vectorsQuery.WithEpochSelection(epochSelection);

        Assert.NotEqual(previous, epochSelection);
        Assert.Equal(previous, vectorsQuery.EpochSelection);
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

    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetNullEpochSelection() => null!;
    private static IEpochSelection GetValidEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }

    private static IEpochSelection GetDifferentEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch, new JulianDay(1));
    }
}
