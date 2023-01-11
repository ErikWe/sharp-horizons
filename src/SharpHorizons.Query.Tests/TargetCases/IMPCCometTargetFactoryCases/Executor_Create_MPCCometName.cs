namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCCometTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCCometName
{
    public static void Invalid_ArgumentException(IMPCCometTargetFactory factory)
    {
        var target = GetInvalidMPCCometName();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(IMPCCometTargetFactory factory)
    {
        var target = GetValidMPCCometName();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCCometName GetInvalidMPCCometName() => default;
    private static MPCCometName GetValidMPCCometName() => new("Halley");
}
