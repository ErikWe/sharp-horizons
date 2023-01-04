namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_TimePrecision
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var timePrecision = GetInvalidTimePrecision();

        AnyError_TException<InvalidEnumArgumentException>(timePrecision);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var timePrecision = GetForbiddenTimePrecision();

        AnyError_TException<ArgumentException>(timePrecision);
    }

    private static void AnyError_TException<TException>(TimePrecision timePrecision) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(timePrecision));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var timePrecision = GetValidTimePrecision();

        var actual = vectorsQuery.WithConfiguration(timePrecision);

        Assert.Equal(timePrecision, actual.TimePrecision);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var expected = vectorsQuery.TimePrecision;

        var timePrecision = GetValidTimePrecision();

        vectorsQuery.WithConfiguration(timePrecision);

        Assert.NotEqual(expected, timePrecision);
        Assert.Equal(expected, vectorsQuery.TimePrecision);
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

    private static TimePrecision GetInvalidTimePrecision() => (TimePrecision)(-1);
    private static TimePrecision GetForbiddenTimePrecision() => TimePrecision.Unknown;
    private static TimePrecision GetValidTimePrecision() => TimePrecision.Minute;
}
