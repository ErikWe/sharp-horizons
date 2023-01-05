namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_ReferenceSystem
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var referenceSystem = GetInvalidReferenceSystem();

        AnyError_TException<InvalidEnumArgumentException>(referenceSystem);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var referenceSystem = GetForbiddenReferenceSystem();

        AnyError_TException<ArgumentException>(referenceSystem);
    }

    private static void AnyError_TException<TException>(ReferenceSystem referenceSystem) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(referenceSystem));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.ReferenceSystem;

        var referenceSystem = GetDifferentReferenceSystem(previous);

        var actual = vectorsQuery.WithConfiguration(referenceSystem);

        Assert.NotEqual(previous, referenceSystem);
        Assert.Equal(referenceSystem, actual.ReferenceSystem);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.ReferenceSystem;

        var referenceSystem = GetDifferentReferenceSystem(previous);

        vectorsQuery.WithConfiguration(referenceSystem);

        Assert.NotEqual(previous, referenceSystem);
        Assert.Equal(previous, vectorsQuery.ReferenceSystem);
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

    private static ReferenceSystem GetInvalidReferenceSystem() => (ReferenceSystem)(-1);
    private static ReferenceSystem GetForbiddenReferenceSystem() => ReferenceSystem.Unknown;
    private static ReferenceSystem GetDifferentReferenceSystem(ReferenceSystem referenceSystem) => referenceSystem switch
    {
        ReferenceSystem.ICRF => ReferenceSystem.B1950,
        ReferenceSystem.B1950 => ReferenceSystem.ICRF,
        _ => throw new InvalidEnumArgumentException()
    };
}
