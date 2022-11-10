namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="Identity.MajorObject"/>.</summary>
internal sealed record class MajorObjectTarget : ITarget
{
    /// <summary>The center of this <see cref="Identity.MajorObject"/> represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObject MajorObject { get; }

    /// <summary>Used to compose a <see cref="ICommandArgument"/> describing <see langword="this"/>.</summary>
    private ICommandComposer<MajorObject> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectTarget(MajorObject majorObject, ICommandComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    ICommandArgument ITarget.ComposeArgument() => Composer.Compose(MajorObject);
}
