namespace SharpHorizons.Vectors.Fluency;

using SharpHorizons.Identification;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="ITargetStage"/>
internal sealed class TargetStage : ITargetStage
{
    IOriginStage ITargetStage.WithTarget(ITarget target)
    {
        ArgumentNullException.ThrowIfNull(target);

        return new OriginStage(target);
    }

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new OriginStage(TargetBuilder.Represent(majorObject));
    }

    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID) => new OriginStage(TargetBuilder.Represent(majorObjectID));
    IOriginStage ITargetStage.WithTarget(MajorObjectName majorObjectName) => new OriginStage(TargetBuilder.Represent(majorObjectName));

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new OriginStage(TargetBuilder.Represent(majorObject, coordinate));
    }

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new OriginStage(TargetBuilder.Represent(majorObject, coordinate));
    }

    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => new OriginStage(TargetBuilder.Represent(majorObjectID, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => new OriginStage(TargetBuilder.Represent(majorObjectID, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => new OriginStage(TargetBuilder.Represent(majorObjectName, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => new OriginStage(TargetBuilder.Represent(majorObjectName, coordinate));

    IOriginStage ITargetStage.WithTarget(MPCObject mpcObject)
    {
        ArgumentNullException.ThrowIfNull(mpcObject);

        return new OriginStage(TargetBuilder.Represent(mpcObject));
    }

    IOriginStage ITargetStage.WithTarget(MPCProvisionalObject mpcObject) => new OriginStage(TargetBuilder.Represent(mpcObject));
    IOriginStage ITargetStage.WithTarget(MPCName mpcName) => new OriginStage(TargetBuilder.Represent(mpcName));
    IOriginStage ITargetStage.WithTarget(MPCProvisionalDesignation mpcDesignation) => new OriginStage(TargetBuilder.Represent(mpcDesignation));
    IOriginStage ITargetStage.WithTarget(MPCSequentialNumber mpcNumber) => new OriginStage(TargetBuilder.Represent(mpcNumber));
}