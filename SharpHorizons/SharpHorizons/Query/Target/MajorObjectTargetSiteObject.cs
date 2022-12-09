namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITargetSiteObject"/> as a <see cref="SharpHorizons.MajorObject"/>.</summary>
internal sealed record class MajorObjectTargetSiteObject : ITargetSiteObject
{
    /// <summary>The <see cref="SharpHorizons.MajorObject"/> which represents the <see cref="ITargetSiteObject"/>.</summary>
    public required MajorObject MajorObject { private get; init; }

    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetSiteObjectComposer<MajorObject> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectTargetSiteObject"/>
    public MajorObjectTargetSiteObject() { }

    /// <inheritdoc cref="MajorObjectTargetSiteObject"/>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectTargetSiteObject(MajorObject majorObject, ITargetSiteObjectComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Composer.Compose(MajorObject);
}
