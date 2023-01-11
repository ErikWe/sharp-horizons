namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMPCCometTargetFactoryCases;

using Xunit;

public class Create_MPCComet
{
    [Fact]
    public void Null_ArgumentNullException() => Executor_Create_MPCComet.Null_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MPCComet.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
