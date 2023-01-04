﻿namespace SharpHorizons.Tests.QueryCases.VectorsCases.FluencyCases.IEpochStageCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Fluency;
using SharpHorizons.Query.Vectors.Table;

using System;

using Xunit;

public class WithEpochCollection_DEpochCollectionFactory
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var epochCollectionFactoryDelegate = GetNullDelegate();

        AnyError_TException<ArgumentNullException>(epochCollectionFactoryDelegate);
    }

    [Fact]
    public void ExceptionThrowingDelegate_ArgumentException()
    {
        var epochCollectionFactoryDelegate = GetExceptionThrowingDelegate();

        AnyError_TException<ArgumentException>(epochCollectionFactoryDelegate);
    }

    private static void AnyError_TException<TException>(IEpochStage.DEpochCollectionFactory epochCollectionFactoryDelegate)
    {
        var epochStage = GetEpochStage();

        var exception = Record.Exception(() => epochStage.WithEpochCollection(epochCollectionFactoryDelegate));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var factory = GetFactory();

        var target = GetValidTarget();
        var origin = GetValidOrigin();

        var epochStage = factory.Create(target, origin);

        var epochCollection = GetValidEpochCollection();

        var actual = epochStage.WithEpochCollection(epochCollectionFactoryDelegate);

        Assert.Equal(target, actual.Target);
        Assert.Equal(origin, actual.Origin);
        Assert.Equal(epochCollection, actual.Epochs);

        Assert.Equal(OutputFormat.JSON, actual.OutputFormat);
        Assert.Equal(ObjectDataInclusion.Disable, actual.ObjectDataInclusion);
        Assert.Equal(ReferencePlane.Ecliptic, actual.ReferencePlane);
        Assert.Equal(ReferenceSystem.ICRF, actual.ReferenceSystem);
        Assert.Equal(OutputUnits.KilometresAndSeconds, actual.OutputUnits);
        Assert.Equal(new VectorTableContent(VectorTableQuantities.StateVectors, VectorTableUncertainties.None), actual.TableContent);
        Assert.Equal(VectorCorrection.None, actual.Correction);
        Assert.Equal(TimePrecision.Second, actual.TimePrecision);
        Assert.Equal(ValueSeparation.WhitespaceSeparation, actual.ValueSeparation);
        Assert.Equal(OutputLabels.Disable, actual.OutputLabels);
        Assert.Equal(TimeDeltaInclusion.Disable, actual.TimeDeltaInclusion);

        IEpochCollection epochCollectionFactoryDelegate(IEpochCollectionFactory _) => epochCollection;
    }

    private static IEpochStageFactory GetFactory() => DependencyInjection.GetRequiredService<IEpochStageFactory>();
    private static IEpochStage GetEpochStage() => GetFactory().Create(GetValidTarget(), GetValidOrigin());

    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static IEpochCollection GetValidEpochCollection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }

    private static IEpochStage.DEpochCollectionFactory GetNullDelegate() => null!;
    private static IEpochStage.DEpochCollectionFactory GetExceptionThrowingDelegate() => (factory) => throw new Exception();
}
