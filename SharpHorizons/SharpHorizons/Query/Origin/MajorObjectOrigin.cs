namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments.Composers.Origin;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as <see cref="SharpHorizons.MajorObject"/>.</summary>
internal sealed record class MajorObjectOrigin : IOriginObject
{
    /// <summary>The <see cref="SharpHorizons.MajorObject"/> which represents the <see cref="IOriginObject"/> in a query.</summary>
    public required MajorObject MajorObject { private get; init; }

    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required IOriginObjectComposer<MajorObject> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectOrigin"/>
    public MajorObjectOrigin() { }

    /// <inheritdoc cref="MajorObjectOrigin"/>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectOrigin(MajorObject majorObject, IOriginObjectComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Composer.Compose(MajorObject);
}
