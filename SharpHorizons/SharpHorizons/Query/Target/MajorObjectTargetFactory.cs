namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments;
using SharpHorizons.Composers.Arguments.Target;
using SharpHorizons.Identity;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="IMajorObjectTargetFactory"/>
internal sealed class MajorObjectTargetFactory : IMajorObjectTargetFactory
{
    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MajorObject"/>.</summary>
    private ICommandComposer<MajorObject> MajorObjectComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MajorObjectID"/>.</summary>
    private ICommandComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MajorObjectName"/>.</summary>
    private ICommandComposer<MajorObjectName> MajorObjectNameComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="ISiteTarget"/>.</summary>
    private ICommandComposer<ISiteTarget> SiteComposer { get; }

    /// <inheritdoc cref="ITargetSiteObjectFactory"/>
    private ITargetSiteObjectFactory SiteObjectFactory { get; }

    /// <inheritdoc cref="ITargetSiteFactory"/>
    private ITargetSiteFactory SiteFactory { get; }

    /// <summary><inheritdoc cref="MajorObjectTargetFactory" path="/summary"/></summary>
    /// <param name="majorObjectComposer"><inheritdoc cref="MajorObjectComposer" path="/summary"/></param>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    /// <param name="majorObjectNameComposer"><inheritdoc cref="MajorObjectNameComposer" path="/summary"/></param>
    /// <param name="siteComposer"><inheritdoc cref="SiteComposer" path="/summary"/></param>
    /// <param name="siteObjectFactory"><inheritdoc cref="SiteObjectFactory" path="/summary"/></param>
    /// <param name="siteFactory"><inheritdoc cref="SiteFactory" path="/summary"/></param>
    public MajorObjectTargetFactory(ICommandComposer<MajorObject>? majorObjectComposer = null, ICommandComposer<MajorObjectID>? majorObjectIDComposer = null, ICommandComposer<MajorObjectName>? majorObjectNameComposer = null, ICommandComposer<ISiteTarget>? siteComposer = null, ITargetSiteObjectFactory? siteObjectFactory = null, ITargetSiteFactory? siteFactory = null)
    {
        MajorObjectIDComposer? defaultMajorObjectIDComposer = null;

        if (majorObjectComposer is null || majorObjectIDComposer is null)
        {
            defaultMajorObjectIDComposer = new MajorObjectIDComposer();
        }

        MajorObjectComposer = majorObjectComposer ?? new MajorObjectComposer(majorObjectIDComposer ?? defaultMajorObjectIDComposer!, defaultMajorObjectIDComposer!);
        MajorObjectIDComposer = majorObjectIDComposer ?? defaultMajorObjectIDComposer!;
        MajorObjectNameComposer = majorObjectNameComposer ?? new MajorObjectNameComposer();

        SiteComposer = siteComposer ?? new SiteTargetComposer();

        SiteObjectFactory = siteObjectFactory ?? new TargetSiteObjectFactory();
        SiteFactory = siteFactory ?? new TargetSiteFactory();
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return CreateTarget(majorObject);
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID) => CreateTarget(majorObjectID);
    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName) => CreateTarget(majorObjectName);

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return CreateTarget(SiteObjectFactory.Create(majorObject), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return CreateTarget(SiteObjectFactory.Create(majorObject), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => CreateTarget(SiteObjectFactory.Create(majorObjectID), SiteFactory.Create(coordinate));
    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => CreateTarget(SiteObjectFactory.Create(majorObjectID), SiteFactory.Create(coordinate));
    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => CreateTarget(SiteObjectFactory.Create(majorObjectName), SiteFactory.Create(coordinate));
    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => CreateTarget(SiteObjectFactory.Create(majorObjectName), SiteFactory.Create(coordinate));

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="ITarget"/> in a query.</param>
    private ITarget CreateTarget(MajorObject majorObject) => new MajorObjectTarget(majorObject, MajorObjectComposer);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</param>
    private ITarget CreateTarget(MajorObjectID majorObjectID) => new MajorObjectIDTarget(majorObjectID, MajorObjectIDComposer);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</param>
    private ITarget CreateTarget(MajorObjectName majorObjectName) => new MajorObjectNameTarget(majorObjectName, MajorObjectNameComposer);

    /// <summary>Describes the <see cref="ITarget"/> in a query as a <paramref name="targetSite"/> assocaited with <paramref name="targetSiteObject"/>.</summary>
    /// <param name="targetSiteObject">The <see cref="ITargetSiteObject"/> associated with <paramref name="targetSite"/>.</param>
    /// <param name="targetSite">The <see cref="ITargetSite"/> associated with <paramref name="targetSiteObject"/>.</param>
    private ITarget CreateTarget(ITargetSiteObject targetSiteObject, ITargetSite targetSite) => new SiteTarget(targetSiteObject, targetSite, SiteComposer);
}
