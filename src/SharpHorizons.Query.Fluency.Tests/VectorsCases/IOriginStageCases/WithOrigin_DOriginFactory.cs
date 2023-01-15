namespace SharpHorizons.Tests.QueryCases.FluencyCases.VectorsCases.IOriginStageCases;

using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

using Xunit;

public class WithOrigin_DOriginFactory
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var originFactoryDelegate = GetNullDelegate();

        AnyError_TException<ArgumentNullException>(originFactoryDelegate);
    }

    [Fact]
    public void InvalidOperationExceptionThrowingDelegate_ArgumentException()
    {
        var originFactoryDelegate = GetInvalidOperationExceptionThrowingDelegate();

        AnyError_TException<ArgumentException>(originFactoryDelegate);
    }

    [Fact]
    public void NullReturningDelegate_ArgumentException()
    {
        var originFactoryDelegate = GetNullReturningDelegate();

        AnyError_TException<ArgumentException>(originFactoryDelegate);
    }

    private static void AnyError_TException<TException>(IOriginStage.DOriginFactory originFactoryDelegate)
    {
        var originStage = GetOriginStage();

        var exception = Record.Exception(() => originStage.WithOrigin(originFactoryDelegate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var originStage = GetOriginStage();

        var originFactoryDelegate = GetValidDelegate();

        var actual = originStage.WithOrigin(originFactoryDelegate);

        Assert.NotNull(actual);
    }

    private static IOriginStage GetOriginStage() => DependencyInjection.GetRequiredService<IOriginStageFactory>().Create(GetValidTarget());

    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static IOriginStage.DOriginFactory GetNullDelegate() => null!;
    private static IOriginStage.DOriginFactory GetInvalidOperationExceptionThrowingDelegate() => (factory) => throw new InvalidOperationException();
    private static IOriginStage.DOriginFactory GetNullReturningDelegate() => (factory) => null!;
    private static IOriginStage.DOriginFactory GetValidDelegate() => (factory) => factory.Create(new MajorObjectID(399));
}
