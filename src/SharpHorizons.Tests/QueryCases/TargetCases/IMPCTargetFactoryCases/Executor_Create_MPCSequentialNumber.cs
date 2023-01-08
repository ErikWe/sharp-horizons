namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCSequentialNumber
{
    public static void Invalid_ArgumentException(ITargetFactory factory)
    {
        var target = GetInvalidMPCSequentialNumber();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentException>(exception);
    }

    public static void Valid_NotNull(ITargetFactory factory)
    {
        var target = GetValidMPCSequentialNumber();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCSequentialNumber GetInvalidMPCSequentialNumber() => default;
    private static MPCSequentialNumber GetValidMPCSequentialNumber() => new(1);
}
