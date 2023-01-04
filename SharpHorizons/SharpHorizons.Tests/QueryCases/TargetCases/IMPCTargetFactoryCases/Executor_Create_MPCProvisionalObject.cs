namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCProvisionalObject
{
    public static void Invalid_ArgumentException(ITargetFactory factory)
    {
        var target = GetInvalidMPCProvisionalObject();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(ITargetFactory factory)
    {
        var target = GetValidMPCProvisionalObject();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCProvisionalObject GetInvalidMPCProvisionalObject() => default;
    private static MPCProvisionalObject GetValidMPCProvisionalObject() => new(new MPCProvisionalDesignation("A801 AA"));
}
