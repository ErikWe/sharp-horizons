namespace SharpHorizons.Query.Arguments.Composers.Target;

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

        var argument = ((IArgumentComposer<ITargetArgument, MajorObjectID>)IDComposer).Compose(obj.ID);

        try
        {
            QueryArgument.Validate(argument);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(ITargetComposer<MajorObject>)} for {nameof(MajorObject)} provided an invalid {nameof(ITargetArgument)}.", e);
        }

        return argument;
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MajorObject>.Compose(MajorObject obj) => ((IArgumentComposer<ITargetArgument, MajorObject>)this).Compose(obj);

    TargetSiteObjectIdentifier ITargetSiteObjectComposer<MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var identifier = IDSiteObjectComposer.Compose(obj.ID);

        try
        {
            TargetSiteObjectIdentifier.Validate(identifier);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(ITargetSiteObjectComposer<MajorObjectID>)} for {nameof(MajorObjectID)} provided an invalid {nameof(TargetSiteObjectIdentifier)}.", e);
        }

        return identifier;
    }
}
