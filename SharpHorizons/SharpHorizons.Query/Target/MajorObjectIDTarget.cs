namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTarget : ITarget
{
    /// <summary>The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MajorObjectID ID { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MajorObjectID> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectIDTarget"/>
    public MajorObjectIDTarget() { }

    /// <inheritdoc cref="MajorObjectIDTarget"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectIDTarget(MajorObjectID id, ITargetComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MajorObjectID>)Composer).Compose(ID);
}
