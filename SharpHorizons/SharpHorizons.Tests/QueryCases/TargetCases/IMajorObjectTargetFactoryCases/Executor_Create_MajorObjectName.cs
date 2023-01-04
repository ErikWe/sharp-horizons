namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MajorObjectName
{
    public static void Invalid_ArgumentException(IMajorObjectTargetFactory factory)
    {
        var target = GetInvalidMajorObjectName();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObjectName();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MajorObjectName GetInvalidMajorObjectName() => default;
    private static MajorObjectName GetValidMajorObjectName() => new("Moon");
}
