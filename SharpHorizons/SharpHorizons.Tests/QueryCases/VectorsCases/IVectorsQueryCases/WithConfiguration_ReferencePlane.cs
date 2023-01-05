namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_ReferencePlane
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var referencePlane = GetInvalidReferencePlane();

        AnyError_TException<InvalidEnumArgumentException>(referencePlane);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var referencePlane = GetForbiddenReferencePlane();

        AnyError_TException<ArgumentException>(referencePlane);
    }

    private static void AnyError_TException<TException>(ReferencePlane referencePlane) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(referencePlane));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.ReferencePlane;

        var referencePlane = GetDifferentReferencePlane(previous);

        var actual = vectorsQuery.WithConfiguration(referencePlane);

        Assert.NotEqual(previous, referencePlane);
        Assert.Equal(referencePlane, actual.ReferencePlane);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.ReferencePlane;

        var referencePlane = GetDifferentReferencePlane(previous);

        vectorsQuery.WithConfiguration(referencePlane);

        Assert.NotEqual(previous, referencePlane);
        Assert.Equal(previous, vectorsQuery.ReferencePlane);
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

    private static ReferencePlane GetInvalidReferencePlane() => (ReferencePlane)(-1);
    private static ReferencePlane GetForbiddenReferencePlane() => ReferencePlane.Unknown;
    private static ReferencePlane GetDifferentReferencePlane(ReferencePlane referencePlane) => referencePlane switch
    {
        ReferencePlane.Ecliptic => ReferencePlane.Frame,
        ReferencePlane.Frame => ReferencePlane.BodyEquator,
        ReferencePlane.BodyEquator => ReferencePlane.Ecliptic,
        _ => throw new InvalidEnumArgumentException()
    };
}
