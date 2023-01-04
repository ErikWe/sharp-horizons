﻿namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System.ComponentModel;

using Xunit;

public class WithConfiguration_ObjectDataInclusion
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var vectorsQuery = GetVectorsQuery();

        var objectDataInclusion = GetInvalidObjectDataInclusion();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(objectDataInclusion));

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var objectDataInclusion = GetValidObjectDataInclusion();

        var actual = vectorsQuery.WithConfiguration(objectDataInclusion);

        Assert.Equal(objectDataInclusion, actual.ObjectDataInclusion);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var expected = vectorsQuery.ObjectDataInclusion;

        var objectDataInclusion = GetValidObjectDataInclusion();

        vectorsQuery.WithConfiguration(objectDataInclusion);

        Assert.NotEqual(expected, objectDataInclusion);
        Assert.Equal(expected, vectorsQuery.ObjectDataInclusion);
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

    private static IEpochSelection GetValidEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }

    private static ObjectDataInclusion GetInvalidObjectDataInclusion() => (ObjectDataInclusion)(-1);
    private static ObjectDataInclusion GetValidObjectDataInclusion() => ObjectDataInclusion.Enable;
}
