namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using System;

using Xunit;

public class WithConfiguration_VectorTableContent
{
    [Fact]
    public void Invalid_ArgumentException()
    {
        var vectorsQuery = GetVectorsQuery();

        var vectorTableContent = GetInvalidVectorTableContent();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(vectorTableContent));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var vectorTableContent = GetValidVectorTableContent();

        var actual = vectorsQuery.WithConfiguration(vectorTableContent);

        Assert.Equal(vectorTableContent, actual.TableContent);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var expected = vectorsQuery.TableContent;

        var vectorTableContent = GetValidVectorTableContent();

        vectorsQuery.WithConfiguration(vectorTableContent);

        Assert.NotEqual(expected, vectorTableContent);
        Assert.Equal(expected, vectorsQuery.TableContent);
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

    private static VectorTableContent GetInvalidVectorTableContent() => new(VectorTableQuantities.All, VectorTableUncertainties.XYZ);
    private static VectorTableContent GetValidVectorTableContent() => new(VectorTableQuantities.All);
}
