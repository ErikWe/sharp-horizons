namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments;
using SharpHorizons.Identification;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an <see cref="Identification.MPCObject"/>.</summary>
internal sealed record class MPCObjectTarget : ITarget
{
    /// <summary>The <see cref="Identification.MPCObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCObject MPCObject { get; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    private ITargetComposer<MPCObject> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject"><inheritdoc cref="MPCObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MPCObjectTarget(MPCObject mpcObject, ITargetComposer<MPCObject> composer)
    {
        MPCObject = mpcObject;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => Composer.Compose(MPCObject);
}
