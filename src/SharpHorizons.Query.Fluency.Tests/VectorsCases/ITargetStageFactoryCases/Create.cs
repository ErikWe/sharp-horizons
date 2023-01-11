namespace SharpHorizons.Tests.QueryCases.FluencyCases.VectorsCases.ITargetStageFactoryCases;

using SharpHorizons.Query.Vectors.Fluency;

using Xunit;

public class Create
{
    [Fact]
    public void NotNull()
    {
        var factory = GetService();

        var actual = factory.Create();

        Assert.NotNull(actual);
    }

    private static ITargetStageFactory GetService() => DependencyInjection.GetRequiredService<ITargetStageFactory>();
}
