namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System;

using Xunit;

public class CreateBuilder_ITargetIOriginIEpochSelection
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

        var exception = Record.Exception(() => factory.CreateBuilder(target, origin, epochSelection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_NotNull()
    {
        var factory = GetService();

        var target = GetValidTarget();
        var origin = GetValidOrigin();
        var epochSelection = GetValidEpochSelection();

        var actual = factory.CreateBuilder(target, origin, epochSelection);

        Assert.NotNull(actual);
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
