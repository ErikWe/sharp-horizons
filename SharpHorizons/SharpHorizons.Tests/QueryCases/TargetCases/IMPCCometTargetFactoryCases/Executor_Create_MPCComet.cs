namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCCometTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCComet
{
    public static void Null_ArgumentNullException(IMPCCometTargetFactory factory)
    {
        var target = GetNullMPCComet();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_NotNull(IMPCCometTargetFactory factory)
    {
        var target = GetValidMPCComet();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCComet GetNullMPCComet() => null!;
    private static MPCComet GetValidMPCComet() => new(new MPCCometDesignation("1P"));
}
