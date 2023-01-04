namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectNameAndITargetSite
{
    [Fact]
    public void InvalidName_ArgumentException() => Executor_Create_MajorObjectNameAndITargetSite.InvalidName_ArgumentException(GetService());

    [Fact]
    public void NullSite_ArgumentNullException() => Executor_Create_MajorObjectNameAndITargetSite.NullSite_ArgumentNullException(GetService());

    [Fact]
    public void InvalidNameAndNullSite_ArgumentNullException() => Executor_Create_MajorObjectNameAndITargetSite.InvalidNameAndNullSite_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectNameAndITargetSite.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
