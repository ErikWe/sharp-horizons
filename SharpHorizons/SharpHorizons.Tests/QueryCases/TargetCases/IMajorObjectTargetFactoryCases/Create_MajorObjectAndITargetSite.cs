namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MajorObjectAndITargetSite
{
    [Fact]
    public void NullObject_ArgumentNullException() => Executor_Create_MajorObjectAndITargetSite.NullObject_ArgumentNullException(GetService());

    [Fact]
    public void NullSite_ArgumentNullException() => Executor_Create_MajorObjectAndITargetSite.NullSite_ArgumentNullException(GetService());

    [Fact]
    public void NullObjectAndSite_ArgumentNullException() => Executor_Create_MajorObjectAndITargetSite.NullObjectAndSite_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectAndITargetSite.Valid_NotNull(GetService());

    private static IMajorObjectTargetFactory GetService() => DependencyInjection.GetRequiredService<IMajorObjectTargetFactory>();
}
