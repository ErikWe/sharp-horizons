namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectID
{
    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectID.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
