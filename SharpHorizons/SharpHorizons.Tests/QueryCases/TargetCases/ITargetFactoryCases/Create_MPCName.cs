﻿namespace SharpHorizons.Tests.QueryCases.TargetCases.ITargetFactoryCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Tests.QueryCases.TargetCases.IMPCTargetFactoryCases;

using Xunit;

public class Create_MPCName
{
    [Fact]
    public void Invalid_ArgumentException() => Executor_Create_MPCName.Invalid_ArgumentException(GetService());

    [Fact]
    public void Valid_NotNull() => Executor_Create_MPCName.Valid_NotNull(GetService());

    private static ITargetFactory GetService() => DependencyInjection.GetRequiredService<ITargetFactory>();
}
