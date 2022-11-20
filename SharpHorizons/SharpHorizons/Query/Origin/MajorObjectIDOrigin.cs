namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDOrigin : IOriginObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="IOriginObject"/> in a query.</summary>
    public required MajorObjectID ID { private get; init; }

    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required IOriginObjectComposer<MajorObjectID> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectIDOrigin"/>
    public MajorObjectIDOrigin() { }

    /// <inheritdoc cref="MajorObjectIDOrigin"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectIDOrigin(MajorObjectID id, IOriginObjectComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Composer.Compose(ID);
}
