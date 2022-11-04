﻿namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;

/// <summary>Handles construction of <see cref="ITargetSiteObject"/>.</summary>
public interface ITargetSiteObjectFactory
{
    /// <summary>Describes the <see cref="ITargetSiteObject"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="ITargetSiteObject"/> in a query.</param>
    public abstract ITargetSiteObject Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="ITargetSiteObject"/> in a query as the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITargetSiteObject"/> in a query.</param>
    public abstract ITargetSiteObject Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="ITargetSiteObject"/> in a query as the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, the center of which represents the <see cref="ITargetSiteObject"/> in a query.</param>
    public abstract ITargetSiteObject Create(MajorObjectName majorObjectName);
}