namespace SharpHorizons.Tests.QueryCases.EpochCases.IFixedStepSizeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

public class Create
{
    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaTimes))]
    public void OutOfRange_ArgumentOutOfRangeException(Time deltaTime)
    {
        AnyError_TException<ArgumentOutOfRangeException>(deltaTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidDeltaTimes))]
    public void Invalid_ArgumentException(Time deltaTime)
    {
        AnyError_TException<ArgumentException>(deltaTime);
    }

    private static void AnyError_TException<TException>(Time deltaTime)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(deltaTime));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaTimes))]
    public void Valid_ExactMatch(Time deltaTime)
    {
        var factory = GetService();

        var actual = factory.Create(deltaTime);

        Assert.Equal(deltaTime, actual.DeltaTime);
    }

    private static IFixedStepSizeFactory GetService() => DependencyInjection.GetRequiredService<IFixedStepSizeFactory>();
}
