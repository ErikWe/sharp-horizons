namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.IVectorTableQuantitiesValidatorCases;

using SharpHorizons.Query.Vectors.Table;

using Xunit;

public class CheckSupport
{
    [Theory]
    [ClassData(typeof(Datasets.SupportedVectorTableQuantities))]
    public void Supported_True(VectorTableQuantities quantities)
    {
        var validator = GetService();

        var actual = validator.CheckSupport(quantities);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnsupportedVectorTableQuantities))]
    public void Unsupported_False(VectorTableQuantities quantities)
    {
        var validator = GetService();

        var actual = validator.CheckSupport(quantities);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidVectorTableQuantities))]
    public void Invalid_False(VectorTableQuantities quantities)
    {
        var validator = GetService();

        var actual = validator.CheckSupport(quantities);

        Assert.False(actual);
    }

    private static IVectorTableQuantitiesValidator GetService() => DependencyInjection.GetRequiredService<IVectorTableQuantitiesValidator>();
}
