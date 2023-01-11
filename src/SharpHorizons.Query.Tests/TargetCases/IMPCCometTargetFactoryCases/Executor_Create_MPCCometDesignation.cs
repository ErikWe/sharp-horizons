namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCCometTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCCometDesignation
{
    public static void Invalid_ArgumentException(IMPCCometTargetFactory factory)
    {
        var target = GetInvalidMPCCometDesignation();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(IMPCCometTargetFactory factory)
    {
        var target = GetValidMPCCometDesignation();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCCometDesignation GetInvalidMPCCometDesignation() => default;
    private static MPCCometDesignation GetValidMPCCometDesignation() => new("1P");
}
