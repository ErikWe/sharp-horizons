namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITargetSiteObject"/> as an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTargetSiteObject : ITargetSiteObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="ITargetSiteObject"/>.</summary>
    public required MajorObjectID ID { private get; init; }

    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetSiteObjectComposer<MajorObjectID> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectIDTargetSiteObject"/>
    public MajorObjectIDTargetSiteObject() { }

    /// <inheritdoc cref="MajorObjectIDTargetSiteObject"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectIDTargetSiteObject(MajorObjectID id, ITargetSiteObjectComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Composer.Compose(ID);
}
