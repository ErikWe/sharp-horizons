namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using Xunit;

public class Create_MajorObjectAndGeodetic
{
    [Fact]
    public void NullObject_ArgumentNullException() => Executor_Create_MajorObjectAndGeodetic.NullMajorObject_ArgumentNullException(GetService());

    [Fact]
    public void InvalidCooordinate_ArgumentException() => Executor_Create_MajorObjectAndGeodetic.InvalidCooordinate_ArgumentException(GetService());

    [Fact]
    public void NullObjectAndInvalidCoordinate_ArgumentNullException() => Executor_Create_MajorObjectAndGeodetic.NullMajorObjectAndInvalidCoordinate_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectAndGeodetic.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
