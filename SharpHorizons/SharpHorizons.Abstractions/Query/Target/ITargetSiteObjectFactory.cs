﻿namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;

/// <summary>Handles construction of <see cref="ITargetSiteObject"/>.</summary>
public interface ITargetSiteObjectFactory
{
    /// <summary>Describes the <see cref="ITargetSiteObject"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">This <see cref="MajorObject"/> represents the <see cref="ITargetSiteObject"/> in a query.</param>
    public abstract ITargetSiteObject Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="ITargetSiteObject"/> in a query as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/> which represents the <see cref="ITargetSiteObject"/> in a query.</param>
    public abstract ITargetSiteObject Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="ITargetSiteObject"/> in a query as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/> which represents the <see cref="ITargetSiteObject"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public abstract ITargetSiteObject Create(MajorObjectName majorObjectName);
}