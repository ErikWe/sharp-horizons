namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;
using SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="ICommandArgument"/> and <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
internal sealed class MajorObjectComposer : ICommandComposer<MajorObject>, ITargetSiteObjectComposer<MajorObject>
{
    /// <summary>Used to compose a <see cref="ICommandArgument"/> that describe the <see cref="MajorObjectID"/> associated with a <see cref="MajorObject"/>.</summary>
    private ICommandComposer<MajorObjectID> IDComposer { get; }
    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> that describe the <see cref="MajorObjectID"/> associated with a <see cref="MajorObject"/>.</summary>
    private ITargetSiteObjectComposer<MajorObjectID> IDSiteObjectComposer { get; }

    /// <summary><inheritdoc cref="MajorObjectComposer" path="/summary"/></summary>
    /// <param name="idComposer"><inheritdoc cref="IDComposer" path="/summary"/></param>
    /// <param name="idSiteObjectComposer"><inheritdoc cref="IDSiteObjectComposer" path="/summary"/></param>
    public MajorObjectComposer(ICommandComposer<MajorObjectID> idComposer, ITargetSiteObjectComposer<MajorObjectID> idSiteObjectComposer)
    {
        IDComposer = idComposer;
        IDSiteObjectComposer = idSiteObjectComposer;
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return IDComposer.Compose(obj.ID);
    }

    TargetSiteObjectIdentifier ITargetSiteObjectComposer<MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return IDSiteObjectComposer.Compose(obj.ID);
    }
}
