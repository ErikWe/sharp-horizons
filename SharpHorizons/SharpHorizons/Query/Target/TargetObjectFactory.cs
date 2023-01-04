namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System;

/// <inheritdoc cref="ITargetObjectFactory"/>
internal sealed class TargetObjectFactory : ITargetObjectFactory
{
    /// <summary>Composes <see cref="TargetObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
    private ITargetObjectComposer<MajorObject> MajorObjectComposer { get; }

    /// <summary>Composes <see cref="TargetObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
    private ITargetObjectComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary>Composes <see cref="TargetObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
    private ITargetObjectComposer<MajorObjectName> MajorObjectNameComposer { get; }

    /// <inheritdoc cref="TargetObjectFactory"/>
    /// <param name="majorObjectComposer"><inheritdoc cref="MajorObjectComposer" path="/summary"/></param>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    /// <param name="majorObjectNameComposer"><inheritdoc cref="MajorObjectNameComposer" path="/summary"/></param>
    public TargetObjectFactory(ITargetObjectComposer<MajorObject>? majorObjectComposer = null, ITargetObjectComposer<MajorObjectID>? majorObjectIDComposer = null, ITargetObjectComposer<MajorObjectName>? majorObjectNameComposer = null)
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

    ITargetObject ITargetObjectFactory.Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new MajorObjectTargetObject(majorObject, MajorObjectComposer);
    }

    ITargetObject ITargetObjectFactory.Create(MajorObjectID majorObjectID) => new MajorObjectIDTargetObject(majorObjectID, MajorObjectIDComposer);

    ITargetObject ITargetObjectFactory.Create(MajorObjectName majorObjectName)
    {
        MajorObjectName.Validate(majorObjectName);

        return new MajorObjectNameTargetObject(majorObjectName, MajorObjectNameComposer);
    }
}
