namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryFactoryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using System;

using Xunit;

public class Create
{
    [Fact]
    public void NullTarget_ArgumentNullException()
    {
        var target = GetNullTarget();
        var origin = GetValidOrigin();
        var epochSelection = GetValidEpochSelection();

        AnyNull_ArgumentNullException(target, origin, epochSelection);
    }

    [Fact]
    public void NullOrigin_ArgumentNullException()
    {
        var target = GetValidTarget();
        var origin = GetNullOrigin();
        var epochSelection = GetValidEpochSelection();

        AnyNull_ArgumentNullException(target, origin, epochSelection);
    }

    [Fact]
    public void NullEpochSelection_ArgumentNullException()
    {
        var target = GetValidTarget();
        var origin = GetValidOrigin();
        var epochSelection = GetNullEpochSelection();

        AnyNull_ArgumentNullException(target, origin, epochSelection);
    }

    [Fact]
    public void NullTargetOriginAndEpochSelection_ArgumentNullException()
    {
        var target = GetNullTarget();
        var origin = GetNullOrigin();
        var epochSelection = GetNullEpochSelection();

        AnyNull_ArgumentNullException(target, origin, epochSelection);
    }

    private static void AnyNull_ArgumentNullException(ITarget target, IOrigin origin, IEpochSelection epochSelection)
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(target, origin, epochSelection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var factory = GetService();

        var target = GetValidTarget();
        var origin = GetValidOrigin();
        var epochSelection = GetValidEpochSelection();

        var actual = factory.Create(target, origin, epochSelection);

        Assert.Equal(target, actual.Target);
        Assert.Equal(origin, actual.Origin);
        Assert.Equal(epochSelection, actual.EpochSelection);

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
    }

    private static IVectorsQueryFactory GetService() => DependencyInjection.GetRequiredService<IVectorsQueryFactory>();

    private static ITarget GetNullTarget() => null!;
    private static ITarget GetValidTarget()
    {
        var targetFactory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return targetFactory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetNullOrigin() => null!;
    private static IOrigin GetValidOrigin()
    {
        var originFactory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return originFactory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetNullEpochSelection() => null!;
    private static IEpochSelection GetValidEpochSelection()
    {
        var epochSelectionFactory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return epochSelectionFactory.Create(JulianDay.Epoch);
    }
}
