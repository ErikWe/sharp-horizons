namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITargetStage"/>
internal sealed class TargetStage : ITargetStage
{
    /// <inheritdoc cref="ITargetFactory"/>
    public required ITargetFactory TargetFactory { private get; init; }

    /// <inheritdoc cref="IOriginStageFactory"/>
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

        return Create(target);
    }

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject) => Create(TargetFactory.Create(majorObject));

    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID) => Create(TargetFactory.Create(majorObjectID));
    IOriginStage ITargetStage.WithTarget(ObjectRadiiInterpretation majorObjectName) => Create(TargetFactory.Create(majorObjectName));

    IOriginStage ITargetStage.WithTarget(MajorObject majorObject, CylindricalCoordinate coordinate) => Create(TargetFactory.Create(majorObject, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObject majorObject, GeodeticCoordinate coordinate) => Create(TargetFactory.Create(majorObject, coordinate));

    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => Create(TargetFactory.Create(majorObjectID, coordinate));
    IOriginStage ITargetStage.WithTarget(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => Create(TargetFactory.Create(majorObjectID, coordinate));
    IOriginStage ITargetStage.WithTarget(ObjectRadiiInterpretation majorObjectName, CylindricalCoordinate coordinate) => Create(TargetFactory.Create(majorObjectName, coordinate));
    IOriginStage ITargetStage.WithTarget(ObjectRadiiInterpretation majorObjectName, GeodeticCoordinate coordinate) => Create(TargetFactory.Create(majorObjectName, coordinate));

    IOriginStage ITargetStage.WithTarget(MPCObject mpcObject) => Create(TargetFactory.Create(mpcObject));
    IOriginStage ITargetStage.WithTarget(MPCProvisionalObject mpcObject) => Create(TargetFactory.Create(mpcObject));
    IOriginStage ITargetStage.WithTarget(MPCName mpcName) => Create(TargetFactory.Create(mpcName));
    IOriginStage ITargetStage.WithTarget(MPCProvisionalDesignation mpcDesignation) => Create(TargetFactory.Create(mpcDesignation));
    IOriginStage ITargetStage.WithTarget(MPCSequentialNumber mpcNumber) => Create(TargetFactory.Create(mpcNumber));

    IOriginStage ITargetStage.WithTarget(MPCComet mpcComet) => Create(TargetFactory.Create(mpcComet));
    IOriginStage ITargetStage.WithTarget(MPCCometName mpcCometName) => Create(TargetFactory.Create(mpcCometName));
    IOriginStage ITargetStage.WithTarget(MPCCometDesignation mpcCometDesignation) => Create(TargetFactory.Create(mpcCometDesignation));

    /// <summary>Selects <paramref name="target"/> as the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="target">The <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    private IOriginStage Create(ITarget target) => OriginStageFactory.Create(target);
}
