namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetObjectFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MajorObjectID
{
    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var target = GetValidMajorObjectID();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static ITargetObjectFactory GetService() => DependencyInjection.GetRequiredService<ITargetObjectFactory>();

    private static MajorObjectID GetValidMajorObjectID() => new(301);
}
