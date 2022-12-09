namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITargetSiteObject"/> as an object identified by a <see cref="ObjectRadiiInterpretation"/>.</summary>
internal sealed record class MajorObjectNameTargetSiteObject : ITargetSiteObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="ITargetSiteObject"/>.</summary>
    public required ObjectRadiiInterpretation Name { private get; init; }

    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetSiteObjectComposer<ObjectRadiiInterpretation> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectNameTargetSiteObject"/>
    public MajorObjectNameTargetSiteObject() { }

    /// <inheritdoc cref="MajorObjectNameTargetSiteObject"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectNameTargetSiteObject(ObjectRadiiInterpretation name, ITargetSiteObjectComposer<ObjectRadiiInterpretation> composer)
    {
        Name = name;

        Composer = composer;
    }

    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Composer.Compose(Name);
}
