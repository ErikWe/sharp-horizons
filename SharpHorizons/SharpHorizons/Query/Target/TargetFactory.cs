namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="ITarget"/>.</summary>
public sealed class TargetFactory : ITargetFactory
{
    /// <summary><inheritdoc cref="IMajorObjectTargetFactory" path="/summary"/></summary>
    private IMajorObjectTargetFactory MajorObjectFactory { get; }

    /// <summary><inheritdoc cref="IMPCTargetFactory" path="/summary"/></summary>
    private IMPCTargetFactory MPCFactory { get; }

    /// <summary><inheritdoc cref="IMPCCometTargetFactory" path="/summary"/></summary>
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
    public ITarget Create(MajorObjectName majorObjectName) => MajorObjectFactory.Create(majorObjectName);

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return MajorObjectFactory.Create(majorObject, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return MajorObjectFactory.Create(majorObject, coordinate);
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => MajorObjectFactory.Create(majorObjectID, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => MajorObjectFactory.Create(majorObjectID, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => MajorObjectFactory.Create(majorObjectName, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => MajorObjectFactory.Create(majorObjectName, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MPCObject mpcObject)
    {
        ArgumentNullException.ThrowIfNull(mpcObject);

        return MPCFactory.Create(mpcObject);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCProvisionalObject mpcObject) => MPCFactory.Create(mpcObject);

    /// <inheritdoc/>
    public ITarget Create(MPCName mpcName) => MPCFactory.Create(mpcName);

    /// <inheritdoc/>
    public ITarget Create(MPCProvisionalDesignation mpcDesignation) => MPCFactory.Create(mpcDesignation);

    /// <inheritdoc/>
    public ITarget Create(MPCSequentialNumber mpcNumber) => MPCFactory.Create(mpcNumber);

    /// <inheritdoc/>
    public ITarget Create(MPCComet mpcComet)
    {
        ArgumentNullException.ThrowIfNull(mpcComet);

        return MPCCometFactory.Create(mpcComet);
    }

    /// <inheritdoc/>
    public ITarget Create(MPCCometName mpcCometName) => MPCCometFactory.Create(mpcCometName);

    /// <inheritdoc/>
    public ITarget Create(MPCCometDesignation mpcCometDesignation) => MPCCometFactory.Create(mpcCometDesignation);
}
