namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="ITargetArgument"/> and <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
internal sealed class MajorObjectComposer : ITargetComposer<MajorObject>, ITargetSiteObjectComposer<MajorObject>
{
    /// <summary>Used to compose a <see cref="ITargetArgument"/> that describe the <see cref="MajorObjectID"/> associated with a <see cref="MajorObject"/>.</summary>
    private ITargetComposer<MajorObjectID> IDComposer { get; }
    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> that describe the <see cref="MajorObjectID"/> associated with a <see cref="MajorObject"/>.</summary>
    private ITargetSiteObjectComposer<MajorObjectID> IDSiteObjectComposer { get; }

    /// <inheritdoc cref="MajorObjectComposer"/>
    /// <param name="idComposer"><inheritdoc cref="IDComposer" path="/summary"/></param>
    /// <param name="idSiteObjectComposer"><inheritdoc cref="IDSiteObjectComposer" path="/summary"/></param>
    public MajorObjectComposer(ITargetComposer<MajorObjectID> idComposer, ITargetSiteObjectComposer<MajorObjectID> idSiteObjectComposer)
    {
        IDComposer = idComposer;
        IDSiteObjectComposer = idSiteObjectComposer;
    }

    ITargetArgument IArgumentComposer<ITargetArgument, MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return ((IArgumentComposer<ITargetArgument, MajorObjectID>)IDComposer).Compose(obj.ID);
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MajorObject>.Compose(MajorObject obj) => ((IArgumentComposer<ITargetArgument, MajorObject>)this).Compose(obj);

    TargetSiteObjectIdentifier ITargetSiteObjectComposer<MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return IDSiteObjectComposer.Compose(obj.ID);
    }
}
