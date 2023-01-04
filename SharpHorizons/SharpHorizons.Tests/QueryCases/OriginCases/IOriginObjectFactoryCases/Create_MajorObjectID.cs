namespace SharpHorizons.Tests.QueryCases.OriginCases.IOriginObjectFactoryCases;

using SharpHorizons.Query.Origin;

using Xunit;

public class Create_MajorObjectID
{
    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var origin = GetValidMajorObjectID();

        var actual = factory.Create(origin);

        Assert.NotNull(actual);
    }

    private static IOriginObjectFactory GetService() => DependencyInjection.GetRequiredService<IOriginObjectFactory>();

    private static MajorObjectID GetValidMajorObjectID() => new(399);
}
