namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTarget : ITarget
{
    /// <summary>The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObjectID ID { get; }

    /// <summary>Used to compose a <see cref="ICommandArgument"/> describing <see langword="this"/>.</summary>
    private ICommandComposer<MajorObjectID> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="id"/>.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectIDTarget(MajorObjectID id, ICommandComposer<MajorObjectID> composer)
    {
        ID = id;

        Composer = composer;
    }

    ICommandArgument ITarget.ComposeArgument() => Composer.Compose(ID);
}
