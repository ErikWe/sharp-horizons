namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="ITarget"/>.</summary>
public sealed class TargetFactory : ITargetFactory
{
    /// <summary><inheritdoc cref="IMajorObjectTargetFactory" path="/summary"/></summary>
    private IMajorObjectTargetFactory MajorObjectFactory { get; }
    /// <summary><inheritdoc cref="IMPCTargetFactory" path="/summary"/></summary>
    private IMPCTargetFactory MPCFactory { get; }

    /// <summary><inheritdoc cref="TargetFactory" path="/summary"/></summary>
    /// <param name="majorObjectFactory"><inheritdoc cref="MajorObjectFactory" path="/summary"/></param>
    /// <param name="mpcFactory"><inheritdoc cref="MPCFactory" path="/summary"/></param>
    public TargetFactory(IMajorObjectTargetFactory? majorObjectFactory = null, IMPCTargetFactory? mpcFactory = null)
    {
        MajorObjectFactory = majorObjectFactory ?? new MajorObjectTargetFactory();
        MPCFactory = mpcFactory ?? new MPCTargetFactory();
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
}
