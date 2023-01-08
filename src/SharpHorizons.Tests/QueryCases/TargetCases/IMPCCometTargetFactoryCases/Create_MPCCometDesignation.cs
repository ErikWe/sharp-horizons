namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCCometTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MPCCometDesignation
{
    [Fact]
    public void Invalid_ArgumentException() => Executor_Create_MPCCometDesignation.Invalid_ArgumentException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MPCCometDesignation.Valid_NotNull(GetService());

    private static IMPCCometTargetFactory GetService() => DependencyInjection.GetRequiredService<IMPCCometTargetFactory>();
}
