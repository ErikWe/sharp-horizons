namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCProvisionalDesignation
{
    public static void Invalid_ArgumentException(ITargetFactory factory)
    {
        var target = GetInvalidMPCProvisionalDesignation();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(ITargetFactory factory)
    {
        var target = GetValidMPCProvisionalDesignation();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCProvisionalDesignation GetInvalidMPCProvisionalDesignation() => default;
    private static MPCProvisionalDesignation GetValidMPCProvisionalDesignation() => new("A801 AA");
}
