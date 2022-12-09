namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="ITarget"/>.</summary>
public sealed class TargetFactory : ITargetFactory
{
    /// <inheritdoc cref="IMajorObjectTargetFactory"/>
    private IMajorObjectTargetFactory MajorObjectFactory { get; }

    /// <inheritdoc cref="IMPCTargetFactory"/>
    private IMPCTargetFactory MPCFactory { get; }

    /// <inheritdoc cref="IMPCCometTargetFactory"/>
    private IMPCCometTargetFactory MPCCometFactory { get; }

    /// <inheritdoc cref="TargetFactory"/>
    /// <param name="majorObjectFactory"><inheritdoc cref="MajorObjectFactory" path="/summary"/></param>
    /// <param name="mpcFactory"><inheritdoc cref="MPCFactory" path="/summary"/></param>
    /// <param name="mpcCometFactory"><inheritdoc cref="MPCCometFactory" path="/summary"/></param>
    public TargetFactory(IMajorObjectTargetFactory? majorObjectFactory = null, IMPCTargetFactory? mpcFactory = null, IMPCCometTargetFactory? mpcCometFactory = null)
    {
        MajorObjectFactory = majorObjectFactory ?? new MajorObjectTargetFactory();
        MPCFactory = mpcFactory ?? new MPCTargetFactory();
        MPCCometFactory = mpcCometFactory ?? new MPCCometTargetFactory();
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return MajorObjectFactory.Create(majorObject);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID) => MajorObjectFactory.Create(majorObjectID);

    /// <inheritdoc/>
    public ITarget Create(ObjectRadiiInterpretation majorObjectName)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);

        return MajorObjectFactory.Create(majorObjectName);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        SharpMeasuresValidation.Validate(coordinate);

        return MajorObjectFactory.Create(majorObject, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        SharpMeasuresValidation.Validate(coordinate);

        return MajorObjectFactory.Create(majorObject, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return MajorObjectFactory.Create(majorObjectID, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return MajorObjectFactory.Create(majorObjectID, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(ObjectRadiiInterpretation majorObjectName, CylindricalCoordinate coordinate)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);
        SharpMeasuresValidation.Validate(coordinate);

        return MajorObjectFactory.Create(majorObjectName, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(ObjectRadiiInterpretation majorObjectName, GeodeticCoordinate coordinate)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);
        SharpMeasuresValidation.Validate(coordinate);

        return MajorObjectFactory.Create(majorObjectName, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCObject mpcObject)
    {
        ArgumentNullException.ThrowIfNull(mpcObject);

        return MPCFactory.Create(mpcObject);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCProvisionalObject mpcObject)
    {
        MPCProvisionalObject.Validate(mpcObject);

        return MPCFactory.Create(mpcObject);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCName mpcName)
    {
        MPCName.Validate(mpcName);

        return MPCFactory.Create(mpcName);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCProvisionalDesignation mpcDesignation)
    {
        MPCProvisionalDesignation.Validate(mpcDesignation);

        return MPCFactory.Create(mpcDesignation);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCSequentialNumber mpcNumber) => MPCFactory.Create(mpcNumber);

    /// <inheritdoc/>
    public ITarget Create(MPCComet mpcComet)
    {
        ArgumentNullException.ThrowIfNull(mpcComet);

        return MPCCometFactory.Create(mpcComet);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCCometName mpcCometName)
    {
        MPCCometName.Validate(mpcCometName);

        return MPCCometFactory.Create(mpcCometName);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCCometDesignation mpcCometDesignation)
    {
        MPCCometDesignation.Validate(mpcCometDesignation);

        return MPCCometFactory.Create(mpcCometDesignation);
    }
}
