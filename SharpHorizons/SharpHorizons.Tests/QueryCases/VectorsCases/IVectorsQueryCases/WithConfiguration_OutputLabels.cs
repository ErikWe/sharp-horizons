namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System.ComponentModel;

using Xunit;

public class WithConfiguration_OutputLabels
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var vectorsQuery = GetVectorsQuery();

        var outputLabels = GetInvalidOutputLabels();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(outputLabels));

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var outputLabels = GetValidOutputLabels();

        var actual = vectorsQuery.WithConfiguration(outputLabels);

        Assert.Equal(outputLabels, actual.OutputLabels);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var expected = vectorsQuery.OutputLabels;

        var outputLabels = GetValidOutputLabels();

        vectorsQuery.WithConfiguration(outputLabels);

        Assert.NotEqual(expected, outputLabels);
        Assert.Equal(expected, vectorsQuery.OutputLabels);
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

    private static OutputLabels GetInvalidOutputLabels() => (OutputLabels)(-1);
    private static OutputLabels GetValidOutputLabels() => OutputLabels.Enable;
}
