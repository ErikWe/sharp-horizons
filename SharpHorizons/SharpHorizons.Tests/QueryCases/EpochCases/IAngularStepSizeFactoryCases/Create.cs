namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularStepSizeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

public class Create
{
    [Theory]
    [ClassData(typeof(Datasets.InvalidDeltaAngles))]
    public void Invalid_ArgumentException(Angle deltaAngle)
    {
        AnyError_TException<ArgumentException>(deltaAngle);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaAngles))]
    public void OutOfRange_ArgumentOutOfRangeException(Angle deltaAngle)
    {
        AnyError_TException<ArgumentOutOfRangeException>(deltaAngle);
    }

    private static void AnyError_TException<TException>(Angle deltaAngle) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(deltaAngle));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaAngles))]
    public void Valid_ExactMatch(Angle deltaAngle)
    {
        var factory = GetService();

        var actual = factory.Create(deltaAngle);

        Assert.Equal(deltaAngle, actual.DeltaAngle);
    }

    private static IAngularStepSizeFactory GetService() => DependencyInjection.GetRequiredService<IAngularStepSizeFactory>();
}
