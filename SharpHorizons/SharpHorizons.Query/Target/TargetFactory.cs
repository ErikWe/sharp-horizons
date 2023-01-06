namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Target;

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

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="IBodyCentricTarget"/>.</summary>
    private ITargetComposer<IBodyCentricTarget> BodyCentricComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="ISiteTarget"/>.</summary>
    private ITargetComposer<ISiteTarget> SiteComposer { get; }

    /// <inheritdoc cref="ITargetSiteFactory"/>
    private ITargetSiteFactory SiteFactory { get; }

    /// <inheritdoc cref="TargetFactory"/>
    /// <param name="majorObjectFactory"><inheritdoc cref="MajorObjectFactory" path="/summary"/></param>
    /// <param name="mpcFactory"><inheritdoc cref="MPCFactory" path="/summary"/></param>
    /// <param name="mpcCometFactory"><inheritdoc cref="MPCCometFactory" path="/summary"/></param>
    /// <param name="bodyCentricComposer"><inheritdoc cref="BodyCentricComposer" path="/summary"/></param>
    /// <param name="siteComposer"><inheritdoc cref="SiteComposer" path="/summary"/></param>
    /// <param name="siteFactory"><inheritdoc cref="SiteFactory" path="/summary"/></param>
    public TargetFactory(IMajorObjectTargetFactory? majorObjectFactory = null, IMPCTargetFactory? mpcFactory = null, IMPCCometTargetFactory? mpcCometFactory = null, ITargetComposer<IBodyCentricTarget>? bodyCentricComposer = null, ITargetComposer<ISiteTarget>? siteComposer = null, ITargetSiteFactory? siteFactory = null)
    {
        MajorObjectFactory = majorObjectFactory ?? new MajorObjectTargetFactory();
        MPCFactory = mpcFactory ?? new MPCTargetFactory();
        MPCCometFactory = mpcCometFactory ?? new MPCCometTargetFactory();

        BodyCentricComposer = bodyCentricComposer ?? new BodyCentricComposer();
        SiteComposer = siteComposer ?? new SiteTargetComposer();

        SiteFactory = siteFactory ?? new TargetSiteFactory();
    }

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject) => MajorObjectFactory.Create(majorObject);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID) => MajorObjectFactory.Create(majorObjectID);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectName majorObjectName) => MajorObjectFactory.Create(majorObjectName);

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, CylindricalCoordinate coordinate) => MajorObjectFactory.Create(majorObject, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, GeodeticCoordinate coordinate) => MajorObjectFactory.Create(majorObject, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObject majorObject, ITargetSite site) => MajorObjectFactory.Create(majorObject, site);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => MajorObjectFactory.Create(majorObjectID, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => MajorObjectFactory.Create(majorObjectID, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectID majorObjectID, ITargetSite site) => MajorObjectFactory.Create(majorObjectID, site);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => MajorObjectFactory.Create(majorObjectName, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => MajorObjectFactory.Create(majorObjectName, coordinate);

    /// <inheritdoc/>
    public ITarget Create(MajorObjectName majorObjectName, ITargetSite site) => MajorObjectFactory.Create(majorObjectName, site);

    /// <inheritdoc/>
    public ITarget Create(MPCObject mpcObject) => MPCFactory.Create(mpcObject);

    /// <inheritdoc/>
    public ITarget Create(MPCProvisionalObject mpcObject) => MPCFactory.Create(mpcObject);

    /// <inheritdoc/>
    public ITarget Create(MPCName mpcName) => MPCFactory.Create(mpcName);

    /// <inheritdoc/>
    public ITarget Create(MPCProvisionalDesignation mpcDesignation) => MPCFactory.Create(mpcDesignation);

    /// <inheritdoc/>
    public ITarget Create(MPCSequentialNumber mpcNumber) => MPCFactory.Create(mpcNumber);

    /// <inheritdoc/>
    public ITarget Create(MPCComet mpcComet) => MPCCometFactory.Create(mpcComet);

    /// <inheritdoc/>
    public ITarget Create(MPCCometName mpcCometName) => MPCCometFactory.Create(mpcCometName);

    /// <inheritdoc/>
    public ITarget Create(MPCCometDesignation mpcCometDesignation) => MPCCometFactory.Create(mpcCometDesignation);

    /// <inheritdoc/>
    public ITarget Create(ITargetObject targetObject)
    {
        ArgumentNullException.ThrowIfNull(targetObject);

        return new BodyCentricTarget(targetObject, BodyCentricComposer);
    }

    /// <inheritdoc/>
    public ITarget Create(ITargetObject targetObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(targetObject);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(targetObject, SiteFactory.Create(coordinate));
    }

    /// <inheritdoc/>
    public ITarget Create(ITargetObject targetObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(targetObject);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(targetObject, SiteFactory.Create(coordinate));
    }

    /// <inheritdoc/>
    public ITarget Create(ITargetObject targetObject, ITargetSite site)
    {
        ArgumentNullException.ThrowIfNull(targetObject);
        ArgumentNullException.ThrowIfNull(site);

        return CreateTarget(targetObject, site);
    }

    /// <summary>Describes the <see cref="ITarget"/> in a query as some <paramref name="targetSite"/> associated with some <paramref name="targetObject"/>.</summary>
    /// <param name="targetObject">The <see cref="ITargetObject"/> associated with some <paramref name="targetSite"/>.</param>
    /// <param name="targetSite">The <see cref="ITargetSite"/> associated with some <paramref name="targetObject"/>.</param>
    private ITarget CreateTarget(ITargetObject targetObject, ITargetSite targetSite) => new SiteTarget(targetObject, targetSite, SiteComposer);
}
