namespace SharpHorizons.Tests.QueryCases.TargetCases.IMajorObjectTargetFactoryCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

internal static class Executor_Create_MajorObject
{
    public static void Null_ArgumentNullException(IMajorObjectTargetFactory factory)
    {
        var target = GetNullMajorObject();

        var exception = Record.Exception(() => factory.Create(target));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_NotNull(IMajorObjectTargetFactory factory)
    {
        var target = GetValidMajorObject();

        var actual = factory.Create(target);

        Assert.NotNull(actual);
    }

    private static MajorObject GetNullMajorObject() => null!;
    private static MajorObject GetValidMajorObject() => new(new MajorObjectID(301));
}
