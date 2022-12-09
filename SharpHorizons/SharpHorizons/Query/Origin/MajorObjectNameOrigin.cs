namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments.Composers.Origin;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by a <see cref="ObjectRadiiInterpretation"/>.</summary>
internal sealed record class MajorObjectNameOrigin : IOriginObject
{
    /// <summary>The <see cref="ObjectRadiiInterpretation"/> of an object which represents the <see cref="IOriginObject"/> in a query.</summary>
    public required ObjectRadiiInterpretation Name { private get; init; }

    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required IOriginObjectComposer<ObjectRadiiInterpretation> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectNameOrigin"/>
    public MajorObjectNameOrigin() { }

    /// <inheritdoc cref="MajorObjectNameOrigin"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectNameOrigin(ObjectRadiiInterpretation name, IOriginObjectComposer<ObjectRadiiInterpretation> composer)
    {
        Name = name;

        Composer = composer;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Composer.Compose(Name);
}
