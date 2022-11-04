namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments;
using SharpHorizons.Identification;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTarget : ITarget
{
    /// <summary>The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObjectID ID { get; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    private ITargetComposer<MajorObjectID> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="id"/>.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectIDTarget(MajorObjectID id, ITargetComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => Composer.Compose(ID);
}
