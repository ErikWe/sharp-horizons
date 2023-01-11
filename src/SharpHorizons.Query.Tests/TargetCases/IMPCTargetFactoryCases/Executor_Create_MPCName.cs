namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCName
{
    public static void Invalid_ArgumentException(ITargetFactory factory)
    {
        var target = GetInvalidMPCName();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(ITargetFactory factory)
    {
        var target = GetValidMPCName();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCName GetInvalidMPCName() => default;
    private static MPCName GetValidMPCName() => new("Ceres");
}
