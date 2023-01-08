namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITargetObject"/> as an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTargetObject : ITargetObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="ITargetObject"/>.</summary>
    public required MajorObjectID ID { private get; init; }

    /// <summary>Used to compose a <see cref="TargetObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetObjectComposer<MajorObjectID> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectIDTargetObject"/>
    public MajorObjectIDTargetObject() { }

    /// <inheritdoc cref="MajorObjectIDTargetObject"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectIDTargetObject(MajorObjectID id, ITargetObjectComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    TargetObjectIdentifier ITargetObject.ComposeIdentifier() => Composer.Compose(ID);
}
