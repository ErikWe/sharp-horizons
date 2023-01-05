namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_OutputFormat
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var outputFormat = GetInvalidOutputFormat();

        AnyError_TException<InvalidEnumArgumentException>(outputFormat);
    }

    [Fact]
    public void Forbidden_ArgumentException()
    {
        var outputFormat = GetForbiddenOutputFormat();

        AnyError_TException<ArgumentException>(outputFormat);
    }

    private static void AnyError_TException<TException>(OutputFormat outputFormat) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(outputFormat));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.OutputFormat;

        var outputFormat = GetDifferentOutputFormat(previous);

        var actual = vectorsQuery.WithConfiguration(outputFormat);

        Assert.NotEqual(previous, outputFormat);
        Assert.Equal(outputFormat, actual.OutputFormat);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.OutputFormat;

        var outputFormat = GetDifferentOutputFormat(previous);

        vectorsQuery.WithConfiguration(outputFormat);

        Assert.NotEqual(previous, outputFormat);
        Assert.Equal(previous, vectorsQuery.OutputFormat);
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

    private static OutputFormat GetInvalidOutputFormat() => (OutputFormat)(-1);
    private static OutputFormat GetForbiddenOutputFormat() => OutputFormat.Unknown;
    private static OutputFormat GetDifferentOutputFormat(OutputFormat outputFormat) => outputFormat switch
    {
        OutputFormat.JSON => OutputFormat.Text,
        OutputFormat.Text => OutputFormat.JSON,
        _ => throw new InvalidEnumArgumentException()
    };
}
