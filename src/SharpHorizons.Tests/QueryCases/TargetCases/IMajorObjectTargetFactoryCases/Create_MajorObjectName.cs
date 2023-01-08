namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MajorObjectName
{
    [Fact]
    public void Invalid_ArgumentException() => Executor_Create_MajorObjectName.Invalid_ArgumentException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectName.Valid_NotNull(GetService());

    private static IMajorObjectTargetFactory GetService() => DependencyInjection.GetRequiredService<IMajorObjectTargetFactory>();
}
