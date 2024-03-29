﻿namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Target;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="IMajorObjectTargetFactory"/>
internal sealed class MajorObjectTargetFactory : IMajorObjectTargetFactory
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MajorObject"/>.</summary>
    private ITargetComposer<MajorObject> MajorObjectComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MajorObjectID"/>.</summary>
    private ITargetComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MajorObjectName"/>.</summary>
    private ITargetComposer<MajorObjectName> MajorObjectNameComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="ISiteTarget"/>.</summary>
    private ITargetComposer<ISiteTarget> SiteComposer { get; }

    /// <inheritdoc cref="ITargetObjectFactory"/>
    private ITargetObjectFactory SiteObjectFactory { get; }

    /// <inheritdoc cref="ITargetSiteFactory"/>
    private ITargetSiteFactory SiteFactory { get; }

    /// <inheritdoc cref="MajorObjectTargetFactory"/>
    /// <param name="majorObjectComposer"><inheritdoc cref="MajorObjectComposer" path="/summary"/></param>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    /// <param name="majorObjectNameComposer"><inheritdoc cref="MajorObjectNameComposer" path="/summary"/></param>
    /// <param name="siteComposer"><inheritdoc cref="SiteComposer" path="/summary"/></param>
    /// <param name="siteObjectFactory"><inheritdoc cref="SiteObjectFactory" path="/summary"/></param>
    /// <param name="siteFactory"><inheritdoc cref="SiteFactory" path="/summary"/></param>
    public MajorObjectTargetFactory(ITargetComposer<MajorObject>? majorObjectComposer = null, ITargetComposer<MajorObjectID>? majorObjectIDComposer = null, ITargetComposer<MajorObjectName>? majorObjectNameComposer = null, ITargetComposer<ISiteTarget>? siteComposer = null, ITargetObjectFactory? siteObjectFactory = null, ITargetSiteFactory? siteFactory = null)
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

        SiteObjectFactory = siteObjectFactory ?? new TargetObjectFactory();
        SiteFactory = siteFactory ?? new TargetSiteFactory();
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return CreateTarget(majorObject);
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID) => CreateTarget(majorObjectID);
    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName)
    {
        MajorObjectName.Validate(majorObjectName);

        return CreateTarget(majorObjectName);
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(SiteObjectFactory.Create(majorObject), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(SiteObjectFactory.Create(majorObject), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObject majorObject, ITargetSite site)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        ArgumentNullException.ThrowIfNull(site);

        return CreateTarget(SiteObjectFactory.Create(majorObject), site);
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(SiteObjectFactory.Create(majorObjectID), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(SiteObjectFactory.Create(majorObjectID), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectID majorObjectID, ITargetSite site)
    {
        ArgumentNullException.ThrowIfNull(site);

        return CreateTarget(SiteObjectFactory.Create(majorObjectID), site);
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName, CylindricalCoordinate coordinate)
    {
        MajorObjectName.Validate(majorObjectName);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(SiteObjectFactory.Create(majorObjectName), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName, GeodeticCoordinate coordinate)
    {
        MajorObjectName.Validate(majorObjectName);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateTarget(SiteObjectFactory.Create(majorObjectName), SiteFactory.Create(coordinate));
    }

    ITarget IMajorObjectTargetFactory.Create(MajorObjectName majorObjectName, ITargetSite site)
    {
        ArgumentNullException.ThrowIfNull(site);
        MajorObjectName.Validate(majorObjectName);

        return CreateTarget(SiteObjectFactory.Create(majorObjectName), site);
    }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="ITarget"/> in a query.</param>
    private ITarget CreateTarget(MajorObject majorObject) => new MajorObjectTarget(majorObject, MajorObjectComposer);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</param>
    private ITarget CreateTarget(MajorObjectID majorObjectID) => new MajorObjectIDTarget(majorObjectID, MajorObjectIDComposer);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</param>
    private ITarget CreateTarget(MajorObjectName majorObjectName) => new MajorObjectNameTarget(majorObjectName, MajorObjectNameComposer);

    /// <summary>Describes the <see cref="ITarget"/> in a query as some <paramref name="targetSite"/> associated with some <paramref name="targetObject"/>.</summary>
    /// <param name="targetObject">Some <see cref="ITargetObject"/> associated with some <paramref name="targetSite"/>.</param>
    /// <param name="targetSite">Some <see cref="ITargetSite"/> associated with some <paramref name="targetObject"/>.</param>
    private ITarget CreateTarget(ITargetObject targetObject, ITargetSite targetSite) => new SiteTarget(targetObject, targetSite, SiteComposer);
}
