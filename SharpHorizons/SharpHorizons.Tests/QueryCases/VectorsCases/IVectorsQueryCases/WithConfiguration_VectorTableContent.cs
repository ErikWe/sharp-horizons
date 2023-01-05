namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;

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

        var previous = vectorsQuery.TableContent;

        var vectorTableContent = GetDifferentVectorTableContent(previous);

        var actual = vectorsQuery.WithConfiguration(vectorTableContent);

        Assert.NotEqual(previous, vectorTableContent);
        Assert.Equal(vectorTableContent, actual.TableContent);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.TableContent;

        var vectorTableContent = GetDifferentVectorTableContent(previous);

        vectorsQuery.WithConfiguration(vectorTableContent);

        Assert.NotEqual(previous, vectorTableContent);
        Assert.Equal(previous, vectorsQuery.TableContent);
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
    private static VectorTableContent GetDifferentVectorTableContent(VectorTableContent vectorTableContent) => new(GetDifferentVectorTableQuantities(vectorTableContent.Quantities));

    private static VectorTableQuantities GetDifferentVectorTableQuantities(VectorTableQuantities vectorTableQuantities) => vectorTableQuantities switch
    {
        VectorTableQuantities.Position => VectorTableQuantities.Velocity,
        VectorTableQuantities.Velocity => VectorTableQuantities.Distance,
        VectorTableQuantities.Distance => VectorTableQuantities.StateVectors,
        VectorTableQuantities.StateVectors => VectorTableQuantities.Position | VectorTableQuantities.Distance,
        VectorTableQuantities.Position | VectorTableQuantities.Distance => VectorTableQuantities.All,
        VectorTableQuantities.All => VectorTableQuantities.Position,
        _ => throw new InvalidEnumArgumentException()
    };
}
