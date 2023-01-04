namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MPCProvisionalObject
{
    [Fact]
    public void Invalid_ArgumentException() => Executor_Create_MPCProvisionalObject.Invalid_ArgumentException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MPCProvisionalObject.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
