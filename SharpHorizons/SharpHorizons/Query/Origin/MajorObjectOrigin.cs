namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as <see cref="Identification.MajorObject"/>.</summary>
internal sealed record class MajorObjectOrigin : IOriginObject
{
    /// <summary>The <see cref="Identification.MajorObject"/> which represents the <see cref="IOriginObject"/> in a query.</summary>
    private MajorObject MajorObject { get; }

    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> describing <see langword="this"/>.</summary>
    private IOriginObjectComposer<MajorObject> Composer { get; }

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectOrigin(MajorObject majorObject, IOriginObjectComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Composer.Compose(MajorObject);
}
