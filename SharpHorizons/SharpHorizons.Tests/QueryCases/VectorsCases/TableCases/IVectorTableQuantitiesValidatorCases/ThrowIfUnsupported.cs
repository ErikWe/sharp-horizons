namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.IVectorTableQuantitiesValidatorCases;

using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;

using Xunit;

public class ThrowIfUnsupported
{
    [Theory]
    [ClassData(typeof(Datasets.SupportedVectorTableQuantities))]
    public void Supported_NoException(VectorTableQuantities quantities)
    {
        var validator = GetService();

        var exception = Record.Exception(() => validator.ThrowIfUnsupported(quantities));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnsupportedVectorTableQuantities))]
    public void Unsupported_ArgumentException(VectorTableQuantities quantities)
    {
        var validator = GetService();

        var exception = Record.Exception(() => validator.ThrowIfUnsupported(quantities));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidVectorTableQuantities))]
    public void Invalid_InvalidEnumArgumentException(VectorTableQuantities quantities)
    {
        var validator = GetService();

        var exception = Record.Exception(() => validator.ThrowIfUnsupported(quantities));

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }

    private static IVectorTableQuantitiesValidator GetService() => DependencyInjection.GetRequiredService<IVectorTableQuantitiesValidator>();
}
