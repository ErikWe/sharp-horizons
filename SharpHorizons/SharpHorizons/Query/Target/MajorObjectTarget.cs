namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="Identification.MajorObject"/>.</summary>
internal sealed record class MajorObjectTarget : ITarget
{
    /// <summary>The <see cref="Identification.MajorObject"/> which represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObject MajorObject { get; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    private ITargetComposer<MajorObject> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectTarget(MajorObject majorObject, ITargetComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => Composer.Compose(MajorObject);
}
