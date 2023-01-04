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

        var referenceSystem = GetValidReferenceSystem();

        var actual = vectorsQuery.WithConfiguration(referenceSystem);

        Assert.Equal(referenceSystem, actual.ReferenceSystem);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var expected = vectorsQuery.ReferenceSystem;

        var referenceSystem = GetValidReferenceSystem();

        vectorsQuery.WithConfiguration(referenceSystem);

        Assert.NotEqual(expected, referenceSystem);
        Assert.Equal(expected, vectorsQuery.ReferenceSystem);
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
    private static ReferenceSystem GetValidReferenceSystem() => ReferenceSystem.B1950;
}
