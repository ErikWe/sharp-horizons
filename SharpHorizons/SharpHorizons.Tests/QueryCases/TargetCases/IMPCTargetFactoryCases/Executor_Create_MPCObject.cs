namespace SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MPCObject
{
    public static void Null_ArgumentNullException(ITargetFactory factory)
    {
        var target = GetInvalidMPCObject();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_NotNull(ITargetFactory factory)
    {
        var target = GetValidMPCObject();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MPCObject GetInvalidMPCObject() => null!;
    private static MPCObject GetValidMPCObject() => MPCObject.Named(new MPCSequentialNumber(1), new MPCName("Ceres"));
}
