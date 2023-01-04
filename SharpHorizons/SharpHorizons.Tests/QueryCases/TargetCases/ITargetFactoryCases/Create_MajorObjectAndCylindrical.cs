namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectAndCylindrical
{
    [Fact]
    public void NullObject_ArgumentNullException() => Executor_Create_MajorObjectAndCylindrical.NullObject_ArgumentNullException(GetService());

    [Fact]
    public void InvalidCooordinate_ArgumentException() => Executor_Create_MajorObjectAndCylindrical.InvalidCooordinate_ArgumentException(GetService());

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException() => Executor_Create_MajorObjectAndCylindrical.NullObjectAndInvalidCoordinate_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectAndCylindrical.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
