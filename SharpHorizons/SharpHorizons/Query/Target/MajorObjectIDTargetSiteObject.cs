namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;

/// <summary>Describes the <see cref="ITargetSiteObject"/> as an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTargetSiteObject : ITargetSiteObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="ITargetSiteObject"/>.</summary>
    private MajorObjectID ID { get; }

    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> describing <see langword="this"/>.</summary>
    private ITargetSiteObjectComposer<MajorObjectID> Composer { get; }

    /// <summary>Describes the <see cref="ITargetSiteObject"/> as an object identified by <paramref name="id"/>.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectIDTargetSiteObject(MajorObjectID id, ITargetSiteObjectComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Composer.Compose(ID);
}
