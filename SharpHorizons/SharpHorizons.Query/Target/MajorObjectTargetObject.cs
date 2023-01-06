namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITargetObject"/> as a <see cref="SharpHorizons.MajorObject"/>.</summary>
internal sealed record class MajorObjectTargetObject : ITargetObject
{
    /// <summary>The <see cref="SharpHorizons.MajorObject"/> which represents the <see cref="ITargetObject"/>.</summary>
    public required MajorObject MajorObject { private get; init; }

    /// <summary>Used to compose a <see cref="TargetObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetObjectComposer<MajorObject> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectTargetObject"/>
    public MajorObjectTargetObject() { }

    /// <inheritdoc cref="MajorObjectTargetObject"/>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectTargetObject(MajorObject majorObject, ITargetObjectComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    TargetObjectIdentifier ITargetObject.ComposeIdentifier() => Composer.Compose(MajorObject);
}
