namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_VectorCorrection
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var vectorCorrection = GetInvalidVectorCorrection();

        AnyError_TException<InvalidEnumArgumentException>(vectorCorrection);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var vectorCorrection = GetForbiddenVectorCorrection();

        AnyError_TException<ArgumentException>(vectorCorrection);
    }

    private static void AnyError_TException<TException>(VectorCorrection vectorCorrection) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(vectorCorrection));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.Correction;

        var vectorCorrection = GetDifferentVectorCorrection(previous);

        var actual = vectorsQuery.WithConfiguration(vectorCorrection);

        Assert.NotEqual(previous, vectorCorrection);
        Assert.Equal(vectorCorrection, actual.Correction);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.Correction;

        var vectorCorrection = GetDifferentVectorCorrection(previous);

        vectorsQuery.WithConfiguration(vectorCorrection);

        Assert.NotEqual(previous, vectorCorrection);
        Assert.Equal(previous, vectorsQuery.Correction);
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

    private static VectorCorrection GetInvalidVectorCorrection() => (VectorCorrection)(-1);
    private static VectorCorrection GetForbiddenVectorCorrection() => VectorCorrection.Aberration;
    private static VectorCorrection GetDifferentVectorCorrection(VectorCorrection vectorCorrection) => vectorCorrection switch
    {
        VectorCorrection.None => VectorCorrection.LightTime,
        VectorCorrection.LightTime => VectorCorrection.All,
        VectorCorrection.All => VectorCorrection.None,
        _ => throw new InvalidEnumArgumentException()
    };
}
