namespace SharpHorizons.Query.Origin;

using SharpHorizons.Composers.Arguments.Origin;
using SharpHorizons.Identification;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDOrigin : IOriginObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="IOriginObject"/> in a query.</summary>
    private MajorObjectID ID { get; }

    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> describing <see langword="this"/>.</summary>
    private IOriginObjectComposer<MajorObjectID> Composer { get; }

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="id"/>.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectIDOrigin(MajorObjectID id, IOriginObjectComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Composer.Compose(ID);
}
