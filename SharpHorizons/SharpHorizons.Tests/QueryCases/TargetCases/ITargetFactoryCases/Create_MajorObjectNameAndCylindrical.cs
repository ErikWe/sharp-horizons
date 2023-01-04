namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectNameAndCylindrical
{
    [Fact]
    public void InvalidName_ArgumentException() => Executor_Create_MajorObjectNameAndCylindrical.InvalidName_ArgumentException(GetService());

    [Fact]
    public void InvalidCooordinate_ArgumentException() => Executor_Create_MajorObjectNameAndCylindrical.InvalidCooordinate_ArgumentException(GetService());

    [Fact]
    public void InvalidNameAndCoordinate_ArgumentException() => Executor_Create_MajorObjectNameAndCylindrical.InvalidNameAndCoordinate_ArgumentException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectNameAndCylindrical.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
