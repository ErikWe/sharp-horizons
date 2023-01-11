namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectNameAndGeodetic
{
    [Fact]
    public void InvalidName_ArgumentException() => Executor_Create_MajorObjectNameAndGeodetic.InvalidName_ArgumentException(GetService());

    [Fact]
    public void InvalidCooordinate_ArgumentException() => Executor_Create_MajorObjectNameAndGeodetic.InvalidCooordinate_ArgumentException(GetService());

    [Fact]
    public void InvalidNameAndCoordinate_ArgumentException() => Executor_Create_MajorObjectNameAndGeodetic.InvalidNameAndCoordinate_ArgumentException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectNameAndGeodetic.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
