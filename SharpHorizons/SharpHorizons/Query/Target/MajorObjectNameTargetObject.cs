namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITargetObject"/> as an object identified by a <see cref="MajorObjectName"/>.</summary>
internal sealed record class MajorObjectNameTargetObject : ITargetObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="ITargetObject"/>.</summary>
    public required MajorObjectName Name { private get; init; }

    /// <summary>Used to compose a <see cref="TargetObjectIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetObjectComposer<MajorObjectName> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectNameTargetObject"/>
    public MajorObjectNameTargetObject() { }

    /// <inheritdoc cref="MajorObjectNameTargetObject"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectNameTargetObject(MajorObjectName name, ITargetObjectComposer<MajorObjectName> composer)
    {
        Name = name;

        Composer = composer;
    }

    TargetObjectIdentifier ITargetObject.ComposeIdentifier() => Composer.Compose(Name);
}
