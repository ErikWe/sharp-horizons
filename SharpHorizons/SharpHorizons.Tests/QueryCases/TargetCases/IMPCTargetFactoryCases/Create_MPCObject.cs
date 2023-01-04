namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MPCObject
{
    [Fact]
    public void Null_ArgumentNullException() => Executor_Create_MPCObject.Null_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MPCObject.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
