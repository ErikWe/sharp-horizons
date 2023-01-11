namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectIDAndITargetSite
{
    [Fact]
    public void NullCoordinate_ArgumentNullException() => Executor_Create_MajorObjectIDAndITargetSite.NullCoordinate_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectIDAndITargetSite.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
