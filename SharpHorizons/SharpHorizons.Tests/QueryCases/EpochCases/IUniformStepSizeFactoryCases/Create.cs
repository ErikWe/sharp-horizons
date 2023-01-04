namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformStepSizeFactoryCases;

using SharpHorizons.Query.Epoch;

using System;

using Xunit;

public class Create
{
    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeStepCounts))]
    public void OutOfRange_ArgumentOutOfRangeException(int stepCount)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(stepCount));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidStepCounts))]
    public void Valid_ExactMatch(int stepCount)
    {
        var factory = GetService();

        var actual = factory.Create(stepCount);

        Assert.Equal(stepCount, actual.StepCount);
    }

    private static IUniformStepSizeFactory GetService() => DependencyInjection.GetRequiredService<IUniformStepSizeFactory>();
}
