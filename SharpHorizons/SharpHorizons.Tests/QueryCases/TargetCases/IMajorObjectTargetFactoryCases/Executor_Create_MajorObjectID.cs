namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using Xunit;

internal static class Executor_Create_MajorObjectID
{
    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectID();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MajorObjectID GetValidMajorObjectID() => new(301);
}
