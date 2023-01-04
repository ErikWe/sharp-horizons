namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.IVectorTableContentValidatorCases;

using SharpHorizons.Query.Vectors.Table;

using Xunit;

public class CheckSupport
{
    [Theory]
    [ClassData(typeof(Datasets.SupportedVectorTableContent))]
    public void Supported_True(VectorTableContent content)
    {
        var validator = GetService();

        var actual = validator.CheckSupport(content);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnsupportedVectorTableContent))]
    public void Unsupported_False(VectorTableContent content)
    {
        var validator = GetService();

        var actual = validator.CheckSupport(content);

        Assert.False(actual);
    }

    private static IVectorTableContentValidator GetService() => DependencyInjection.GetRequiredService<IVectorTableContentValidator>();
}
