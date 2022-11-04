namespace SharpHorizons.Vectors.Fluency;

using SharpHorizons.Identification;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="IOriginStage"/>
internal sealed class OriginStage : IOriginStage
{
    /// <summary>The <see cref="ITarget"/> of the <see cref="IVectorsQuery"/>.</summary>
    private ITarget Target { get; }

    /// <summary><inheritdoc cref="IOriginFactory" path="/summary"/></summary>
    private IOriginFactory OriginFactory { get; }

    /// <summary><inheritdoc cref="IEpochStageFactory" path="/summary"/></summary>
    private IEpochStageFactory EpochStageFactory { get; }

    /// <summary>Uses <paramref name="target"/> as the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>, and provides means of selecting the <see cref="IOrigin"/>.</summary>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="originFactory"><inheritdoc cref="OriginFactory" path="/summary"/></param>
    /// <param name="epochStageFactory"><inheritdoc cref="EpochStageFactory" path="/summary"/></param>
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

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return EpochStageFactory.Create(Target, OriginFactory.Create(majorObject));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectID));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectName));

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return EpochStageFactory.Create(Target, OriginFactory.Create(majorObject, coordinate));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return EpochStageFactory.Create(Target, OriginFactory.Create(majorObject, coordinate));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectID, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectID, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectName, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectName, coordinate));

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, ObservationSiteID observationSiteID)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return EpochStageFactory.Create(Target, OriginFactory.Create(majorObject, observationSiteID));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, ObservationSiteID observationSiteID) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectID, observationSiteID));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName, ObservationSiteID observationSiteID) => EpochStageFactory.Create(Target, OriginFactory.Create(majorObjectName, observationSiteID));
}