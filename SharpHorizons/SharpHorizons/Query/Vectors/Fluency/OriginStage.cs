namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IOriginStage"/>
internal sealed class OriginStage : IOriginStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    public required ITarget Target { private get; init; }

    /// <inheritdoc cref="IOriginFactory"/>
    public required IOriginFactory OriginFactory { private get; init; }

    /// <inheritdoc cref="IEpochStageFactory"/>
    public required IEpochStageFactory EpochStageFactory { private get; init; }

    /// <inheritdoc cref="OriginStage"/>
    public OriginStage() { }

    /// <inheritdoc cref="OriginStage"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="originFactory"><inheritdoc cref="OriginFactory" path="/summary"/></param>
    /// <param name="epochStageFactory"><inheritdoc cref="EpochStageFactory" path="/summary"/></param>
    [SetsRequiredMembers]
    public OriginStage(ITarget target, IOriginFactory originFactory, IEpochStageFactory epochStageFactory)
    {
        Target = target;

        OriginFactory = originFactory;
        EpochStageFactory = epochStageFactory;
    }

    IEpochStage IOriginStage.WithOrigin(IOrigin origin)
    {
        ArgumentNullException.ThrowIfNull(origin);

        return EpochStageFactory.Create(Target, origin);
    }

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject) => Create(OriginFactory.Create(majorObject));
    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID) => Create(OriginFactory.Create(majorObjectID));
    IEpochStage IOriginStage.WithOrigin(ObjectRadiiInterpretation majorObjectName) => Create(OriginFactory.Create(majorObjectName));

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, CylindricalCoordinate coordinate) => Create(OriginFactory.Create(majorObject, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, GeodeticCoordinate coordinate) => Create(OriginFactory.Create(majorObject, coordinate));

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => Create(OriginFactory.Create(majorObjectID, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => Create(OriginFactory.Create(majorObjectID, coordinate));
    IEpochStage IOriginStage.WithOrigin(ObjectRadiiInterpretation majorObjectName, CylindricalCoordinate coordinate) => Create(OriginFactory.Create(majorObjectName, coordinate));
    IEpochStage IOriginStage.WithOrigin(ObjectRadiiInterpretation majorObjectName, GeodeticCoordinate coordinate) => Create(OriginFactory.Create(majorObjectName, coordinate));

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, ObservationSiteID observationSiteID) => Create(OriginFactory.Create(majorObject, observationSiteID));
    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, ObservationSiteID observationSiteID) => Create(OriginFactory.Create(majorObjectID, observationSiteID));
    IEpochStage IOriginStage.WithOrigin(ObjectRadiiInterpretation majorObjectName, ObservationSiteID observationSiteID) => Create(OriginFactory.Create(majorObjectName, observationSiteID));

    /// <summary>Selects <paramref name="origin"/> as the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="origin">The <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    private IEpochStage Create(IOrigin origin) => EpochStageFactory.Create(Target, origin);
}