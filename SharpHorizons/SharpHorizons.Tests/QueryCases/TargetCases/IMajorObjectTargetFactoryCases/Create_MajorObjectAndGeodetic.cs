namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

public class Create_MajorObjectAndGeodetic
{
    [Fact]
    public void NullMajorObject_ArgumentNullException() => Executor_Create_MajorObjectAndGeodetic.NullMajorObject_ArgumentNullException(GetService());

    [Fact]
    public void InvalidCooordinate_ArgumentException() => Executor_Create_MajorObjectAndGeodetic.InvalidCooordinate_ArgumentException(GetService());

    [Fact]
    public void NullMajorObjectAndInvalidCoordinate_ArgumentNullException() => Executor_Create_MajorObjectAndGeodetic.NullMajorObjectAndInvalidCoordinate_ArgumentNullException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MajorObjectAndGeodetic.Valid_NotNull(GetService());

    private static IMajorObjectTargetFactory GetService() => DependencyInjection.GetRequiredService<IMajorObjectTargetFactory>();
}
