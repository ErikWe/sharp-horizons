namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Identity;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITargetStage"/>
internal sealed class TargetStage : ITargetStage
{
    /// <summary><inheritdoc cref="ITargetFactory" path="/summary"/></summary>
    public required ITargetFactory TargetFactory { private get; init; }

    /// <summary><inheritdoc cref="IOriginStageFactory" path="/summary"/></summary>
    public required IOriginStageFactory OriginStageFactory { private get; init; }

    /// <inheritdoc cref="TargetStage"/>
    public TargetStage() { }

    /// <inheritdoc cref="TargetStage"/>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="originStageFactory"><inheritdoc cref="OriginStageFactory" path="/summary"/></param>
    [SetsRequiredMembers]
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