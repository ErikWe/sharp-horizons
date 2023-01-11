namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryComposerCases;

using SharpHorizons.Query.Vectors;

using System;

using Xunit;

public class Compose
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var vectorsQuery = GetNullVectorsQuery();

        AnyError_TException<ArgumentNullException>(vectorsQuery);
    }

    private static void AnyError_TException<TException>(IVectorsQuery vectorsQuery) where TException : Exception
    {
        var composer = GetService();

        var exception = Record.Exception(() => composer.Compose(vectorsQuery));

        Assert.IsType<TException>(exception);
    }

    private static IVectorsQueryComposer GetService() => DependencyInjection.GetRequiredService<IVectorsQueryComposer>();

    private static IVectorsQuery GetNullVectorsQuery() => null!;
}
