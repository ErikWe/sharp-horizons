namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.IVectorTableContentValidatorCases;

using SharpHorizons.Query.Vectors.Table;

using System;

using Xunit;

public class ThrowIfUnsupported
{
    [Theory]
    [ClassData(typeof(Datasets.SupportedVectorTableContent))]
    public void Supported_NoException(VectorTableContent content)
    {
        var validator = GetService();

        var exception = Record.Exception(() => validator.ThrowIfUnsupported(content));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnsupportedVectorTableContent))]
    public void Unsupported_ArgumentException(VectorTableContent content)
    {
        var validator = GetService();

        var exception = Record.Exception(() => validator.ThrowIfUnsupported(content));

        Assert.IsType<ArgumentException>(exception);
    }

    private static IVectorTableContentValidator GetService() => DependencyInjection.GetRequiredService<IVectorTableContentValidator>();
}
