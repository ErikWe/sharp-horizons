namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_ValueSeparation
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var valueSeparation = GetInvalidValueSeparation();

        AnyError_TException<InvalidEnumArgumentException>(valueSeparation);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var valueSeparation = GetForbiddenValueSeparation();

        AnyError_TException<ArgumentException>(valueSeparation);
    }

    private static void AnyError_TException<TException>(ValueSeparation valueSeparation) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(valueSeparation));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.ValueSeparation;

        var valueSeparation = GetDifferentValueSeparation(previous);

        var actual = vectorsQuery.WithConfiguration(valueSeparation);

        Assert.NotEqual(previous, valueSeparation);
        Assert.Equal(valueSeparation, actual.ValueSeparation);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.ValueSeparation;

        var valueSeparation = GetDifferentValueSeparation(previous);

        vectorsQuery.WithConfiguration(valueSeparation);

        Assert.NotEqual(previous, valueSeparation);
        Assert.Equal(previous, vectorsQuery.ValueSeparation);
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

    private static ValueSeparation GetInvalidValueSeparation() => (ValueSeparation)(-1);
    private static ValueSeparation GetForbiddenValueSeparation() => ValueSeparation.Unknown;
    private static ValueSeparation GetDifferentValueSeparation(ValueSeparation valueSeparation) => valueSeparation switch
    {
        ValueSeparation.WhitespaceSeparation => ValueSeparation.CommaSeparation,
        ValueSeparation.CommaSeparation => ValueSeparation.WhitespaceSeparation,
        _ => throw new InvalidEnumArgumentException()
    };
}
