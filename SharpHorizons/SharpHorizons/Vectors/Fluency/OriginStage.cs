namespace SharpHorizons.Vectors.Fluency;

using SharpHorizons.Identification;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="IOriginStage"/>
internal sealed class OriginStage : IOriginStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    private ITarget Target { get; }

    /// <summary>Uses <paramref name="target"/> as the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>, and provides means of selecting the <see cref="IOrigin"/>.</summary>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    public OriginStage(ITarget target)
    {
        Target = target;
    }

    IEpochStage IOriginStage.WithOrigin(IOrigin origin)
    {
        ArgumentNullException.ThrowIfNull(origin);

        return new EpochStage(Target, origin);
    }

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new EpochStage(Target, OriginBuilder.Represent(majorObject));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID) => new EpochStage(Target, OriginBuilder.Represent(majorObjectID));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName) => new EpochStage(Target, OriginBuilder.Represent(majorObjectName));

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new EpochStage(Target, OriginBuilder.Represent(majorObject, coordinate));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new EpochStage(Target, OriginBuilder.Represent(majorObject, coordinate));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => new EpochStage(Target, OriginBuilder.Represent(majorObjectID, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => new EpochStage(Target, OriginBuilder.Represent(majorObjectID, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => new EpochStage(Target, OriginBuilder.Represent(majorObjectName, coordinate));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => new EpochStage(Target, OriginBuilder.Represent(majorObjectName, coordinate));

    IEpochStage IOriginStage.WithOrigin(MajorObject majorObject, ObservationSiteID observationSiteID)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new EpochStage(Target, OriginBuilder.Represent(majorObject, observationSiteID));
    }

    IEpochStage IOriginStage.WithOrigin(MajorObjectID majorObjectID, ObservationSiteID observationSiteID) => new EpochStage(Target, OriginBuilder.Represent(majorObjectID, observationSiteID));
    IEpochStage IOriginStage.WithOrigin(MajorObjectName majorObjectName, ObservationSiteID observationSiteID) => new EpochStage(Target, OriginBuilder.Represent(majorObjectName, observationSiteID));
}