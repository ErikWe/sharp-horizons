namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_OutputUnits
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var outputUnits = GetInvalidOutputUnits();

        AnyError_TException<InvalidEnumArgumentException>(outputUnits);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var outputUnits = GetForbiddenOutputUnits();

        AnyError_TException<ArgumentException>(outputUnits);
    }

    private static void AnyError_TException<TException>(OutputUnits outputUnits) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(outputUnits));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.OutputUnits;

        var outputUnits = GetDifferentOutputUnits(previous);

        var actual = vectorsQuery.WithConfiguration(outputUnits);

        Assert.NotEqual(previous, outputUnits);
        Assert.Equal(outputUnits, actual.OutputUnits);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.OutputUnits;

        var outputUnits = GetDifferentOutputUnits(previous);

        vectorsQuery.WithConfiguration(outputUnits);

        Assert.NotEqual(previous, outputUnits);
        Assert.Equal(previous, vectorsQuery.OutputUnits);
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

    private static OutputUnits GetInvalidOutputUnits() => (OutputUnits)(-1);
    private static OutputUnits GetForbiddenOutputUnits() => OutputUnits.Unknown;
    private static OutputUnits GetDifferentOutputUnits(OutputUnits outputUnits) => outputUnits switch
    {
        OutputUnits.KilometresAndSeconds => OutputUnits.KilometresAndDays,
        OutputUnits.KilometresAndDays => OutputUnits.AstronomicalUnitsAndDays,
        OutputUnits.AstronomicalUnitsAndDays => OutputUnits.KilometresAndSeconds,
        _ => throw new InvalidEnumArgumentException()
    };
}
