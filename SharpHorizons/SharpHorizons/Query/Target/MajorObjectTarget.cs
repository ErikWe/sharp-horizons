namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="Identity.MajorObject"/>.</summary>
internal sealed record class MajorObjectTarget : ITarget
{
    /// <summary>The center of this <see cref="Identity.MajorObject"/> represents the <see cref="ITarget"/> in a query.</summary>
    public required MajorObject MajorObject { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MajorObject> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectTarget"/>
    public MajorObjectTarget() { }

    /// <inheritdoc cref="MajorObjectTarget"/>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectTarget(MajorObject majorObject, ITargetComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MajorObject>)Composer).Compose(MajorObject);
}
