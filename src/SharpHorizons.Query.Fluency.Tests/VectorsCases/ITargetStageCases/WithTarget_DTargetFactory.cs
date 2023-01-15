namespace SharpHorizons.Tests.QueryCases.FluencyCases.VectorsCases.ITargetStageCases;

using SharpHorizons.Query.Vectors.Fluency;

using System;

using Xunit;

public class WithTarget_DTargetFactory
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var targetFactoryDelegate = GetNullDelegate();

        AnyError_TException<ArgumentNullException>(targetFactoryDelegate);
    }

    [Fact]
    public void InvalidOperationExceptionThrowingDelegate_ArgumentException()
    {
        var targetFactoryDelegate = GetInvalidOperationExceptionThrowingDelegate();

        AnyError_TException<ArgumentException>(targetFactoryDelegate);
    }

    [Fact]
    public void NullReturningDelegate_ArgumentException()
    {
        var targetFactoryDelegate = GetNullReturningDelegate();

        AnyError_TException<ArgumentException>(targetFactoryDelegate);
    }

    private static void AnyError_TException<TException>(ITargetStage.DTargetFactory targetFactoryDelegate)
    {
        var targetStage = GetTargetStage();

        var exception = Record.Exception(() => targetStage.WithTarget(targetFactoryDelegate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var targetStage = GetTargetStage();

        var targetFactoryDelegate = GetValidDelegate();

        var actual = targetStage.WithTarget(targetFactoryDelegate);

        Assert.NotNull(actual);
    }

    private static ITargetStage GetTargetStage() => DependencyInjection.GetRequiredService<ITargetStageFactory>().Create();

    private static ITargetStage.DTargetFactory GetNullDelegate() => null!;
    private static ITargetStage.DTargetFactory GetInvalidOperationExceptionThrowingDelegate() => (factory) => throw new InvalidOperationException();
    private static ITargetStage.DTargetFactory GetNullReturningDelegate() => (factory) => null!;
    private static ITargetStage.DTargetFactory GetValidDelegate() => (factory) => factory.Create(new MajorObjectID(301));
}
