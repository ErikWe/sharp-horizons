namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;

using Xunit;

public class CreateBuilder_IVectorsQuery
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var vectorsQuery = GetNullVectorsQuery();

        AnyError_TException<ArgumentNullException>(vectorsQuery);
    }

    [Theory]
    [ClassData(typeof(InvalidVectorsQueries))]
    public void Invalid_ArgumentException(IVectorsQuery vectorsQuery)
    {
        AnyError_TException<ArgumentException>(vectorsQuery);
    }

    private static void AnyError_TException<TException>(IVectorsQuery vectorsQuery) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.CreateBuilder(vectorsQuery));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var vectorsQuery = GetValidVectorsQuery();

        var actual = factory.CreateBuilder(vectorsQuery);

        Assert.NotNull(actual);
    }

    private static IVectorsQueryFactory GetService() => DependencyInjection.GetRequiredService<IVectorsQueryFactory>();

    private static IVectorsQuery GetNullVectorsQuery() => null!;
    private static IVectorsQuery GetValidVectorsQuery()
    {
        var factory = GetService();

        return factory.Create(GetValidTarget(), GetValidOrigin(), GetValidEpochSelection());
    }

    private static ITarget GetValidTarget()
    {
        var targetFactory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return targetFactory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetValidOrigin()
    {
        var originFactory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return originFactory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetValidEpochSelection()
    {
        var epochSelectionFactory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return epochSelectionFactory.Create(JulianDay.Epoch);
    }
}
