namespace SharpHorizons.Vectors.Fluency;

using SharpHorizons.Identification;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="ITargetStage"/>
internal sealed class TargetStage : ITargetStage
{
    /// <summary><inheritdoc cref="ITargetFactory" path="/summary"/></summary>
    private ITargetFactory TargetFactory { get; }

    /// <summary><inheritdoc cref="IOriginStageFactory" path="/summary"/></summary>
    private IOriginStageFactory OriginStageFactory { get; }

    /// <summary><inheritdoc cref="TargetStage" path="/summary"/></summary>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="originStageFactory"><inheritdoc cref="OriginStageFactory" path="/summary"/></param>
    public TargetStage(ITargetFactory targetFactory, IOriginStageFactory originStageFactory)
    {
        TargetFactory = targetFactory;
        OriginStageFactory = originStageFactory;
    }

    IOriginStage ITargetStage.WithTarget(ITarget target)
    {
        ArgumentNullException.ThrowIfNull(target);

        return OriginStageFactory.Create(target);
    }

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return OriginStageFactory.Create(TargetFactory.Create(majorObject));
    }

    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID) => OriginStageFactory.Create(TargetFactory.Create(majorObjectID));
    IOriginStage ITargetStage.WithTarget(MajorObjectName majorObjectName) => OriginStageFactory.Create(TargetFactory.Create(majorObjectName));

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return OriginStageFactory.Create(TargetFactory.Create(majorObject, coordinate));
    }

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return OriginStageFactory.Create(TargetFactory.Create(majorObject, coordinate));
    }

    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => OriginStageFactory.Create(TargetFactory.Create(majorObjectID, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => OriginStageFactory.Create(TargetFactory.Create(majorObjectID, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => OriginStageFactory.Create(TargetFactory.Create(majorObjectName, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => OriginStageFactory.Create(TargetFactory.Create(majorObjectName, coordinate));

    IOriginStage ITargetStage.WithTarget(MPCObject mpcObject)
    {
        ArgumentNullException.ThrowIfNull(mpcObject);

        return OriginStageFactory.Create(TargetFactory.Create(mpcObject));
    }

    IOriginStage ITargetStage.WithTarget(MPCProvisionalObject mpcObject) => OriginStageFactory.Create(TargetFactory.Create(mpcObject));
    IOriginStage ITargetStage.WithTarget(MPCName mpcName) => OriginStageFactory.Create(TargetFactory.Create(mpcName));
    IOriginStage ITargetStage.WithTarget(MPCProvisionalDesignation mpcDesignation) => OriginStageFactory.Create(TargetFactory.Create(mpcDesignation));
    IOriginStage ITargetStage.WithTarget(MPCSequentialNumber mpcNumber) => OriginStageFactory.Create(TargetFactory.Create(mpcNumber));
}