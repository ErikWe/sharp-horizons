namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System;

/// <inheritdoc cref="ITargetSiteObjectFactory"/>
internal sealed class TargetSiteObjectFactory : ITargetSiteObjectFactory
{
    /// <summary>Composes <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
    private ITargetSiteObjectComposer<MajorObject> MajorObjectComposer { get; }

    /// <summary>Composes <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
    private ITargetSiteObjectComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary>Composes <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
    private ITargetSiteObjectComposer<MajorObjectName> MajorObjectNameComposer { get; }

    /// <inheritdoc cref="TargetSiteObjectFactory"/>
    /// <param name="majorObjectComposer"><inheritdoc cref="MajorObjectComposer" path="/summary"/></param>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    /// <param name="majorObjectNameComposer"><inheritdoc cref="MajorObjectNameComposer" path="/summary"/></param>
    public TargetSiteObjectFactory(ITargetSiteObjectComposer<MajorObject>? majorObjectComposer = null, ITargetSiteObjectComposer<MajorObjectID>? majorObjectIDComposer = null, ITargetSiteObjectComposer<MajorObjectName>? majorObjectNameComposer = null)
    {
        MajorObjectIDComposer? defaultMajorObjectIDComposer = null;

        if (majorObjectComposer is null || majorObjectIDComposer is null)
        {
            defaultMajorObjectIDComposer = new MajorObjectIDComposer();
        }

        MajorObjectComposer = majorObjectComposer ?? new MajorObjectComposer(defaultMajorObjectIDComposer!, majorObjectIDComposer ?? defaultMajorObjectIDComposer!);
        MajorObjectIDComposer = majorObjectIDComposer ?? defaultMajorObjectIDComposer!;
        MajorObjectNameComposer = majorObjectNameComposer ?? new MajorObjectNameComposer();
    }

    ITargetSiteObject ITargetSiteObjectFactory.Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new MajorObjectTargetSiteObject(majorObject, MajorObjectComposer);
    }

    ITargetSiteObject ITargetSiteObjectFactory.Create(MajorObjectID majorObjectID) => new MajorObjectIDTargetSiteObject(majorObjectID, MajorObjectIDComposer);

    ITargetSiteObject ITargetSiteObjectFactory.Create(MajorObjectName majorObjectName)
    {
        MajorObjectName.Validate(majorObjectName);

        return new MajorObjectNameTargetSiteObject(majorObjectName, MajorObjectNameComposer);
    }
}
